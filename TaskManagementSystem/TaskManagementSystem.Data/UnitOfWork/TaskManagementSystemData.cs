namespace TaskManagementSystem.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using TaskManagementSystem.Data.Repositories;
    using TaskManagementSystem.Models;

    public class TaskManagementSystemData : ITaskManagementSystemData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public TaskManagementSystemData()
            : this(new TaskManagementSystemDbContext())
        {
        }

        public TaskManagementSystemData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<TaskProject> Tasks
        {
            get
            {
                return this.GetRepository<TaskProject>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EntityFrameworkRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}