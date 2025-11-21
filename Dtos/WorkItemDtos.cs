using System;
using System.ComponentModel.DataAnnotations;
using FutureOfWork.Api.Models;

namespace FutureOfWork.Api.Dtos
{
    public class WorkItemCreateDto
    {
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class WorkItemUpdateDto
    {
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        public WorkItemStatus Status { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class WorkItemReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public WorkItemStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
