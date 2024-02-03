namespace Project_Management_System.Models
{
    public class TaskViewModel
    {
        public enum TaskPriority
        {
            None,
            Low,
            Medium,
            High
        }
        public TaskViewModel(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public TimeSpan TaskDuration { get; set; }

        public string TaskDescription { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }

        public string Tags { get; set; }

        public TaskPriority Priority { get; set; }

    }
}