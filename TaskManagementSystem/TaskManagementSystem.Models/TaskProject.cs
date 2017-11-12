namespace TaskManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //I called the class TaskProject instead only Task, because there already exist class with that name in ASP.NET MVC.
    public class TaskProject
    {
        private ICollection<User> users;
        private ICollection<Comment> comments;

        public TaskProject()
        {
            this.users = new HashSet<User>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MM, yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MM, yyyy}")]
        public DateTime RequiredByDate { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        [Required]
        public TaskType Type { get; set; }

        //This is the list of users for which it is intended.
        [Display(Name = "Assigned to")]
        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MM, yyyy}")]
        public DateTime NextActionDate { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
