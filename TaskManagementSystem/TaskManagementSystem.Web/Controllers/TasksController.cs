namespace TaskManagementSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using TaskManagementSystem.Web.Models;

    public class TasksController : BaseController
    {
        [Authorize]
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

        
    }
}