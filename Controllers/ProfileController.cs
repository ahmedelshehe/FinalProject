using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Helper;
using FinalProject.ViewModels;
using Newtonsoft.Json;
using Rotativa;
using Rotativa.AspNetCore;

namespace FinalProject.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IEmployeeRepository employeeRepository;
		private readonly IAttendanceRepositoryService attendanceRepository;
		private readonly IVacationRepository vacationRepository;
		public IDepartmentRepository DepartmentRepository { get; }
		public ProfileController(UserManager<AppUser> userManager, IEmployeeRepository employeeRepository ,
			IDepartmentRepository departmentRepository, IAttendanceRepositoryService AttendanceRepository, IVacationRepository vacationRepository)
		{
			this.userManager = userManager;
			this.employeeRepository = employeeRepository;
			DepartmentRepository = departmentRepository;
			attendanceRepository = AttendanceRepository;
			this.vacationRepository = vacationRepository;
		}


		public async Task<IActionResult> Index()
		{
			ViewBag.allDepts = DepartmentRepository.GetDepartments();
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);

			return View(employee);
		}

		public async Task<IActionResult> Dashboard()
		{
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);
			var EmployeeAttendances =  attendanceRepository.GetAttendances().Where(a =>a.EmployeeId == employee.Id).ToList();

			EmployeeDashboardVM vM = new EmployeeDashboardVM(EmployeeAttendances, employee, vacationRepository);
			return View(vM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public  IActionResult RequestVacation(Vacation vacation)
		{
			if(ModelState.IsValid)
			{
				vacationRepository.InsertVacation(vacation);

			}
			return RedirectToAction(nameof(Dashboard));


		}

		public async Task<IActionResult> AttendanceSummary()
		{
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);
			var EmployeeAttendances = attendanceRepository.GetAttendances().Where(a => a.EmployeeId == employee.Id).ToList();

			EmployeeDashboardVM vM = new (EmployeeAttendances, employee, vacationRepository);
			return View(vM);

		}
		public async Task<IActionResult> PrintAttendanceSummary()
		{
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);
			var EmployeeAttendances = attendanceRepository.GetAttendances().Where(a => a.EmployeeId == employee.Id).ToList();

			EmployeeDashboardVM vM = new (EmployeeAttendances, employee, vacationRepository);
			return new ViewAsPdf("AttendanceSummary",vM);
		}
	}
	}

