using TaskStatus=task_managerApi.Models.Enum.TaskStatus;
namespace task_managerApi.Models {
    public class TaskModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime Deadline { get; set; }
    }
}
