namespace TaskManagementSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using TaskManagementSystem.Models;

    public class TaskManagementSystemDbContext : IdentityDbContext<User>
    {
        public TaskManagementSystemDbContext()
            : base("TaskManagementSystemtConnection", throwIfV1Schema: false)
        {
        }

        public static TaskManagementSystemDbContext Create()
        {
            return new TaskManagementSystemDbContext();
        }
    }
}
