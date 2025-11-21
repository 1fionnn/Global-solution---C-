using System.ComponentModel.DataAnnotations;

namespace FutureOfWork.Api.Dtos
{
    public class CommentCreateDto
    {
        [Required] public string Author { get; set; }
        [Required] public string Message { get; set; }
    }

    public class CommentReadDto
    {
        public int Id { get; set; }
        public int WorkItemId { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedAt { get; set; }
    }
}
