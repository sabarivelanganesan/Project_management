namespace Project_Management_System.Models
{
    public class TaskModel
    {
        public enum TaskPriority
        {
            None,
            Low,
            Medium,
            High
        }
        public TaskModel(int projectId)
        {
            this.ProjectId = projectId;
        }

        public TaskModel()
        {

        }

        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskOwner { get; set; }

        public string TaskStatus { get; set; }
        public TimeSpan TaskDuration { get; set; }

        public string TaskDescription { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }

        public string Tags { get; set; }

        public TaskPriority Priority { get; set; }
        public IFormFile TaskAttachment { get; set; }

    }
}