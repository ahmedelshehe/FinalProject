using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public interface ISalaryService
    {
        public (List<SalaryViewModel> result, string alertMessage) GetData(int? Year, int? Month);
    }
}
