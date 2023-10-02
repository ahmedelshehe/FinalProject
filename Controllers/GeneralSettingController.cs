using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FinalProject.Controllers
{
    public class GeneralSettingController : Controller
    {
        private readonly IGeneralSettingRepository generalSettingRepository;

        public GeneralSettingController(IGeneralSettingRepository generalSettingRepository)
        {
            this.generalSettingRepository = generalSettingRepository;
        }
        //[AuthorizeByPermission("GeneralSetting", Operation.Show)]
        //[AuthorizeByPermission("GeneralSetting", Operation.Update)]

        public IActionResult Index()
        {
            var generalVM = new SettingViewModel();
            generalVM.Extra = generalSettingRepository.OverTimePricePerHour();
            generalVM.Discount = generalSettingRepository.DiscountTimePricePerHour();
            return View(generalVM);
        }
        //[AuthorizeByPermission("GeneralSetting", Operation.Show)]

        //[AuthorizeByPermission("GeneralSetting", Operation.Update)]

        public async Task<IActionResult> Save(SettingViewModel vm)
        {

            if (ModelState.IsValid)
            {
               
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
