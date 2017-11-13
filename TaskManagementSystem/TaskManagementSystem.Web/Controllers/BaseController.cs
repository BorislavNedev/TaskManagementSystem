namespace TaskManagementSystem.Web.Controllers
{
    using System.Web.Mvc;
    using TaskManagementSystem.Data.UnitOfWork;

    public class BaseController : Controller
    {
        protected ITaskManagementSystemData Data;

        public BaseController(ITaskManagementSystemData data)
        {
            this.Data = data;
        }

        public BaseController()
            :this(new TaskManagementSystemData())
        {
        }
    }
}