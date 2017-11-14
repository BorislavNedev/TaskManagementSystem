namespace TaskManagementSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using TaskManagementSystem.Web.Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var listOfTasks = this.Data.Tasks
                .All()
                .OrderByDescending(x => x.CreatedDate)
                .Take(6)
                .Select(x => new TaskConciseViewModel
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    RequiredByDate = x.RequiredByDate,
                    Description = x.Description,
                    Type = x.Type
                });

            return View(listOfTasks);
        }        
    }
}