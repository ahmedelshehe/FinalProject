using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Middleware;
using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<AppUser,AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Register Services / Reposotories Here

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepoService>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepoService>();
            builder.Services.AddScoped<IPermissionRepository, PermissionRepoService>();

          builder.Services.AddScoped<IAttendanceRepositoryService, AttendanceRepositoryService>();
            builder.Services.AddScoped<IAppRoleRepository, AppRoleRepoService>();
            builder.Services.AddScoped<IOfficialVacationRepository, OfficialVacationRepoService>();
            builder.Services.AddScoped<IUserRepository, AppUserRepository>();
            builder.Services.AddScoped<ISalaryService, SalaryService>();
            builder.Services.AddScoped<IGeneralSettingRepository, GeneralSetiingRepository>();



            builder.Services.AddRazorPages();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                await AdminSeeder.InitializeAdminUser(context);
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<PermissionsMiddleware>();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}