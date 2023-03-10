using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
