using FinalProject.Helper;
using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.WebPages;

namespace FinalProject.Controllers
{
    [Authorize]
    public class VacationController : Controller
    {
        private readonly IEmployeeRepository EmployeeRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly IVacationRepository VacationRepository;
        private readonly IOfficialVacationRepository officialVacationRepository;
        private readonly IWeeklyHolidayRepository weeklyHolidayRepository;


        public VacationController(UserManager<AppUser> userManager, IVacationRepository vacationRepository, IEmployeeRepository employeeRepository,
            IOfficialVacationRepository officialVacationRepository,IWeeklyHolidayRepository weeklyHolidayRepository
            )
        {
            EmployeeRepository = employeeRepository;
            VacationRepository = vacationRepository;
            this.userManager = userManager;
            this.officialVacationRepository = officialVacationRepository;
            this.weeklyHolidayRepository = weeklyHolidayRepository;

        }

        [HttpGet]

        [AuthorizeByEntity("Vacation")]
        public IActionResult Index()
        {
            return View(VacationRepository.GetVacations());
        }
        [HttpGet]
        public async Task<IActionResult> MyVacations()
        {

            var user = await userManager.GetUserAsync(User);
            var emp = EmployeeRepository.GetEmployee(user.EmpId);
            var vacations = VacationRepository.GetVacations().Where(v => v.EmployeeId == user.EmpId).ToList();
            ViewBag.AvailableVacations = emp.AvailableVacations;
            return View(vacations);
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

            if (vacation.StartDate > vacation.EndDate)
            {
                ModelState.AddModelError(nameof(vacation.StartDate), "Start date must be earlier than the end date.");
                return View(vacation);
            }
            var officialHolidays = officialVacationRepository
                            .GetOfficialVacations()
                            .Where(o => o.Date.Year == vacation.StartDate.Year 
                            || o.Date.Year == vacation.StartDate.AddYears(1).Year).Select(o => o.Date).ToList();
            var weeklyHoildays = weeklyHolidayRepository.GetAllHolidays().Select(w => w.Holiday).ToList();
            int numberOfDays = HelperShared
                .GetWorkDays(vacation.StartDate, vacation.EndDate, weeklyHoildays, officialHolidays);

			if (numberOfDays <= 0)
            {
                ModelState.AddModelError(string.Empty, "The vacation duration must be at least 1 day.");
                return View(vacation);
            }
            
            if (numberOfDays > employee.AvailableVacations)
            {
                ModelState.AddModelError(string.Empty, "You do not have enough available vacations for this request.");
                return View(vacation);
            }
            var isUnique = VacationRepository.GetVacation(user.EmpId,vacation.StartDate);
            if(isUnique != null)
            {
				ModelState.AddModelError(nameof(vacation.StartDate), "You have requested With the same start date before");
				return View(vacation);
			}
            VacationRepository.InsertVacation(vacation);
            return RedirectToAction("MyVacations");
        }




        [AuthorizeByPermission("Vacation", Operation.Update)]
        public async Task<IActionResult> Approve(int id, DateTime date)
        {
            var vacation = VacationRepository.GetVacation(id, date);

            var employee = EmployeeRepository.GetEmployee(id);

            
            var numOfDays = VacationRepository.GetVacationDays(id, date);
            if (employee.AvailableVacations < numOfDays)
            {
                return RedirectToAction(nameof(Index));
            }
			vacation.Status = VacationStatus.Approved;
            VacationRepository.UpdateVacation(id, date, vacation);
            employee.AvailableVacations -= numOfDays;
            EmployeeRepository.UpdateEmployee(id, employee);

            return RedirectToAction(nameof(Index));
        }

        [AuthorizeByPermission("Vacation", Operation.Update)]
        public async Task<IActionResult> Reject(int id, DateTime date)
        {
            var vacation = VacationRepository.GetVacation(id, date);

            var employee = EmployeeRepository.GetEmployee(vacation.EmployeeId);

            vacation.Status = VacationStatus.Rejected;
            VacationRepository.UpdateVacation(id, date, vacation);

            return RedirectToAction(nameof(Index));
        }
    }
}
