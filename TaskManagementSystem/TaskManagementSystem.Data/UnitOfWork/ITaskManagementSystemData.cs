namespace TaskManagementSystem.Data.UnitOfWork
{
    using Models;
    using Repositories;

    public interface ITaskManagementSystemData
    {
        IRepository<User> Users { get; }

        IRepository<TaskProject> Tasks { get; }

        IRepository<Comment> Comments { get; }
        
        int SaveChanges();
    }
}
