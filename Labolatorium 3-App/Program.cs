using Data;
using Labolatorium_3_App.Models;
using Labolatorium_3_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Labolatorium_3_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddSession();
            builder.Services.AddTransient<IContactService, EFContactService>();
            builder.Services.AddTransient<IGroupService, EFGroupService>();
            builder.Services.AddTransient<IPostService, EFPostService>();
            // builder.Services.AddSingleton<IBookService, MemoryBookService>();
            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
           // builder.Services.AddSingleton<IContactService, MemoryContactService>();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();
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
            app.UseMiddleware<LastVisitCookie>();
            app.UseRouting();
            app.UseSession();
            app.MapRazorPages();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}