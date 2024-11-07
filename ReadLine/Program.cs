using ReadLine.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Extensions.Options;
using ReadLine.Models.People;
using Microsoft.AspNetCore.Identity;

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
            builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

            var app = builder.Build();


            SeedMainData.SeedMainDatabase(app);
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

        }
    }
}
