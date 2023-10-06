using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public class OfficialVacationRepoService : IOfficialVacationRepository
    {
        ApplicationDbContext _context;

        public OfficialVacationRepoService(ApplicationDbContext context)
        {
            _context = context;
        }



        public List<OfficialVacation> GetOfficialVacations()
        {
            return _context.OfficalVacations.ToList();
        }

        public OfficialVacation GetOfficialVacation(int id)
        {
            return _context.OfficalVacations.FirstOrDefault(o => o.Id == id);
        }


        public void InsertOfficialVacation(OfficialVacationViewModel Vacation)
        {
            var VacationDb = new OfficialVacation()
            {
                Title = Vacation.Name,
                Date = Vacation.Date
            };
            _context.OfficalVacations.Add(VacationDb);
            _context.SaveChanges();
        }

        public void UpdateOfficialVacation(int Id, OfficialVacationViewModel Vacation)
        {
            OfficialVacation updatevacations = GetOfficialVacation(Id);
            updatevacations.Title = Vacation.Name;
            updatevacations.Date = Vacation.Date;
            _context.SaveChanges();

        }




        public void DeleteOfficialVacation(int Id)
        {
            var vacation = _context.OfficalVacations.FirstOrDefault(o => o.Id == Id);
            if (vacation != null)
            {
                _context.OfficalVacations.Remove(vacation);
                _context.SaveChanges();
            }

        }


    }
}
