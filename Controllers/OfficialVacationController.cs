using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
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
        public ActionResult Details(int id)
        {
            return View(officialVacationRepository.GetOfficialVacation(id));
        }

        // GET: OfficialVacationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficialVacationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficialVacation officalVacation)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    officialVacationRepository.InsertOfficialVacation(officalVacation);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfficialVacationController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(officialVacationRepository.GetOfficialVacation(id));
        }

        // POST: OfficialVacationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OfficialVacation officalVacation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    officialVacationRepository.UpdateOfficialVacation(id,officalVacation);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfficialVacationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(officialVacationRepository.GetOfficialVacation(id));
        }

        // POST: OfficialVacationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
