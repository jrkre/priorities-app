using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using priorities.Data;

namespace priorities 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = BuildWebHost(args);

            if (args.Length == 1 && args[0].ToLower() == "/seed")
            {
                RunSeeding(app);
            }

            app.Run();
        }


        private static void RunSeeding(IWebHost app)
        {
            var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var seeder = scope.ServiceProvider.GetService<TaskSeeder>();
            seeder.Seed();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(AddConfiguration)
                .UseStartup<Startup>()
                .Build();


        private static void AddConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear(); // not necessary for normal implimentation

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            // because add env var is after json config, an environment var will override a json var
        }
    }
    /*var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Host

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();*/
}