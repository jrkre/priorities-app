using priorities.Models;

namespace priorities.Data
{
    public class TaskSeeder
    {

        private readonly TaskContext _ctx;
        private readonly IWebHostEnvironment _env;


        TaskSeeder(TaskContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }


        public void Seed()
        {

            var tasks = new List<TaskItem>{
                new TaskItem{ Name = "assignment 1", Description = "assignment for cs 135", DueDate = DateTime.Now, Size = 1 },
                new TaskItem{ Name = "assignment 2", Description = "new improved assignment for cs 135", DueDate = DateTime.Now.AddDays(30), Size = 1 },
                new TaskItem{ Name = "essay", Description = "semester essay for english", DueDate = DateTime.Now.AddDays(70), Size = 10 },
                new TaskItem{ Name = "go to store", Description = "need cheese for james may", DueDate = DateTime.Now.AddDays(2), Size = 3 }
            };


            foreach(var task in tasks)
            {
                Console.WriteLine(task + "\'added\' to db");
                _ctx.Tasks.Add(task);
            }
        }
    }
}
