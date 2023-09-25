using FinalProject.Data;
using FinalProject.Models;

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
            return _context.OfficalVacations.FirstOrDefault( o => o.Id == id);
        }
        public void InsertOfficialVacation(OfficialVacation Vacation)
        {
            _context.OfficalVacations.Add(Vacation);
            _context.SaveChanges();
        }

        public void UpdateOfficialVacation(int Id, OfficialVacation Vacation)
        {
            _context.OfficalVacations.Update(Vacation);
            _context.SaveChanges();

        }

        public void DeleteOfficialVacation(int Id)
        {
            var vacation = _context.OfficalVacations.FirstOrDefault(o=> o.Id == Id);
            if(vacation != null)
            {
                _context.OfficalVacations.Remove(vacation);
                _context.SaveChanges();
            }

        }

    }
}
