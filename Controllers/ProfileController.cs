using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IEmployeeRepository employeeRepository;

		public ProfileController(UserManager<AppUser> userManager, IEmployeeRepository employeeRepository , IDepartmentRepository departmentRepository)
		{
			this.userManager = userManager;
			this.employeeRepository = employeeRepository;
			DepartmentRepository = departmentRepository;
		}

		public IDepartmentRepository DepartmentRepository { get; }

		public async Task<IActionResult> Index()
		{
			ViewBag.allDepts = DepartmentRepository.GetDepartments();
			var user = await userManager.GetUserAsync(User);
			var employee = employeeRepository.GetEmployee(user.EmpId);

			return View(employee);
		}
	}
}
