using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IUserRepository
    {
        public List<AppUser> GetUsers();
        public AppUser GetUser(string id);
        public void InsertUser(AppUser appUser);
        public void UpdateUser(string id, AppUser appUser);
        public void DeleteUser(string id);

    }
}
