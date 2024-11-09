using ReadLine.Models;
using Microsoft.EntityFrameworkCore;using ReadLine.Models.People;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace ReadLine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddRazorPages();

            builder.Services.AddDbContext<MainDataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("MainDataConnection")); options.EnableSensitiveDataLogging(true); });
            builder.Services.AddDbContext<ModerateDataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("ModerateDataConnection")); options.EnableSensitiveDataLogging(true); });
            builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp", Version = "v1" });
            });

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();


            SeedMainData.SeedMainDatabase(app);
            // Configure the HTTP request pipeline.

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.MapDefaultControllerRoute();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");
            });
            app.Run();

        }
    }
}
