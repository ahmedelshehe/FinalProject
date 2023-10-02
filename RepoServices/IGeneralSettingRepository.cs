using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public interface IGeneralSettingRepository
    {
      
            int OverTimePricePerHour();
            int DiscountTimePricePerHour();
            Task AddAsync(GeneralSetting generalSetting);

            public void insert(GeneralSetting generalSetting);
    }
}
