using GaribExam.DAL;
using GaribExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GaribExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BlogerContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 10;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;


            }).AddEntityFrameworkStores<BlogerContext>().AddDefaultTokenProviders();

            var app = builder.Build();

            
           
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllerRoute("areas","{area:exists}/{controller=Employee}/{action=Index}/{id?}"
		 );

			app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
