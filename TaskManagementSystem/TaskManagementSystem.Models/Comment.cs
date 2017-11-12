namespace TaskManagementSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:mm hh dd MM, yyyy}")]
        public DateTime DateAdded { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        //Here I don't undrstand very well what types of comments should be made.
        public CommentType Type { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:mm hh dd MM, yyyy}")]
        public DateTime ReminderDate { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int TaskProjectId { get; set; }

        public virtual TaskProject Task { get; set; }
    }
}
