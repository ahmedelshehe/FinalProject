
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repositories
{
    public class AppUserRepository : Repository<AppUser>
    {
        ApplicationDbContext applicationDbContext;
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
            applicationDbContext = context;
        }

        public IEnumerable<AppUser> GetAppUsersWithAppRoles()
        {
            return applicationDbContext.AppUsers.Include("AppRoles");
        }
    }
}
