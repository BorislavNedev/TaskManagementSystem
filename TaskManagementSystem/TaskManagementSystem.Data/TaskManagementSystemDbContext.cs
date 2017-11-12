namespace TaskManagementSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TaskManagementSystem.Models;

    public class TaskManagementSystemDbContext : IdentityDbContext<User>
    {
        public TaskManagementSystemDbContext()
            : base("TaskManagementSystemConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<TaskProject> Tasks { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static TaskManagementSystemDbContext Create()
        {
            return new TaskManagementSystemDbContext();
        }
    }
}
