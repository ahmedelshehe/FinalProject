using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public interface ISalaryService
    {
        public (List<SalaryViewModel> result, string alertMessage) getDataPerYear(int Year);

        public (List<SalaryViewModel> result, string alertMessage) getDataPerMonth(int Year, int Month);
        //public (List<SalaryViewModel> result, string alertMessage) getDataPerYearByEmployee(int Year, int empId);

    }
}
