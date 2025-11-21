using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutureOfWork.Api.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required] public int WorkItemId { get; set; }
        [ForeignKey(nameof(WorkItemId))]
        public WorkItem WorkItem { get; set; }

        [Required] public string Author { get; set; }
        [Required] public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
