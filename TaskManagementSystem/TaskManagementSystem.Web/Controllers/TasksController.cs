namespace TaskManagementSystem.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using TaskManagementSystem.Data;
    using TaskManagementSystem.Models;
    using TaskManagementSystem.Web.Models;

    [Authorize]
    public class TasksController : BaseController
    {
        private TaskManagementSystemDbContext db = new TaskManagementSystemDbContext();
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedDate,RequiredByDate,Description,Status,Type,NextActionDate")] TaskProject taskProject)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(taskProject);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(taskProject);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskProject taskProject = db.Tasks.Find(id);
            if (taskProject == null)
            {
                return HttpNotFound();
            }
            return View(taskProject);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedDate,RequiredByDate,Description,Status,Type,NextActionDate")] TaskProject taskProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(taskProject);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskProject taskProject = db.Tasks.Find(id);
            if (taskProject == null)
            {
                return HttpNotFound();
            }
            return View(taskProject);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskProject taskProject = db.Tasks.Find(id);
            db.Tasks.Remove(taskProject);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public ActionResult List()
        {
            var tasks = this.Data.Tasks
                .All()
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new TaskConciseViewModel
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    RequiredByDate = x.RequiredByDate,
                    Description = x.Description,
                    Type = x.Type
                });

            return View(tasks);
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            var task = this.Data.Tasks
                .All()
                .Where(x => x.Id == id)
                .Select(x => new TaskDetailsViewModel
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    RequiredByDate = x.RequiredByDate,
                    Description = x.Description,
                    Status = x.Status,
                    Type = x.Type,
                    NextActionDate = x.NextActionDate,
                    Comments = x.Comments.Select(y => new CommentViewModel
                    {
                        DateAdded = y.DateAdded,
                        Content = y.Content,
                        Type = y.Type,
                        ReminderDate = y.ReminderDate,
                        AuthorUsername = y.User.UserName
                    })
                }).FirstOrDefault();

            return View(task);
        }

        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    UserId = userId,
                    DateAdded = commentModel.DateAdded,
                    Content = commentModel.Comment,
                    ReminderDate = commentModel.ReminderDate,
                    Type = commentModel.Type,
                    TaskProjectId = commentModel.TaskId
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = username, Content = commentModel.Comment };
                return View(viewModel);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
            }
        }
    }
}
