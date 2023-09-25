using FinalProject.Models;

namespace FinalProject.RepoServices
{
    public interface IOfficialVacationRepository 
    {
        public List<OfficialVacation> GetOfficialVacations();

        public OfficialVacation GetOfficialVacation(int id);
        public void InsertOfficialVacation(OfficialVacation Vacation);

        public void UpdateOfficialVacation(int Id,OfficialVacation Vacation);

        public void DeleteOfficialVacation(int Id);
    }
}
