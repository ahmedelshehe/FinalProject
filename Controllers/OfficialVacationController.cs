using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using FinalProject.ViewModels;

namespace FinalProject.Controllers
{
    [Authorize]
    public class OfficialVacationController : Controller
    {
        private readonly IOfficialVacationRepository officialVacationRepository;

        public OfficialVacationController(IOfficialVacationRepository OfficialVacationRepository)
        {
            officialVacationRepository = OfficialVacationRepository;
        }

        public ActionResult Index()
        {
            return View(officialVacationRepository.GetOfficialVacations());
        }

        // GET: OfficialVacationController/Details/5
        [AuthorizeByPermission("OfficialVacation", Operation.Show)]
        public ActionResult Details(int id)
        {
            return View(officialVacationRepository.GetOfficialVacation(id));
        }

        // GET: OfficialVacationController/Create
        [AuthorizeByPermission("OfficialVacation", Operation.Add)]
        public ActionResult Create()
        {
            return View();
        }


        // POST: OfficialVacationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("OfficialVacation", Operation.Add)]
        public ActionResult Create(OfficialVacationViewModel officalVacation)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var existingVacation = officialVacationRepository.GetOfficialVacations().FirstOrDefault(v => v.Date == officalVacation.Date);

                    if (existingVacation != null)
                    {

                        ModelState.AddModelError("Date", "this date already exists ");
                    }

                    else
                    {
                        // Create a new vacation
                        var newVacation = new OfficialVacationViewModel
                        {
                            Name = officalVacation.Name,
                            Date = officalVacation.Date
                        };
                        officialVacationRepository.InsertOfficialVacation(newVacation);

                    }

                }
                officalVacation.offvac = officialVacationRepository.GetOfficialVacations();
                return RedirectToAction(nameof(Index), officalVacation);
            }
            catch
            {
                return View();
            }
        }


        // GET: OfficialVacationController/Edit/5
        [AuthorizeByPermission("OfficialVacation", Operation.Update)]
        public ActionResult Edit(int id)
        {
            OfficialVacation editvac = officialVacationRepository.GetOfficialVacation(id);

            var Vacationvm = new OfficialVacationViewModel()
            {
                Date = editvac.Date,
                Name = editvac.Title

            };
            return View(Vacationvm);

        }




        // POST: OfficialVacationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("OfficialVacation", Operation.Update)]
        public ActionResult Edit(int id, OfficialVacationViewModel evac)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var existingVacation = officialVacationRepository.GetOfficialVacations().FirstOrDefault(v => v.Date == evac.Date);

                    officialVacationRepository.UpdateOfficialVacation(id, evac);
                    return RedirectToAction(nameof(Index));


                    //if (existingVacation != null)
                    //{
                    //    // Vacation with the same date already exists, return an error message
                    //    ModelState.AddModelError("Date", "date already exists");
                    //}
                    //else
                    //{
                    //    officialVacationRepository.UpdateOfficialVacation(id, evac);
                    //    return RedirectToAction(nameof(Index));

                    //}
                }
                return View(evac);
            }
            catch
            {
                return View();
            }
        }



        // GET: OfficialVacationController/Delete/5
        [AuthorizeByPermission("OfficialVacation", Operation.Delete)]
        public ActionResult Delete(int id)

        {
            return View(officialVacationRepository.GetOfficialVacation(id));
        }

        // POST: OfficialVacationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("OfficialVacation", Operation.Delete)]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                officialVacationRepository.DeleteOfficialVacation(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(officialVacationRepository.GetOfficialVacation(id));
            }
        }
    }
}
