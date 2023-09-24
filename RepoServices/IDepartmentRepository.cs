using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IDepartmentRepository
    {
        public List<Department> GetDepartments();
        public Department GetDepartment(int id);
        public void InsertDepartment(Department department);
        public void UpdateDepartment(int id, Department department);
        public void DeleteDepartment(int id);
    }
}
