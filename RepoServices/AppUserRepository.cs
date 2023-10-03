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

        public AppUser GetUser(string id)
        {
            return context.AppUsers.Include(a => a.Employee).Include(a => a.Role).FirstOrDefault(a => a.Id == id); ;
        }

        public void InsertUser(AppUser appUser)
        {
            if (appUser != null)
            {
                context.AppUsers.Add(appUser);
                context.SaveChanges();

            }
        }

        public void UpdateUser(string id, AppUser appUser)
        {
            AppUser editUser = context.AppUsers.Include(a => a.Employee).Include(a => a.Role).FirstOrDefault(a => a.Id == id);
            if (editUser != null)
            {
                editUser.UserName = appUser.UserName;
                editUser.Email = appUser.Email;
                editUser.RoleAppId = appUser.RoleAppId;
                editUser.Role = appUser.Role;
                context.SaveChanges();
            }
        }

        public void DeleteUser(string id)
        {
            AppUser deleteUser = context.AppUsers.Include(a => a.Employee).Include(a => a.Role).FirstOrDefault(a => a.Id == id);
            if (deleteUser != null)
            {
                context.AppUsers.Remove(deleteUser);
                context.SaveChanges();
            }
        }
    }
}
