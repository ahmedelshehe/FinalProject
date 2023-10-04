using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class SalaryController : Controller
    {
        ISalaryService ob;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAppRoleRepository appRoleRepository;
        private readonly UserManager<AppUser> userManager;

        public SalaryController(ISalaryService o, IEmployeeRepository _employeeRepository
            , IAppRoleRepository appRoleRepository, UserManager<AppUser> userManager)
        {
            ob = o;
            employeeRepository = _employeeRepository;
            this.appRoleRepository = appRoleRepository;
            this.userManager = userManager;

        }
        /*        [AuthorizeByPermission("Salary", Operation.Show)]
         *        
        */
        [Authorize]
        public async Task<IActionResult> Index(int? empId, int? year, int? month)
        {
            var user = await userManager.GetUserAsync(User);
            var userAppRole = appRoleRepository.GetAppRoleWithPermissions(user.RoleAppId);
            var EmpList = new List<Employee>();
            List<int> Years = new List<int>();
            List<int> months = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            ViewBag.Year = Years;
            ViewBag.months = months;
            var startyear = 2010;
            if (userAppRole != null)
            {
                if (userAppRole.Permissions.Any(p => p.Name == "Salary"))
                {
                    EmpList = employeeRepository.GetEmployees();
                    ViewBag.Employees = EmpList.Select(w => new { Id = w.Id, Name = w.FirstName + ' ' + w.LastName }).ToList();
                    while (DateTime.Now.Year >= startyear)
                    {
                        Years.Add(startyear);
                        startyear++;
                    }


                    if (empId == null)
                    {
                        var list = ob.GetData(year, month);
                        return View(list);
                    }
                    else
                    {
                        var list = ob.GetData(year, month).Where(w => w.empId == empId).ToList();

                        return View(list);
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
            ViewBag.Employees = EmpList.Select(w => new { Id = w.Id, Name = w.FirstName + ' ' + w.LastName }).ToList();

            while (DateTime.Now.Year >= startyear)
            {
                Years.Add(startyear);
                startyear++;
            }


            if (empId == null)
            {
                var list = ob.GetData(year, month);
                return View(list);
            }
            else
            {
                var list = ob.GetData(year, month).Where(w => w.empId == empId).ToList();

                return View(list);
            }
        }
    }
}

