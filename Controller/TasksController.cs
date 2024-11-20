using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_managerApi.Data;
using task_managerApi.Models;
namespace task_managerApi.Controller {
    
    [ApiController]
    [Route("api")]
    public class TasksController : ControllerBase{
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTask(TaskModel model)
        {
            _context.Tasks.Add(model);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetAllTasks), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskModel task)
        {
            if (id != task.Id) return BadRequest();
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
