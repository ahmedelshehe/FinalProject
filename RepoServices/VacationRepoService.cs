﻿using FinalProject.Data;
using FinalProject.Helper;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.WebPages;

namespace FinalProject.RepoServices
{
    public class VacationRepoService : IVacationRepository
    {
        public ApplicationDbContext context { get; }


        public VacationRepoService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public List<Vacation> GetVacations()
        {
            return context.Vacations.Include(v => v.Employee).ToList();
        }
        public Vacation GetVacation(int id, DateTime startDate)
        {
            return context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == id && v.StartDate == startDate);
        }
        public List< Vacation> GetVacationById(int id)
        {
            return context.Vacations.Include(v => v.Employee).Where(v => v.EmployeeId == id ).ToList();
        }

        public void InsertVacation(Vacation vacation)
        {
            if (vacation != null)
            {
                context.Vacations.Add(vacation);
                context.SaveChanges();
            }
        }

        public void UpdateVacation(int id, DateTime startDate, Vacation vacation)
        {
            Vacation editVacation = context.Vacations.FirstOrDefault(v => v.EmployeeId == id && v.StartDate == startDate);
            if (editVacation != null)
            {
                editVacation.Status = vacation.Status;
                context.SaveChanges();

            }
        }
        public void DeleteVacation(int id, DateTime startDate)
        {
            Vacation deleteVacation = context.Vacations.Include(v => v.Employee).FirstOrDefault(v => v.EmployeeId == id && v.StartDate == startDate);
            if (deleteVacation != null)
            {
                context.Vacations.Remove(deleteVacation);
                context.SaveChanges();
            }
        }

        public bool IsVacation(int id, DateTime date)
        {
            var vacations = context.Vacations.Include(v => v.Employee).Where(v => v.EmployeeId == id && v.Status == VacationStatus.Approved).ToList();
            return !vacations.Any(v => v.StartDate.Date <= date.Date && date.Date <= v.EndDate.Date);
        }

		public int GetVacationDays(int id, DateTime startDate)
		{
			var vacation = context.Vacations.FirstOrDefault(v => v.EmployeeId == id && v.StartDate == startDate);
            var officialHolidays = context.OfficalVacations.Where(o => o.Date.Year == startDate.Year || o.Date.Year == startDate.AddYears(1).Year).Select(o => o.Date).ToList();
            var weeklyHoildays = context.WeeklyHolidays.Select(w => w.Holiday).ToList();
            return HelperShared.GetWorkDays(vacation.StartDate, vacation.EndDate, weeklyHoildays, officialHolidays);

		}
	}
}