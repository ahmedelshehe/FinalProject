using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
    public class AppRoleRepoService : IAppRoleRepository
    {
        public AppRoleRepoService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ApplicationDbContext context { get; }

        public AppRole GetAppRoleWithPermissions(string id)
        {
            return context.AppRoles.Include(r => r.Permissions).FirstOrDefault(r => r.Id == id);
        }
        public List<AppRole> getAllRoles()
        {
            return context.AppRoles.ToList();
        }
        public AppRole GetAppRole(string id)
        {
            return context.AppRoles.FirstOrDefault(e => e.Id == id);
        }


    }
}
