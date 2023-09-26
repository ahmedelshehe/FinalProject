using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IAppRoleRepository
    {
        public AppRole GetAppRoleWithPermissions(string id);

    }
}
