namespace TaskManagementSystem.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using TaskManagementSystem.Models;

    public class HomePageViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RequiredByDate { get; set; }
        
        public string Description { get; set; }
        
        public TaskType Type { get; set; }      
    }
}