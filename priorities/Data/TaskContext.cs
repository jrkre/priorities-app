using Microsoft.EntityFrameworkCore;
using priorities.Models;

namespace priorities.Data
{
    public class TaskContext : DbContext
    {
        private readonly IConfiguration _configuration;


        public TaskContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Microsoft.EntityFrameworkCore.DbSet<TaskItem> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = _configuration.GetConnectionString("taskDbContext");

            optionsBuilder.UseSqlServer(connectionString,builder => builder.EnableRetryOnFailure());

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
