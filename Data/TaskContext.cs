using Microsoft.EntityFrameworkCore;
using task_managerApi.Models;

namespace task_managerApi.Data {
    public class TaskContext : DbContext {
        public DbSet<TaskModel> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=tasks.db");
    }
}
