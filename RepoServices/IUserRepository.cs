using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IUserRepository
    {
        public List<AppUser> GetUsers();
        public AppUser GetUser(int id);
        public void InsertUser(AppUser appUser);
        public void UpdateUser(int id, AppUser appUser);
        public void DeleteUser(int id);

    }
}
