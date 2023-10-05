using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using X.PagedList;

namespace FinalProject.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalaryService salaryService;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAppRoleRepository appRoleRepository;
        private readonly UserManager<AppUser> userManager;

        public SalaryController(ISalaryService salaryService, IEmployeeRepository employeeRepository,
            IAppRoleRepository appRoleRepository, UserManager<AppUser> userManager)
        {
            this.salaryService = salaryService;
            this.employeeRepository = employeeRepository;
            this.appRoleRepository = appRoleRepository;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? empId, int? year, int? month, int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var user = await userManager.GetUserAsync(User);
            var userAppRole = appRoleRepository.GetAppRoleWithPermissions(user.RoleAppId);
            var empList = new List<Employee>();
            List<int> years = new List<int>();
            List<int> months = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            ViewBag.Year = years;
            ViewBag.Months = months;

            var startYear = 2010;

            if (userAppRole != null)
            {
                if (userAppRole.Permissions.Any(p => p.Name == "Salary"))
                {
                    empList = employeeRepository.GetEmployees().ToList();
                    ViewBag.Employees = empList.Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();

                    while (DateTime.Now.Year >= startYear)
                    {
                        years.Add(startYear);
                        startYear++;
                    }

                    if (empId == null)
                    {
                        var list = salaryService.GetData(year, month);
                        return View(await list.ToPagedListAsync(pageNumber, pageSize));
                    }
                    else
                    {
                        var list = salaryService.GetData(year, month).Where(w => w.empId == empId).ToList();
                        return View(await list.ToPagedListAsync(pageNumber, pageSize));
                    }
                }
                else
                {
                    var emp = employeeRepository.GetEmployee(user.EmpId);
                    empId = emp.Id;
                }
            }
            else
            {
                var emp = employeeRepository.GetEmployee(user.EmpId);
                empId = emp.Id;
            }

            ViewBag.Employees = empList.Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();

            while (DateTime.Now.Year >= startYear)
            {
                years.Add(startYear);
                startYear++;
            }

            if (empId == null)
            {
                var list = salaryService.GetData(year, month);
                return View(await list.ToPagedListAsync(pageNumber, pageSize));
            }
            else
            {
                var list = salaryService.GetData(year, month).Where(w => w.empId == empId).ToList();
                return View(await list.ToPagedListAsync(pageNumber, pageSize));
            }
        }
    }
}
