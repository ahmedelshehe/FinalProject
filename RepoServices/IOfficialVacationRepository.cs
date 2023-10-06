using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public interface IOfficialVacationRepository 
    {
        public List<OfficialVacation> GetOfficialVacations();
        public OfficialVacation GetOfficialVacation(int id);
        public void InsertOfficialVacation(OfficialVacationViewModel Vacation);

        public void UpdateOfficialVacation(int Id, OfficialVacationViewModel Vacation);

        public void DeleteOfficialVacation(int Id);


     
      
     




    }
}
