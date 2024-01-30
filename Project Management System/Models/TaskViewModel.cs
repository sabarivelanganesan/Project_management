namespace Project_Management_System.Models
{
    public class TaskViewModel
    {
        public string TaskName { get; set; }
        public int TaskDuration { get; set; }
        public List<string> Checklists { get; set; }
    }
}