using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int id);
        public void InsertEmployee(Employee employee);
        public void UpdateEmployee(int id, Employee employee);
        public void DeleteEmployee(int id);
    }
}
