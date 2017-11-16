namespace TaskManagementSystem.Web.Models
{
    using System;
    using TaskManagementSystem.Models;

    public class SubmitCommentModel
    {
        public DateTime DateAdded { get; set; }
        
        public string Comment { get; set; }

        public DateTime ReminderDate { get; set; }

        public CommentType Type { get; set; }
        
        public int TaskId { get; set; }
    }
}