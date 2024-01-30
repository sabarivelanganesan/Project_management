using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Management_System.Models;

namespace Project_Management_System.Controllers
{
    public class ProjectsController : Controller
    {
        // Create a static list to store project data
        private static List<ProjectViewModel> projectList = new List<ProjectViewModel>();
        public IActionResult Index()
        {
            return View(projectList);
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectViewModel model)
        {
            projectList.Add(model);
            return RedirectToAction("Index");
            //return RedirectToAction("Index", "MyTasks");
        }

        [HttpGet]
        public JsonResult Overview_GetCountries(string search)
        {
            List<SelectListItem> countries = GetData(search);

            return Json(countries);
        }

        private static List<SelectListItem> GetData(string search)
        {
            List<SelectListItem> allCountries = new List<SelectListItem>()
            {
                new SelectListItem{ Value = "Sabarivelan", Text = "Sabarivelan"},
                new SelectListItem{ Value = "Ronaldo", Text = "Ronaldo"},
                new SelectListItem{ Value = "Lebron", Text = "Lebron"},
                new SelectListItem{ Value = "Dhoni", Text = "Dhoni"},
            };

            // Filter the items based on the search substring
            List<SelectListItem> filteredCountries = allCountries
                .Where(item => item.Text.StartsWith(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return filteredCountries;
        }
    }
}
