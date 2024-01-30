using Microsoft.AspNetCore.Mvc;

namespace Project_Management_System.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
