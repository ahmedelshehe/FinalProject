using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public interface ISalaryService
    {
        public List<SalaryViewModel> GetData(int? Year, int? Month);
    }
}
