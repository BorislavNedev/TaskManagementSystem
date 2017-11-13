using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Web.Models;

namespace TaskManagementSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var listOfTasks = this.Data.Tasks
                .All()
                .OrderByDescending(x => x.CreatedDate)
                .Take(6)
                .Select(x => new HomePageViewModel
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