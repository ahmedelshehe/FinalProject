using FinalProject.Data;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.RepoServices
{
    public class GeneralSetiingRepository : IGeneralSettingRepository
    {
        private readonly ApplicationDbContext context;

        public GeneralSetiingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int DiscountTimePricePerHour()
        {
            return context.GeneralSetting.Select(g => g.DiscountHourPrice).FirstOrDefault();
        }


        public int OverTimePricePerHour()
        {
            return context.GeneralSetting.Select(g => g.ExtraHourPrice).FirstOrDefault();
        }

        public void insert(GeneralSetting generalSetting)
        {
            if (generalSetting != null)
            {
                context.GeneralSetting.Add(generalSetting);
                context.SaveChanges();
            }

        }


        //    public async Task AddAsync(GeneralSetting NewGeneralSetting)
        //    {
        //        var generalSettingDb =  context.GeneralSetting.FirstOrDefault(g => g.Id == 1);
        //        if (generalSettingDb == null)
        //        {
        //NewGeneralSetting.Id = 1;
        //            await context.GeneralSetting.AddAsync(NewGeneralSetting);
        //        }
        //        else
        //        {
        //            generalSettingDb.DiscountHourPrice = NewGeneralSetting.DiscountHourPrice;
        //            generalSettingDb.ExtraHourPrice = NewGeneralSetting.ExtraHourPrice;
        //            context.GeneralSetting.Update(generalSettingDb);
        //        }
        //        await context.SaveChangesAsync();
        //    }

        public async Task AddAsync(GeneralSetting NewGeneralSetting)
        {
            var generalSettingDb =  context.GeneralSetting.FirstOrDefault(g => g.Id == 1);
            if (generalSettingDb == null)
            {
                NewGeneralSetting.Id = 1;
                await context.GeneralSetting.AddAsync(NewGeneralSetting);
            }
            else
            {
                generalSettingDb.DiscountHourPrice = NewGeneralSetting.DiscountHourPrice;
                generalSettingDb.ExtraHourPrice = NewGeneralSetting.ExtraHourPrice;
                context.GeneralSetting.Update(generalSettingDb);
            }
            await context.SaveChangesAsync();
        }


    }
}
