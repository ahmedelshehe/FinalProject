using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
    public class EmployeeRepoService : IEmployeeRepository
    {
        public ApplicationDbContext context { get;}
        public EmployeeRepoService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public List<Employee> GetEmployees()
        {
            return context.Employees.Include(e => e.Attendances).Include(e => e.Department).ToList();
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Include(e => e.Attendances).Include(e => e.Department).FirstOrDefault(e => e.Id == id);
        }

       
        public void InsertEmployee(Employee employee)
        {
            if (employee != null)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            Employee editEmployee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (editEmployee != null)
            {
                editEmployee.FirstName = employee.FirstName;
                editEmployee.LastName = employee.LastName;
                editEmployee.Street = employee.Street;
                editEmployee.City = employee.City;
                editEmployee.Country = employee.Country;
                editEmployee.Gender = employee.Gender;
                editEmployee.BirthDate = employee.BirthDate;
                editEmployee.ContractDate = employee.ContractDate;
                editEmployee.Email = employee.Email;
                editEmployee.NationalId = employee.NationalId;
                editEmployee.Salary = employee.Salary;
                editEmployee.DeptID = employee.DeptID;
                editEmployee.PhoneNumber = employee.PhoneNumber;
                context.SaveChanges();


            }
        }
        public void DeleteEmployee(int id)
        {
            Employee deleteEmployee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (deleteEmployee != null)
            {
                context.Employees.Remove(deleteEmployee);
                context.SaveChanges();

            }

        }

       
    }
}
