
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class DepartmentRepository : Repository<Department>
    {
        ApplicationDbContext applicationDbContext;

        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            applicationDbContext = context; 
        }
    }
}
