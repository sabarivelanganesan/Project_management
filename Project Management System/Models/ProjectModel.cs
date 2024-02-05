using System.Collections.Generic;

namespace Project_Management_System.Models
{
    public class ProjectModel
    {
        public ProjectModel() {
            tasks = new List<TaskModel>();
        }

        public List<TaskModel> tasks { get; set; }

        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Tags { get; set; }
        public string ProjectDescription { get; set; }

        //public List<TaskViewModel> Tasks { get; set; }
    }
}
