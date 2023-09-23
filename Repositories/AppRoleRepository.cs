
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Repositories
{
    public class AppRoleRepository : Repository<AppRole>
    {
        ApplicationDbContext applicationDbContext;

        public AppRoleRepository(ApplicationDbContext context) : base(context)
        {
             applicationDbContext = context;

        }
    }
}
