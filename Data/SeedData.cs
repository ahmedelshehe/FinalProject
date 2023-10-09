using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NuGet.Packaging;
using System.Reflection.Emit;
using System.Security.Policy;

namespace FinalProject.Data
{

    public class SeedData
    {
        const string adminGuid = "2c5e174e-3b0e-446f-86af-483d56fd7210";


        private readonly ModelBuilder _builder;

        public SeedData( ModelBuilder modelBuilder)
        {
            _builder = modelBuilder;
        }


        public void SeedDatabase()
        {
            List<string> entityNames =
                new List<string> { "Employee", "Attendance", "AppRole", "AppUser", "Permission", "Department", "OfficialVacation","Vacation"  };
            List<Permission> permissions = new List<Permission>();
           
            int id = 1;
            foreach (string entityName in entityNames)
            {
                permissions.Add(new Permission { Id = id, Name = entityName, Operation = Operation.Show });
                permissions.Add(new Permission { Id = id + 1, Name = entityName, Operation = Operation.Update });
                permissions.Add(new Permission { Id = id + 2, Name = entityName, Operation = Operation.Delete });
                permissions.Add(new Permission { Id = id + 3, Name = entityName, Operation = Operation.Add });
                id += 4; // Decrease the id value by 4 for each iteration
            }
            permissions.Add(new Permission { Id = id + 1, Name = "GeneralSetting", Operation = Operation.Show });
            permissions.Add(new Permission { Id = id + 2, Name = "GeneralSetting", Operation = Operation.Update });
            permissions.Add(new Permission { Id = id + 3, Name = "Salary", Operation = Operation.Show });
            var AdminPermissions = permissions.Select(permission => new { AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210", PermissionsId = permission.Id }).ToList();
            _builder.Entity<Permission>(entity =>
            {
                entity.HasData(permissions);
            });
            Random rnd = new Random();
            var departments = new List<Department>() { 
                new Department(){Id = 1 , Name = "HR"  },            
                new Department(){Id = 2 , Name = "R & D"  },            
                new Department(){Id = 3 , Name = "IT"  },            
                new Department(){Id = 4 , Name = "Sales"  },            
            };
            _builder.Entity<Department>(entity =>
            {
                entity.HasData(departments);
            });

            var generalSetting = new GeneralSetting() { Id = 1 , DiscountHourPrice = 150 ,ExtraHourPrice = 75 ,numberofvacationInyear = 21 , PriceForDayOvernumberofvacationInyear = 300  };

            _builder.Entity<GeneralSetting>(entity =>
                entity.HasData(generalSetting)
                );
            // Create 50 employees
            var employees = new List<Employee>();
            for (int i = 1; i <= 50; i++)
            {
                var employee = new Employee
                {
                    Id = i,
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Middle(),
                    Email = "employee" + i + "@hrsm.com",
                    NationalId = "12345678901234",
                    Salary = rnd.Next(7000, 500000),
                    DeptID = rnd.Next(1, 4),
                    Gender = Faker.Enum.Random<Gender>(),
                    BirthDate = new DateTime(rnd.Next(1990, 2003), rnd.Next(1, 12), 1),
                    ContractDate = new DateTime(rnd.Next(2020, 2024), rnd.Next(1, 9), rnd.Next(1, 27)),
                    City= Faker.Address.City(),
                    Country = Faker.Address.Country(),
                    Street = Faker.Address.StreetName(),
                    AvailableVacations = 21
                };

                employees.Add(employee);
            }
            _builder.Entity<Employee>(entity =>
            {
                entity.HasData(employees);
            });
            var adminRole = new AppRole("Adminstrator") { Id = adminGuid };
            _builder.Entity("AppRolePermission").HasData(AdminPermissions);
            _builder.Entity<AppRole>().HasData(adminRole);

        }

        
        }
    public static class AdminSeeder
    {
        const string adminGuid = "2c5e174e-3b0e-446f-86af-483d56fd7210";

        public static async Task InitializeAdminUser(ApplicationDbContext context)
        {
            var adminEmployee = new AppUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                EmpId = 1, // ID of the employee who will be the admin
                UserName = "admin@example.com",
                Email = "admin@example.com",
                RoleAppId = adminGuid,
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            if (!context.Users.Any(u => u.UserName == adminEmployee.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(adminEmployee, "secret");
                adminEmployee.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(context);
                var result = userStore.CreateAsync(adminEmployee);
                if(result.IsCompletedSuccessfully)
                {   await context.SaveChangesAsync();
                    var emp = context.Employees.FirstOrDefault(e =>e.Id == adminEmployee.EmpId);
                    emp.UserId = adminEmployee.Id;
                    await context.SaveChangesAsync();
                }
            }

        }
    }
    }


