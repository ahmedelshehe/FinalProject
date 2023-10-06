using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public interface IWeeklyHolidayRepository
    {
        List<WeeklyHoliday> GetAllHolidays();
        Task AddAsync(List<WeekDaysViewModel> selectedDays);
        Task DeleteAllAsync();
    }
}
