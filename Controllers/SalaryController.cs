using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class SalaryController : Controller
    {
        ISalaryService ob;
        private readonly IEmployeeRepository employeeRepository;
        public SalaryController(ISalaryService o, IEmployeeRepository _employeeRepository)
        {
            ob = o;
            employeeRepository = _employeeRepository;

        }
        [AuthorizeByPermission("Salary", Operation.Show)]
        public IActionResult Index(int? empId, int? year, int? month)
        {

            var EmpList = employeeRepository.GetEmployees();
            ViewBag.Employees = EmpList.Select(w => new { Id = w.Id, Name = w.FirstName + ' ' + w.LastName }).ToList();
            List<int> months = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            ViewBag.months = months;
            List<int> Years = new List<int>();

            var startyear = 2010;
            while (DateTime.Now.Year >= startyear)
            {
                Years.Add(startyear);
                startyear++;
            }
            ViewBag.Year = Years;


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
