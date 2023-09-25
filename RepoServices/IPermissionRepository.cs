using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IPermissionRepository
    {
        public List<Permission> GetPermissions();
        public Permission GetPermission(int id);
        public void InsertPermission(Permission permission);
        public void UpdatePermission(int id, Permission permission);
        public void DeletePermission(int id);

        public void AddPermissionToRole(string RoleId,List<Permission> permission);
    }
}
