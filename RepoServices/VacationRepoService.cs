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
		List<Vacation> IVacationRepository.GetVacations()
		{
			return context.Vacations.Include(v => v.Employee).ToList();
		}
        public Vacation GetVacation(int id , DateTime startDate)
        {
            return context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == id && v.StartDate == startDate);
        }


        void IVacationRepository.InsertVacation(Vacation vacation)
		{
			if (vacation != null)
			{
				context.Vacations.Add(vacation);
				context.SaveChanges();
			}
		}

		void IVacationRepository.UpdateVacation(int id, Vacation vacation , DateTime startDate)
		{
			Vacation editVacation = context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == id && vacation.StartDate == startDate);
			if (editVacation != null)
			{
				editVacation.EndDate = vacation.EndDate;
				editVacation.VacationType = vacation.VacationType;
				editVacation.Description = vacation.Description;
				editVacation.Status = vacation.Status;

                context.SaveChanges();
			}
		}
		void IVacationRepository.DeleteVacation(int id)
		{
			Vacation deleteVacation = context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == id);
			if (deleteVacation != null)
			{
				context.Vacations.Remove(deleteVacation);
				context.SaveChanges();
			}
		}
	}
}
