using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
    public class DepartmentRepoService:IDepartmentRepository
    {
        public ApplicationDbContext context { get; }
        public DepartmentRepoService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<Department> GetDepartments()
        {
            return context.Departments.ToList();
        }

        public Department GetDepartment(int id)
        {
            return context.Departments.Include(d => d.Employees).FirstOrDefault(d => d.Id == id);
        }

        public void InsertDepartment(Department department)
        {
            if (department != null)
            {
                context.Departments.Add(department);
                context.SaveChanges();
            }
        }

        public void UpdateDepartment(int id, Department department)
        {
            Department editDepartment = context.Departments.FirstOrDefault(e => e.Id == id);
            if (editDepartment != null)
            {
                editDepartment.Name = department.Name;
                editDepartment.Employees = department.Employees;
                context.SaveChanges();
            }
        }

        public void DeleteDepartment(int id)
        {
            Department editDepartment = context.Departments.FirstOrDefault(e => e.Id == id);
            if (editDepartment != null)
            {
                context.Departments.Remove(editDepartment); 
                context.SaveChanges();
            }

        }
    }
}
