using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.RepoServices
{
	public class VacationRepoService : IVacationRepository
	{
		public ApplicationDbContext context { get; }
		public VacationRepoService(ApplicationDbContext _context) {
		context = _context;
		}
		public List<Vacation> GetVacations()
		{
			return context.Vacations.Include(v => v.Employee).ToList();
		}
        public Vacation GetVacation(int id , DateTime startDate)
        {
            return context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == id && v.StartDate == startDate);
        }


        public void InsertVacation(Vacation vacation)
		{
			if (vacation != null)
			{
				context.Vacations.Add(vacation);
				context.SaveChanges();
			}
		}

        public void  UpdateVacation(int id, DateTime startDate,Vacation vacation )
		{
			Vacation editVacation = context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == vacation.EmployeeId && vacation.StartDate == startDate);
			if (editVacation != null)
			{
				editVacation.Status = vacation.Status;

                context.Update(editVacation);
			}
		}
        public void  DeleteVacation(int id, DateTime startDate)
		{
			Vacation deleteVacation = context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == id && v.StartDate ==startDate);
			if (deleteVacation != null)
			{
				context.Vacations.Remove(deleteVacation);
				context.SaveChanges();
			}
		}

		public bool IsVacation(int id, DateTime date)
		{
			var vacations = context.Vacations.Include(v => v.Employee).Where(v => v.EmployeeId == id && v.Status == VacationStatus.Approved).ToList();
			return !vacations.Any(v => v.StartDate?.Date <= date.Date && date.Date <= v.EndDate?.Date);
		}

    }
}
