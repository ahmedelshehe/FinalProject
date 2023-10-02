using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    //[Authorize]
    //[Route("vacation")]
    public class VacationController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        private readonly UserManager<AppUser> userManager;
        public IVacationRepository VacationRepository { get; set; }
        public VacationController(UserManager<AppUser> userManager, IVacationRepository vacationRepository, IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
            VacationRepository = vacationRepository;
            this.userManager = userManager;

        }

        [HttpGet]
        //This Action to get all Vacations of all users for admin
        public  IActionResult Index()
        {
            return View(VacationRepository.GetVacations());
        }
        [HttpGet]
        //This Action to get all Vacations of login user for user

        public async Task<IActionResult> MyVacations()
        {
            
            var user = await userManager.GetUserAsync(User);

            var vacations = VacationRepository.GetVacations().Where(v => v.EmployeeId == user.EmpId).ToList();
            ViewBag.AvailableVacations = user.Employee.AvailableVacations;
            return View(vacations);
        }




        [HttpGet]
        public ActionResult Details(int id, DateTime date)
        {
            return View(VacationRepository.GetVacation(id, date));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vacation vacation)
        {
            

            if (!ModelState.IsValid)
            {
                return View(vacation);
            }

            var user = await userManager.GetUserAsync(User);

            var employee = EmployeeRepository.GetEmployee(user.EmpId);
            if (employee == null)
            {
                return RedirectToAction("Login", "Account");
            }


            vacation.Employee = employee;

            VacationRepository.InsertVacation(vacation);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id, DateTime date)
        {
            return View(VacationRepository.GetVacation(id,date));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vacation vacation, DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return View(vacation);
            }

            VacationRepository.UpdateVacation(id, vacation ,date);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int id, DateTime date)
        {
            return View(VacationRepository.GetVacation(id, date));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            VacationRepository.DeleteVacation(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Approve(int id, DateTime date)
        {
            var vacation = VacationRepository.GetVacation(id, date);

            var user = await userManager.GetUserAsync(User);
            var employee = EmployeeRepository.GetEmployee(user.EmpId);

            if (employee.AvailableVacations == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            vacation.Status = VacationStatus.Approved;
            VacationRepository.UpdateVacation(id, vacation, date);

            employee.AvailableVacations  -= vacation.VacationDays;
            EmployeeRepository.UpdateEmployee(id, employee);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Reject(int id, DateTime date)
        {
            var vacation = VacationRepository.GetVacation(id, date);

            var employee = EmployeeRepository.GetEmployee(vacation.EmployeeId);

            vacation.Status = VacationStatus.Rejected;
            VacationRepository.UpdateVacation(id, vacation, date);

            return RedirectToAction(nameof(Index));
        }
    }
}
