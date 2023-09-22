using FinalProject.Models;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext 
        : IdentityDbContext<AppUser,AppRole,string,IdentityUserClaim<string>,IdentityUserRole<string>,IdentityUserLogin<string>,
            Permission,IdentityUserToken<string>>
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
            builder.Entity<Permission>(
                    entity => entity.ToTable(name: "Permissions")
                );
            builder.Entity<IdentityUserToken<string>>(
                    entity => entity.ToTable(name: "UserTokens")
                );
      
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
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

    }
}