using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IAppRoleRepository
    {
        public AppRole GetAppRoleWithPermissions(string id);

        public List<AppRole> getAllRoles();

        public AppRole GetAppRole(string id);


    }
}
