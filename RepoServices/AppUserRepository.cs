using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
    public class AppUserRepository : IUserRepository
    {
        public ApplicationDbContext context { get; }
        public AppUserRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<AppUser> GetUsers()
        {
            return context.AppUsers.Include(a => a.Employee).Include(a => a.Role).ToList();
        }

        public AppUser GetUser(int id)
        {
            return context.AppUsers.Include(a => a.Employee).Include(a => a.Role).FirstOrDefault(a => a.AppId == id); ;
        }

        public void InsertUser(AppUser appUser)
        {
            if (appUser != null)
            {
                context.AppUsers.Add(appUser);
                context.SaveChanges();

            }
        }

        public void UpdateUser(int id, AppUser appUser)
        {
            AppUser editUser = context.AppUsers.Include(a => a.Employee).Include(a => a.Role).FirstOrDefault(a => a.AppId == id);
            if (editUser != null)
            {
                editUser.UserName = appUser.UserName;
                editUser.Email = appUser.Email;
                editUser.RoleAppId = appUser.RoleAppId;
                editUser.Role = appUser.Role;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            AppUser deleteUser = context.AppUsers.Include(a => a.Employee).Include(a => a.Role).FirstOrDefault(a => a.AppId == id);
            if (deleteUser != null)
            {
                context.AppUsers.Remove(deleteUser);
                context.SaveChanges();
            }
            throw new NotImplementedException();
        }
    }
}
