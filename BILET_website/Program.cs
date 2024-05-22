using BILET_website.DAL;
using Microsoft.EntityFrameworkCore;

namespace BILET_website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {

                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }

            );
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );





            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}");
                

            app.Run();
        }
    }
}