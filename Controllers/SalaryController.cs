using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using FinalProject.Helper;
using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using FinalProject.ViewModels;
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
        [HttpGet]
        public async Task<IActionResult> YearlyReportSalary(int? page)
        {
            int pageSize = 30;
            int pageNumber = page ?? 1;
            List<int> years = new List<int>();
            var empList = new List<Employee>();
            empList = employeeRepository.GetEmployees().ToList();
            ViewBag.Employees = empList.Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();

            var startYear = 2015;
            while (DateTime.Now.Year >= startYear)
            {
                years.Add(startYear);
                startYear++;
            }
            ViewBag.Year = years;
            //   return View();
            var listt = new List<SalaryViewModel>();
            return View(await listt.ToPagedListAsync(pageNumber, pageSize));

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> YearlyReportSalary(int? empId, int year, int? page)
        {
            int pageSize = 30;
            int pageNumber = page ?? 1;
            List<SalaryViewModel> list = null;
            string alertMessage = null;
            var empList = new List<Employee>();
            List<int> years = new List<int>();
            List<int> months = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var startYear = 2015;
            while (DateTime.Now.Year >= startYear)
            {
                years.Add(startYear);
                startYear++;
            }
            var user = await userManager.GetUserAsync(User);
            var userAppRole = appRoleRepository.GetAppRoleWithPermissions(user.RoleAppId);

            ViewBag.Year = years;



            if (userAppRole != null)
            {
                if (userAppRole.Permissions.Any(p => p.Name == "Salary"))
                {
                    empList = employeeRepository.GetEmployees().ToList();
                    ViewBag.Employees = empList.Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();


                 
                    if (empId == null )
                    {
                         (list, alertMessage) = salaryService.getDataPerYear(year);
                        ViewBag.AlertMessage = alertMessage;
                        //return View(await list.ToPagedListAsync(pageNumber, pageSize));

                    }
                    else
                    {

                         list = salaryService.getDataPerYear(year).result.Where(w => w.empId == empId).ToList();
                        //return View(await list.ToPagedListAsync(pageNumber, pageSize));
                    }
                }
                else
                {
                    var emp = employeeRepository.GetEmployee(user.EmpId);
                    empId = emp.Id;
                    ViewBag.Employees = empList.Where(w => w.Id == empId).Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();

                    
                    if (empId != null )
                    {

                         list = salaryService.getDataPerYear(year).result.Where(w => w.empId == empId).ToList();
                        //return View(await list.ToPagedListAsync(pageNumber, pageSize));
                    }
                }
            }
            else
            {
                var emp = employeeRepository.GetEmployee(user.EmpId);
                empId = emp.Id;
                ViewBag.Employees = empList.Where(w => w.Id == empId).Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();

               
                if (empId != null )
                {

                    list = salaryService.getDataPerYear(year).result.Where(w => w.empId == empId).ToList();
                    //return View(await list.ToPagedListAsync(pageNumber, pageSize));
                }
            }
            //var listt = new List<SalaryViewModel>();
            //return View(await listt.ToPagedListAsync(pageNumber, pageSize));
            return View(await list.ToPagedListAsync(pageNumber, pageSize));



        }

        [Authorize]
        public async Task<IActionResult> Index(int? empId, int year, int month, int? page)
        {
            int pageSize = 30;
            int pageNumber = page ?? 1;
            List<SalaryViewModel> list = null;
            string alertMessage = null;
            var empList = new List<Employee>();
            List<int> years = new List<int>();
            List<int> months = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
          
            var startYear = 2015;
            while (DateTime.Now.Year >= startYear)
            {
                years.Add(startYear);
                startYear++;
            }



            var user = await userManager.GetUserAsync(User);
            var userAppRole = appRoleRepository.GetAppRoleWithPermissions(user.RoleAppId);

            ViewBag.Year = years;
            ViewBag.Months = months;

          

            if (userAppRole != null)
            {
                if (userAppRole.Permissions.Any(p => p.Name == "Salary"))
                {
                    empList = employeeRepository.GetEmployees().ToList();
                    ViewBag.Employees = empList.Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();


                    if (empId == null )
                    {
                         (list, alertMessage) = salaryService.getDataPerMonth(year, month);
                        ViewBag.AlertMessage = alertMessage;
                        //return View(await list.ToPagedListAsync(pageNumber, pageSize));

                    }
                    
                    else 
                    {
                         list = salaryService.getDataPerMonth(year, month).result.Where(w => w.empId == empId).ToList();
                        //return View(await list.ToPagedListAsync(pageNumber, pageSize));
                    }
                    
                }
                else
                {
                    var emp = employeeRepository.GetEmployee(user.EmpId);
                    empId = emp.Id;
                    ViewBag.Employees = empList.Where(w => w.Id == empId).Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();

                    if (empId != null )
                    {
                         list = salaryService.getDataPerMonth(year, month).result.Where(w => w.empId == empId).ToList();
                        //return View(await list.ToPagedListAsync(pageNumber, pageSize));
                    }
                    
                }
            }
            else
            {
                var emp = employeeRepository.GetEmployee(user.EmpId);
                empId = emp.Id;
                ViewBag.Employees = empList.Where(w => w.Id == empId).Select(w => new { Id = w.Id, Name = $"{w.FirstName} {w.LastName}" }).ToList();

                if (empId != null)
                {
                     list = salaryService.getDataPerMonth(year, month).result.Where(w => w.empId == empId).ToList();
                    //return View(await list.ToPagedListAsync(pageNumber, pageSize));
                }
               
            }
            //var listt = new List<SalaryViewModel>();
            //return View(await listt.ToPagedListAsync(pageNumber, pageSize));
            return View(await list.ToPagedListAsync(pageNumber, pageSize));

        }

    }
}

















