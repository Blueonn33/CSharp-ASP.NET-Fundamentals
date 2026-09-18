using GarageApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GarageApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string connectionString = GetConnectionString(builder);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /*
               Register GarageAppDbContext in ASP.NET Core ServiceCollection
               This allows ASP.NET Core to instantiate DbContext with configured ConnectionString and pass it anywhere in the application through Dependency Injection (DI)
             */
            builder.Services.AddDbContext<GarageAppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            WebApplication app = builder.Build();

            /*
               The .Use() methods work with shared resource - HTTP Request
               Order of execution of .Use() methods matters
            */

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            /* Enables ASP.NET Core Routing Engine */
            /* Automatic Routing based on URL Path from HTTP Request */
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            /*
               When configuring more than 1 Route Convention:
               Map most specific route patterns first 
               Continue with broader more generalized patterns
            */
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        private static string GetConnectionString(IHostApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection");

            if (String.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = builder.Configuration
                    .GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Default connection string is not configured");
            }

            return connectionString;
        }
    }
}