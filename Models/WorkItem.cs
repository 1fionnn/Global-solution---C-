using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FutureOfWork.Api.Models
{
    public enum WorkItemStatus
    {
        Pending,
        InProgress,
        Review,
        Done,
        Rejected
    }

    public class WorkItem
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; } // nome do funcionário que criou a entrega
        public WorkItemStatus Status { get; set; } = WorkItemStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }

        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
