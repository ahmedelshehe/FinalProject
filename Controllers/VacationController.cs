using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
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

		[AuthorizeByPermission("Vacation", Operation.Add)]
		[AuthorizeByPermission("Vacation", Operation.Update)]

		public IActionResult Index()
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
		[AuthorizeByPermission("Vacation", Operation.Add)]
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

            TimeSpan duration = (TimeSpan)(vacation.EndDate - vacation.StartDate);
            int numberOfDays = (int)duration.TotalDays;

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

            VacationRepository.InsertVacation(vacation);

            return RedirectToAction("MyVacations");
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

            TimeSpan duration = (TimeSpan)(vacation.EndDate - vacation.StartDate);
            int numberOfDays = (int)duration.TotalDays;

            employee.AvailableVacations -= numberOfDays;
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
