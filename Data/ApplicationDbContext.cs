using FinalProject.Models;
using FinalProject.Utilities;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Reflection.Emit;

namespace FinalProject.Data
{
    public class ApplicationDbContext 
        : IdentityDbContext<AppUser,AppRole,string,IdentityUserClaim<string>,IdentityUserRole<string>,IdentityUserLogin<string>,
            IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Changing Database Schema 
            builder.HasDefaultSchema("dbo");
            // Renaming The Identity Tables
            builder.Entity<AppUser>(
                    entity =>  entity.ToTable(name: "User")    
                );
            builder.Entity<AppRole>(
                    entity => entity.ToTable(name: "Role")
                );
            builder.Entity<IdentityUserRole<string>>(
                    entity => entity.ToTable(name: "UserRoles")
                );
            builder.Entity<IdentityUserClaim<string>>(
                    entity => entity.ToTable(name: "UserClaims")
                );
            builder.Entity<IdentityUserLogin<string>>(
                    entity => entity.ToTable(name: "UserLogins")
                );
            builder.Entity<IdentityRoleClaim<string>>(
                    entity => entity.ToTable(name: "RoleClaims")
                );
            builder.Entity<IdentityUserToken<string>>(
                    entity => entity.ToTable(name: "UserTokens")
                );
            builder.Entity<Attendance>(
                entity => entity.HasKey("Date", "EmployeeId")
                );
            builder.Entity<PhoneNumber>(
                entity => entity.HasKey("Number", "EmployeeId")
                );
            builder.Entity<Vacation>(
                entity => entity.HasKey("StartDate", "EmployeeId")
                );
            builder.Entity<WeeklyHoliday>(
               entity => entity.HasKey("Holiday", "Genral_Id")
               );
            builder.Entity<Attendance>()
                .Property(a => a.ExtraHours)
                .HasComputedColumnSql("CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 8  THEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) - 8 ELSE 0 END");

            builder.Entity<EmployeeAttendanceVM>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.DepartureTime);
                entity.Property(e => e.DeptName);
                entity.Property(e => e.EmployeeId);
                //entity.Property(e => e.FulllName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.ArrivalTime);
                entity.Property(e => e.Date);

            });
            
            builder.Entity<Attendance>()
                .Property(a => a.DiscountHours)
                .HasComputedColumnSql("CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) < 8 AND DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 3 THEN 8 - DATEDIFF(HOUR, ArrivalTime, DepartureTime) ELSE 0 END");

            builder.Entity<Attendance>()
                .Property(a => a.IsAbsent)
                .HasComputedColumnSql("CONVERT(bit, CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) <= 3 THEN 1 ELSE 0 END)");
            var Seeder = new SeedData(builder);
            Seeder.SeedDatabase();
        }

        // Registering New Conversion Types For DateOnly, TimeOnly
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>();
            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>();
        }
        public virtual DbSet<Employee> Employees { get; set; }
        
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<OfficialVacation> OfficalVacations { get; set; }
        public virtual DbSet<GeneralSetting> GeneralSetting { get; set; }

        public virtual DbSet<Vacation> Vacations { get; set; }
        public DbSet<SettingViewModel> SettingViewModel { get; set; }
        public virtual DbSet<WeeklyHoliday> WeeklyHolidays { get; set; }

        public virtual DbSet<EmployeeAttendanceVM> EmployeeAttendanceReport { get; set; }


    }
}