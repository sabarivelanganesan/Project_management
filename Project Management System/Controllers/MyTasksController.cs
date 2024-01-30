using Microsoft.AspNetCore.Mvc;

namespace Project_Management_System.Controllers
{
    public class MyTasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
