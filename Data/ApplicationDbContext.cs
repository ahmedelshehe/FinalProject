using FinalProject.Models;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
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
            builder.Entity<IdentityRole>(
                    entity => entity.ToTable(name: "IdentityRole")
                );
            builder.Entity<IdentityUserRole<string>>(
                    entity => entity.ToTable(name: "IdentityUserRoles")
                );
            builder.Entity<IdentityUserClaim<string>>(
                    entity => entity.ToTable(name: "IdentityUserClaims")
                );
            builder.Entity<IdentityUserLogin<string>>(
                    entity => entity.ToTable(name: "IdentityUserLogins")
                );
            builder.Entity<IdentityRoleClaim<string>>(
                    entity => entity.ToTable(name: "IdentityRoleClaims")
                );
            builder.Entity<IdentityUserToken<string>>(
                    entity => entity.ToTable(name: "IdentityUserTokens")
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
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

    }
}