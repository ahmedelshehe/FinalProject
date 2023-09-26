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
            throw new NotImplementedException();
        }

        public AppUser GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
