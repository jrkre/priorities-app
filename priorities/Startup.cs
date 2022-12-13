using Microsoft.EntityFrameworkCore;
using priorities.Data;
using priorities.Services;

namespace priorities
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaskContext>(cfg =>
            {
                cfg.UseSqlServer();
            });

            services.AddTransient<TaskSeeder>();
            services.AddTransient<ITaskService, TaskService>();

            //services.AddTransient<IMailService, NullMailService>(); // creates one of these - creates one instance of the object, might keep around might garbage collect


            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(
                    name: "Defualt",
                    pattern: "/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
