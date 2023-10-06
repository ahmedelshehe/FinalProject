using FinalProject.Models;

namespace FinalProject.RepoServices
{
	public interface IVacationRepository
	{
		public List<Vacation> GetVacations();
		public Vacation GetVacation(int id , DateTime date);
		public void InsertVacation(Vacation vacation);
		public void UpdateVacation(int id, DateTime startDate,Vacation vacation);
		public void DeleteVacation(int id,DateTime startDate);
		public bool IsVacation(int id,DateTime date);

	}
}
