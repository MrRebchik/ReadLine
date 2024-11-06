using ReadLine.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Extensions.Options;

namespace ReadLine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<MainDataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("MainDataConnection")); options.EnableSensitiveDataLogging(true); });
            builder.Services.AddDbContext<ModerateDataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("ModerateDataConnection")); options.EnableSensitiveDataLogging(true); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();

            SeedMainData.SeedMainDatabase(app.Services.GetService<MainDataContext>());
        }
    }
}
