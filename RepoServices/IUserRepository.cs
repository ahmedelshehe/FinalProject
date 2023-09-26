using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IUserRepository
    {
        public List<AppUser> GetUsers();
        public AppUser GetUser(int id);

    }
}
