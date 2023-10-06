using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using FinalProject.Global;
//using DayOfWeek = FinalProject.Global.DayOfWeek;

namespace FinalProject.Controllers
{
    [Authorize]
    public class GeneralSettingController : Controller
    {
        private readonly IGeneralSettingRepository generalSettingRepository;
        private readonly IWeeklyHolidayRepository weeklyHolidayRepository;

        public GeneralSettingController(IGeneralSettingRepository generalSettingRepository, IWeeklyHolidayRepository weeklyHolidayRepository)
        {
            this.generalSettingRepository = generalSettingRepository;
            this.weeklyHolidayRepository = weeklyHolidayRepository;
        }
        [AuthorizeByPermission("GeneralSetting", Operation.Show)]
        [AuthorizeByPermission("GeneralSetting", Operation.Update)]
        public IActionResult Index()
        {
            var generalVM = new SettingViewModel();
            generalVM.Extra = generalSettingRepository.OverTimePricePerHour();
            generalVM.Discount = generalSettingRepository.DiscountTimePricePerHour();
            var SelectedDays = weeklyHolidayRepository.GetAllHolidays().Select(n => n.Holiday).ToList();
            var allDays = Global.DayOfWeek.GetWeekDay();
            var checkedDays = allDays.Select(n => new WeekDaysViewModel { Day = n }).ToList();
            foreach (var item in checkedDays)
            {
                if (SelectedDays.Any(n => n == item.Day))
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
            generalVM.DayChecked = checkedDays;

            return View(generalVM);
        }



        [AuthorizeByPermission("GeneralSetting", Operation.Show)]
        [AuthorizeByPermission("GeneralSetting", Operation.Update)]
        public async Task<IActionResult> Save(SettingViewModel vm)
        {

            if (ModelState.IsValid)
            {
                await weeklyHolidayRepository.DeleteAllAsync();
                var selectedDays = vm.DayChecked.Where(n => n.Checked).ToList();
                await weeklyHolidayRepository.AddAsync(selectedDays);
                await generalSettingRepository.AddAsync(new GeneralSetting
                {
                    DiscountHourPrice = vm.Discount,
                    ExtraHourPrice = vm.Extra
                });
                return RedirectToAction(nameof(Index));
            }
            return View("Index", vm);
        }





        //public ActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(GeneralSetting generalSetting)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        generalSettingRepository.insert(generalSetting);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //        return View(generalSetting);
        //}


    }
}
