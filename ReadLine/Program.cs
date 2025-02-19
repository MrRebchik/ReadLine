using ReadLine.Models;
using Microsoft.EntityFrameworkCore;
using ReadLine.Models.People;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using ReadLine.Services;

namespace ReadLine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MainDataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("MainDataConnection")); options.EnableSensitiveDataLogging(true); });
            builder.Services.AddDbContext<ModerateDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ModerateDataConnection")));
            builder.Services.AddDbContext<ProfileContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("ProfileConnection")); options.EnableSensitiveDataLogging(true); });
            builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

            builder.Services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞßàáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüış";
            });
            builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, opts =>
            {
                opts.LoginPath = "/Login";
            });

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp", Version = "v1" });
            });

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddServerSideBlazor();

            //builder.Services.AddTransient<IUserContext, UserContext>();

            var app = builder.Build();


            SeedMainData.SeedMainDatabase(app);
            // Configure the HTTP request pipeline.

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapControllers();
            app.MapRazorPages();
            app.MapBlazorHub();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");
            });
            app.Run();

        }
    }
}
