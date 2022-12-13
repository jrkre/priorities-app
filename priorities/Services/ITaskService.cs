using priorities.Models;
using priorities.ViewModels;

namespace priorities.Services
{
    public interface ITaskService
    {
        Task<TaskItem> Get(string id);
        Task<IEnumerable<TaskItem>> GetTaskItems();
        Task<bool> AddTaskItem(TaskViewModel model);
        Task<TaskItem> UpdateTaskItem(TaskViewModel model);
        Task<TaskItem> DeleteTaskItem(string id);
        Task<TaskItem> DeleteTaskItem(TaskViewModel model);

    }
}
