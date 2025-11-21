using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FutureOfWork.Api.Data;
using FutureOfWork.Api.Models;
using FutureOfWork.Api.Dtos;

namespace FutureOfWork.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WorkItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public WorkItemsController(ApplicationDbContext db) => _db = db;

        // GET: api/v1/WorkItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkItemReadDto>>> GetAll()
        {
            var items = await _db.WorkItems
                .Include(w => w.Comments)
                .OrderByDescending(w => w.CreatedAt)
                .ToListAsync();

            var dto = items.Select(w => new WorkItemReadDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                Creator = w.Creator,
                Status = w.Status,
                CreatedAt = w.CreatedAt,
                DueDate = w.DueDate
            });

            return Ok(dto);
        }

        // GET: api/v1/WorkItems/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WorkItemReadDto>> GetById(int id)
        {
            var w = await _db.WorkItems.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (w == null) return NotFound();

            var dto = new WorkItemReadDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                Creator = w.Creator,
                Status = w.Status,
                CreatedAt = w.CreatedAt,
                DueDate = w.DueDate
            };

            return Ok(dto);
        }

        // POST: api/v1/WorkItems
        [HttpPost]
        public async Task<ActionResult<WorkItemReadDto>> Create([FromBody] WorkItemCreateDto create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var w = new WorkItem
            {
                Title = create.Title,
                Description = create.Description,
                Creator = create.Creator,
                DueDate = create.DueDate
            };

            _db.WorkItems.Add(w);
            await _db.SaveChangesAsync();

            var dto = new WorkItemReadDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                Creator = w.Creator,
                Status = w.Status,
                CreatedAt = w.CreatedAt,
                DueDate = w.DueDate
            };

            return CreatedAtAction(nameof(GetById), new { id = w.Id, version = "1.0" }, dto);
        }

        // PUT: api/v1/WorkItems/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] WorkItemUpdateDto update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var w = await _db.WorkItems.FindAsync(id);
            if (w == null) return NotFound();

            w.Title = update.Title;
            w.Description = update.Description;
            w.Status = update.Status;
            w.DueDate = update.DueDate;

            await _db.SaveChangesAsync();
            return NoContent(); // 204
        }

        // DELETE: api/v1/WorkItems/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var w = await _db.WorkItems.FindAsync(id);
            if (w == null) return NotFound();

            _db.WorkItems.Remove(w);
            await _db.SaveChangesAsync();
            return NoContent(); // 204
        }

        // POST: api/v1/WorkItems/5/comments
        [HttpPost("{id:int}/comments")]
        public async Task<ActionResult> AddComment(int id, [FromBody] CommentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var w = await _db.WorkItems.FindAsync(id);
            if (w == null) return NotFound();

            var comment = new Comment
            {
                WorkItemId = id,
                Author = dto.Author,
                Message = dto.Message
            };

            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();

            var read = new CommentReadDto
            {
                Id = comment.Id,
                WorkItemId = comment.WorkItemId,
                Author = comment.Author,
                Message = comment.Message,
                CreatedAt = comment.CreatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = id, version = "1.0" }, read);
        }
    }
}

