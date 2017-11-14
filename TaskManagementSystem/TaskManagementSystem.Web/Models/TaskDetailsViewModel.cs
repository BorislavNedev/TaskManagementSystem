namespace TaskManagementSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using TaskManagementSystem.Models;

    public class TaskDetailsViewModel
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime RequiredByDate { get; set; }
        
        public string Description { get; set; }
        
        public TaskStatus Status { get; set; }
        
        public TaskType Type { get; set; }
        
        public IEnumerable<User> Users { get; set; }

        public DateTime NextActionDate { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}