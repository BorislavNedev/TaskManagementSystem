namespace TaskManagementSystem.Web.Models
{
    using System;
    using TaskManagementSystem.Models;

    public class CommentViewModel
    {
        public DateTime DateAdded { get; set; }
        
        public string Content { get; set; }
        
        public CommentType Type { get; set; }
        
        public DateTime ReminderDate { get; set; }

        public string AuthorUsername { get; set; }
    }
}