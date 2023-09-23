
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        ApplicationDbContext applicationDbContext;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            applicationDbContext = context;
        }
    }
}
