using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public class PermissionRepoService : IPermissionRepository
    {
        public ApplicationDbContext context { get; }
        public PermissionRepoService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<Permission> GetPermissions()
        {
            return context.Permissions.ToList();
        }

        public Permission GetPermission(int id)
        {
            return context.Permissions.FirstOrDefault(p => p.Id == id );
        }

        public void InsertPermission(Permission permission)
        {
            if (permission != null)
            {
                context.Permissions.Add(permission);
                context.SaveChanges();
            }
        }

        public void UpdatePermission(int id, Permission permission)
        {
            Permission editPermission = context.Permissions.FirstOrDefault(e => e.Id == id);
            if (editPermission != null)
            {
                editPermission.Name = permission.Name;
                editPermission.Operation = permission.Operation;
                context.SaveChanges();
            }
        }

        public void DeletePermission(int id)
        {
            Permission editPermission = context.Permissions.FirstOrDefault(e => e.Id == id);
            if (editPermission != null)
            {
                context.Permissions.Remove(editPermission);
                context.SaveChanges();
            }

        }
    }
}
