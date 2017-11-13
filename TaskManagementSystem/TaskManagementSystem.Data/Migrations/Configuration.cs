namespace TaskManagementSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManagementSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TaskManagementSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaskManagementSystemDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }

            if (!context.Tasks.Any())
            {
                this.SeedTasks(context);
            }

            if (!context.Comments.Any())
            {
                this.SeedComments(context);
            }
        }

        private void SeedUsers(TaskManagementSystemDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var userToInsert = new User { UserName = "JoeSmith", Email = "JoeSmith@usa.net" };
            userManager.Create(userToInsert, "123456");
            userStore = new UserStore<User>(context);
            userManager = new UserManager<User>(userStore);
            userToInsert = new User { UserName = "DavidWeb", Email = "DavidWeb@gmail.com" };
            userManager.Create(userToInsert, "123456");
            userStore = new UserStore<User>(context);
            userManager = new UserManager<User>(userStore);
            userToInsert = new User { UserName = "MichaelJohnson", Email = "MichaelJohnson@gmail.com" };
            userManager.Create(userToInsert, "123456");
        }

        private void SeedTasks(TaskManagementSystemDbContext context)
        {
            var joeSmith = context.Users.FirstOrDefault(u => u.UserName == "JoeSmith");
            var davidWeb = context.Users.FirstOrDefault(u => u.UserName == "DavidWeb");
            var michaelJohnson = context.Users.FirstOrDefault(u => u.UserName == "MichaelJohnson");

            TaskProject firstTask = new TaskProject
            {
                CreatedDate = DateTime.Now.AddDays(-1),
                RequiredByDate = DateTime.Now.AddMonths(1),
                Description = "Develop new book entry screen.",
                Status = TaskStatus.Assigned,
                Type = TaskType.Development,
                Users = new List<User>
                {
                    davidWeb,
                    michaelJohnson
                },
                NextActionDate = DateTime.Now.AddMonths(1)
            };
            context.Tasks.Add(firstTask);            

            TaskProject secondTask = new TaskProject
            {
                CreatedDate = DateTime.Now.AddDays(-2),
                RequiredByDate = DateTime.Now.AddMonths(2),
                Description = "Develop new subject entry screen.",
                Status = TaskStatus.Assigned,
                Type = TaskType.Development,
                Users = new List<User>
                {
                    davidWeb
                },
                NextActionDate = DateTime.Now.AddMonths(1)
            };
            context.Tasks.Add(secondTask);

            TaskProject thirdTask = new TaskProject
            {
                CreatedDate = DateTime.Now.AddDays(-3),
                RequiredByDate = DateTime.Now.AddDays(40),
                Description = "Prepare the contract.",
                Status = TaskStatus.Assigned,
                Type = TaskType.Banking,
                Users = new List<User>
                {
                    joeSmith
                },
                NextActionDate = DateTime.Now.AddMonths(1)
            };
            context.Tasks.Add(thirdTask);

            TaskProject fourthTask = new TaskProject
            {
                CreatedDate = DateTime.Now.AddDays(-4),
                RequiredByDate = DateTime.Now.AddDays(40),
                Description = "Prepare the other contract.",
                Status = TaskStatus.Assigned,
                Type = TaskType.Banking,
                Users = new List<User>
                {
                    michaelJohnson
                },
                NextActionDate = DateTime.Now.AddMonths(1)
            };
            context.Tasks.Add(fourthTask);

            TaskProject fifthdTask = new TaskProject
            {
                CreatedDate = DateTime.Now.AddDays(-5),
                RequiredByDate = DateTime.Now.AddDays(40),
                Description = "Create edition object insert method.",
                Status = TaskStatus.Assigned,
                Type = TaskType.Development,
                Users = new List<User>
                {
                    joeSmith
                },
                NextActionDate = DateTime.Now.AddMonths(1)
            };
            context.Tasks.Add(fifthdTask);

            TaskProject sixthTask = new TaskProject
            {
                CreatedDate = DateTime.Now.AddDays(-6),
                RequiredByDate = DateTime.Now.AddDays(40),
                Description = "Write author object delete the query.",
                Status = TaskStatus.Assigned,
                Type = TaskType.Development,
                Users = new List<User>
                {
                    davidWeb
                },
                NextActionDate = DateTime.Now.AddMonths(1)
            };
            context.Tasks.Add(sixthTask);

            TaskProject sevenTask = new TaskProject
            {
                CreatedDate = DateTime.Now.AddDays(-7),
                RequiredByDate = DateTime.Now.AddDays(40),
                Description = "Some other Task.",
                Status = TaskStatus.Assigned,
                Type = TaskType.Catering,
                Users = new List<User>
                {
                    michaelJohnson
                },
                NextActionDate = DateTime.Now.AddMonths(1)
            };
            context.Tasks.Add(sevenTask);

            context.SaveChanges();
        }

        private void SeedComments(TaskManagementSystemDbContext context)
        {
            var joeSmith = context.Users.FirstOrDefault(u => u.UserName == "JoeSmith");
            var davidWeb = context.Users.FirstOrDefault(u => u.UserName == "DavidWeb");
            var michaelJohnson = context.Users.FirstOrDefault(u => u.UserName == "MichaelJohnson");

            var firstTask = context.Tasks.FirstOrDefault(t => t.Description == "Develop new book entry screen.");
            var secondTask = context.Tasks.FirstOrDefault(t => t.Description == "Develop new subject entry screen.");
            
            Comment firstComment = new Comment
            {
                Task = firstTask,
                DateAdded = DateTime.Now.AddDays(1),
                Content = "Thanks Mike",
                Type = CommentType.Medium,
                ReminderDate = DateTime.Now.AddDays(30),
                UserId = joeSmith.Id
            };
            context.Comments.Add(firstComment);

            Comment secondComment = new Comment
            {
                Task = firstTask,
                DateAdded = DateTime.Now.AddDays(4),
                Content = "Very well.",
                Type = CommentType.Medium,
                ReminderDate = DateTime.Now.AddDays(30),
                UserId = michaelJohnson.Id
            };
            context.Comments.Add(secondComment);

            Comment thirdComment = new Comment
            {
                Task = secondTask,
                DateAdded = DateTime.Now.AddDays(3),
                Content = "Greate job.",
                Type = CommentType.Medium,
                ReminderDate = DateTime.Now.AddDays(30),
                UserId = joeSmith.Id
            };
            context.Comments.Add(thirdComment);

            context.SaveChanges();
        }
    }
}
