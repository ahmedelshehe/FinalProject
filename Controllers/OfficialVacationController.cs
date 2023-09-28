using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Utilities;

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
        [AuthorizeByPermission("OfficialVacation", Operation.Update)]

        public ActionResult Edit(int id)
        {

            return View(officialVacationRepository.GetOfficialVacation(id));
        }

        // POST: OfficialVacationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("OfficialVacation", Operation.Update)]

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
