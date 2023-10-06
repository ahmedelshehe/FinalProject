using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public class WeeklyHolidayRepository:IWeeklyHolidayRepository
    {
        public ApplicationDbContext context { get; }
        public WeeklyHolidayRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(List<WeekDaysViewModel> selectedDays)
        {
            foreach (var item in selectedDays)
            {
                await context.WeeklyHolidays.AddAsync(new WeeklyHoliday { Genral_Id = 1, Holiday = item.Day });
            }
        }


        public async Task DeleteAllAsync()
        {
            var allHolidays = context.WeeklyHolidays.ToList();

            context.WeeklyHolidays.RemoveRange(allHolidays);
            await context.SaveChangesAsync();
        }

        public List<WeeklyHoliday> GetAllHolidays()
        {
            return context.WeeklyHolidays.ToList();
        }

    }
}
