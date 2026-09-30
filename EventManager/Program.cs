using EventManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration
                                          .GetConnectionString("SqlServerDev") ??
                                      throw new InvalidOperationException("Connection string was not found");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<EventManagerDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            WebApplication app = builder.Build();

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

            app.Run();
        }
    }
}
