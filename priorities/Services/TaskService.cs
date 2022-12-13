using Microsoft.EntityFrameworkCore;
using priorities.Data;
using priorities.Models;
using priorities.ViewModels;

namespace priorities.Services
{
    public class TaskService : ITaskService
    {

        private TaskContext context;

        public TaskService(TaskContext _ctx) 
        {
            context= _ctx;
        }

        public async Task<bool> AddTaskItem(TaskViewModel model)
        {
            TaskItem t = new TaskItem
            {
                Name = model.Name,
                Description = model.Description,
                DueDate = model.DueDate,
                Size = model.Size,
                Complete = false,
                Created = DateTime.Now
            };
            var result = await context.Tasks.AddAsync(t);

            if (result.IsKeySet)
            {
                return true;
            }

            return false;
        }

        public async Task<TaskItem> DeleteTaskItem(string id)
        {
            var item = await context.Tasks.Where(task => task.Id == id).FirstOrDefaultAsync();


            if (item != null)
            {
                var returns = context.Tasks.Remove(item);
                return returns.Entity;
            }


            return item;
        }

        public async Task<TaskItem> DeleteTaskItem(TaskViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<TaskItem> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItems()
        {
            var tasks = await context.Tasks.Where(task => task.Complete == false).OrderBy(task => task.DueDate).ToListAsync();

            return tasks;
        }

        public async Task<TaskItem> UpdateTaskItem(TaskViewModel model)
        {
            var taskToUpdate = await context.Tasks.Where(taskItem => taskItem.Name == model.Name && taskItem.DueDate == model.DueDate).FirstOrDefaultAsync();

            if (taskToUpdate != null)
            {
                taskToUpdate.DueDate = model.DueDate;
                taskToUpdate.Name = model.Name;
                taskToUpdate.Complete = model.Completed;
                taskToUpdate.Description = model.Description;

                context.Tasks.Update(taskToUpdate);
            }
            else
            {
                throw new Exception("no model found to update");
            }


            return taskToUpdate;

        }
    }
}
