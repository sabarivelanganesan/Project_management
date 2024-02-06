using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_Management_System.Models;
using System.Threading.Tasks;

namespace Project_Management_System.Controllers
{
    public class ProjectsController : Controller
    {
        // Create a static list to store project data
        private static List<ProjectModel> projectList = new List<ProjectModel>();
        private static List<TaskModel> taskList = new List<TaskModel>();
        private static int indexIncrement = 1;
        public IActionResult Index()
        {
            return View(projectList);
        }

        public IActionResult ProjectDetails(int id, string page)
        {
            var project = projectList.FirstOrDefault(p => p.ProjectId == id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            string ViewName = $"ProjectDetails/{page}";

            return View(ViewName, project);
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectModel model)
        {
            model.ProjectId = indexIncrement;
            indexIncrement++;
            TaskModel task = new TaskModel(model.ProjectId);
            model.tasks.Add(task);
            //Console.WriteLine(String.Format("Task Name {0}, Task Id {1}", model.tasks[0].TaskName, model.tasks[0].ProjectId));
            projectList.Add(model);
            return RedirectToAction("Index");
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
