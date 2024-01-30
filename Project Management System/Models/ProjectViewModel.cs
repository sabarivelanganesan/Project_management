namespace Project_Management_System.Models
{
    public class ProjectViewModel
    {
        private List<TaskViewModel> tasks;

        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Tags { get; set; }
        public string ProjectDescription { get; set; }
    }
}
