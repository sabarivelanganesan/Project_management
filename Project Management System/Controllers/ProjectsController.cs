using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Management_System.Models;

namespace Project_Management_System.Controllers
{
    public class ProjectsController : Controller
    {
        // Create a static list to store project data
        private static List<ProjectViewModel> projectList = new List<ProjectViewModel>();
        private static int indexIncrement = 1;
        public IActionResult Index()
        {
            return View(projectList);
        }

        public IActionResult ProjectDetails(int id=1)
        {
            var project = projectList.FirstOrDefault(p => p.ProjectId == id);
            /* var project = new ProjectViewModel
             {
                 ProjectId = id,
                 ProjectTitle = "Hardcoded Project",
                 StartTime = DateTime.Now,
                 EndTime = DateTime.Now.AddDays(30),
                 Tags = "Sample Tags",
                 ProjectOwner = "Ronaldo",
                 ProjectDescription = "This is a sample project description."
             };*/
            if (project == null)
            {
                // Handle the case where the project with the given ID is not found
                return RedirectToAction("Index");
            }

            // Pass the project details to the view
            Console.WriteLine("I got no idea here");
            return View("ProjectDetails/Tasks", project);
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectViewModel model)
        {
            model.ProjectId = indexIncrement;
            Console.WriteLine("Model" + model.ProjectId);
            Console.WriteLine("ProjectTitle" + model.ProjectTitle);
            indexIncrement++;
            projectList.Add(model);
            Console.WriteLine("Model Added");
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
                .Where(item => item.Text.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return filteredCountries;
        }
    }
}
