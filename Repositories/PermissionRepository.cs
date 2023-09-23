
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class PermissionRepository : Repository<Permission>
    {
        ApplicationDbContext applicationDbContext;

        public PermissionRepository(ApplicationDbContext context) : base(context)
        {
            applicationDbContext = context;
        }
    }
}
