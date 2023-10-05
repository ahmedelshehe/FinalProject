using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Helper;
using FinalProject.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
	[Authorize]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IEmployeeRepository employeeRepository;
		private readonly IAttendanceRepositoryService attendanceRepository;
		private readonly IVacationRepository vacationRepository;
		private readonly IOfficialVacationRepository officialVacationRepository;
		private readonly IDepartmentRepository DepartmentRepository;
		public ProfileController(UserManager<AppUser> userManager, IEmployeeRepository employeeRepository ,
			IDepartmentRepository departmentRepository, 
			IAttendanceRepositoryService AttendanceRepository, IVacationRepository vacationRepository,
			IOfficialVacationRepository officialVacationRepository
			)
		{
			this.userManager = userManager;
			this.employeeRepository = employeeRepository;
			DepartmentRepository = departmentRepository;
			attendanceRepository = AttendanceRepository;
			this.vacationRepository = vacationRepository;
			this.officialVacationRepository = officialVacationRepository;
		}
        [Authorize]
        public async Task<IActionResult> Index()
		{
			ViewBag.allDepts = DepartmentRepository.GetDepartments();
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);

			return View(employee);
		}
		public async Task<IActionResult> Edit()
		{
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);

			return View(employee);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Employee employee)
		{
			if (ModelState.IsValid)
			{
				var validationResults = new List<ValidationResult>();
				var isValid = Validator.TryValidateObject(employee, new ValidationContext(employee), validationResults, true);
				if (isValid)
				{
					employeeRepository.UpdateEmployee(id, employee);
					return RedirectToAction(nameof(Index));
				}
				else
				{
					foreach (var validationResult in validationResults)
					{
						foreach (var memberName in validationResult.MemberNames)
						{
							ModelState.AddModelError(memberName, validationResult.ErrorMessage);
						}
					}
				}
			}

			return View(employee);
		}


        [Authorize]
        public async Task<IActionResult> Dashboard()
		{
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);
			var EmployeeAttendances =  attendanceRepository.GetAttendances().Where(a =>a.EmployeeId == employee.Id).ToList();

			EmployeeDashboardVM vM = new EmployeeDashboardVM(EmployeeAttendances, employee, vacationRepository,officialVacationRepository.GetOfficialVacations());
			return View(vM);
		}

        [Authorize]
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RequestVacation(Vacation vacation)
		{
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);
			if (ModelState.IsValid)
			{
				if (vacation.StartDate > vacation.EndDate)
				{
					ModelState.AddModelError(nameof(vacation.StartDate), "Start date must be earlier than the end date.");
					return RedirectToAction(nameof(Dashboard));
				}

				TimeSpan duration = (TimeSpan)(vacation.EndDate - vacation.StartDate);
				int numberOfDays = (int)duration.TotalDays + 1;

				if (numberOfDays <= 0)
				{
					ModelState.AddModelError(string.Empty, "The vacation duration must be at least 1 day.");
					return RedirectToAction(nameof(Dashboard));
				}

				if (numberOfDays > employee.AvailableVacations)
				{
					ModelState.AddModelError(string.Empty, "You do not have enough available vacations for this request.");
					return RedirectToAction(nameof(Dashboard));
				}
				vacationRepository.InsertVacation(vacation);

			}
			return RedirectToAction(nameof(Dashboard));


		}

        [Authorize]
        public async Task<IActionResult> AdminDashboard()
		{
			if (HttpContext.Items["Permissions"] != null)
			{
				var user = await userManager.GetUserAsync(User);
				var employee = employeeRepository.GetEmployee(user.EmpId);
				var employees = employeeRepository.GetEmployees();
				var departments = DepartmentRepository.GetDepartments();
				var vacations = vacationRepository.GetVacations();
				var thisMonthAttendance = attendanceRepository.GetAttendances().Where(a => a.Date.Month == DateTime.Today.Month).ToList();
				var lastMonthAttendance = attendanceRepository.GetAttendances().Where(a => a.Date.Month == DateTime.Today.AddMonths(-1).Month).ToList();
				var officialVacations = officialVacationRepository.GetOfficialVacations();
				AdminDashboardVM vM = new AdminDashboardVM(employee,employees, departments,vacations,thisMonthAttendance,lastMonthAttendance,officialVacations);
				return View(vM);
			}
			else
			{
				return Unauthorized();

			}

		}
    }
}

