using FinalProject.Models;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            List<string> entityNames = 
                new List<string> { "Employee", "Attendance", "AppRole","AppUser","Permission","Permission","OfficialVacation" };
            List<Permission> permissions = new List<Permission>();
            int id = -1;
            foreach (string entityName in entityNames)
            {
                permissions.Add(new Permission { Id = id, Name = entityName, Operation = Operation.Show });
                permissions.Add(new Permission { Id = id - 1, Name = entityName, Operation = Operation.Update });
                permissions.Add(new Permission { Id = id - 2, Name = entityName, Operation = Operation.Delete });
                permissions.Add(new Permission { Id = id - 3, Name = entityName, Operation = Operation.Add });
                id -= 4; // Decrease the id value by 4 for each iteration
            }

            builder.Entity<Permission>(entity =>
            {
                entity.HasData(permissions);
            });


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

        public virtual DbSet<Vacation> Vacations { get; set; }

    }
}