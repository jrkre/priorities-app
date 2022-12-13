using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using priorities.Models;
using priorities.Services;
using priorities.ViewModels;
using System.Diagnostics;
using System.Text.Encodings.Web;

namespace priorities.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITaskService taskService;

        public HomeController(ILogger<HomeController> logger, ITaskService taskService)
        {
            _logger = logger;
            this.taskService= taskService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = new List<TaskViewModel>{
                new TaskViewModel{ Name = "assignment 1", Description = "assignment for cs 135", DueDate = DateTime.Now, Size = 1 },
                new TaskViewModel{ Name = "assignment 2", Description = "new improved assignment for cs 135", DueDate = DateTime.Now.AddDays(30), Size = 1 },
                new TaskViewModel{ Name = "essay", Description = "semester essay for english", DueDate = DateTime.Now.AddDays(70), Size = 10 },
                new TaskViewModel{ Name = "go to store", Description = "need cheese for james may", DueDate = DateTime.Now.AddDays(2), Size = 3 }
            };

            var dbtasks = await taskService.GetTaskItems();

            return View(dbtasks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskViewModel task)
        {
            taskService.AddTaskItem(task);

            return Ok(task);
        }

        [HttpPost]
        public IActionResult CompleteTask(TaskViewModel task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            taskService.UpdateTaskItem(task);

            var tasksResult = taskService.GetTaskItems();
            
            return View(tasksResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}