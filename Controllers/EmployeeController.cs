using FinalProject.Data;
using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Controllers
{
	public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        private readonly IUserRepository userRepository;

        public EmployeeController(IUserRepository UserRepository,IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, UserManager<AppUser> userManager)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
            this.userManager = userManager;
            userRepository = UserRepository;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var employees = EmployeeRepository.GetEmployees();

            List<EmployeeViewModel> employeeViews = new List<EmployeeViewModel>();
            
            SelectList allDepartment = new SelectList(DepartmentRepository.GetDepartments(), "Id", "Name");
            ViewBag.allDepts = allDepartment;
            foreach (var emp in employees)
            {
                var isExits = userRepository.GetUsers().FirstOrDefault(u => u.EmpId == emp.Id);
                if (isExits != null)
                {
                    employeeViews.Add(new EmployeeViewModel() { employee = emp, isUserAdded = true });

                }
                else
                {
                    employeeViews.Add(new EmployeeViewModel() { employee = emp, isUserAdded = false });

                }
            }
            return View(employeeViews);

        }

		// GET: EmployeeController/Details/5
		[AuthorizeByPermission("Employee", Operation.Show)]
		public ActionResult Details(int id)
        {
            return View(EmployeeRepository.GetEmployee(id));
        }

		// GET: EmployeeController/Create
		[AuthorizeByPermission("Employee", Operation.Add)]
		public ActionResult Create()
        {
            ViewBag.allDepts = DepartmentRepository.GetDepartments();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[AuthorizeByPermission("Employee", Operation.Add)]
		public ActionResult Create(Employee employee)
        {
            ViewBag.allDepts = DepartmentRepository.GetDepartments();
            if (ModelState.IsValid)
            {
                try
                {

                    EmployeeRepository.InsertEmployee(employee);
                    return RedirectToAction("Index");

                }
                catch
                {
                    return View(employee);
                }
            }
            else
            {
				return View(employee);
			}
		}

		// GET: EmployeeController/Edit/5
		[AuthorizeByPermission("Employee", Operation.Update)]
		public ActionResult Edit(int id)
        {
            ViewBag.allDepts = DepartmentRepository.GetDepartments();
            return View(EmployeeRepository.GetEmployee(id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		[AuthorizeByPermission("Employee", Operation.Update)]
		public ActionResult Edit(int id, Employee employee)
        {
            ViewBag.allDepts = DepartmentRepository.GetDepartments();

                try
                {
                    EmployeeRepository.UpdateEmployee(id, employee);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(employee);
                }
        }

		// GET: EmployeeController/Delete/5
		[AuthorizeByPermission("Employee", Operation.Delete)]
		public ActionResult Delete(int id)
        {
            return View(EmployeeRepository.GetEmployee(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
		[AuthorizeByPermission("Employee", Operation.Delete)]
		public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EmployeeRepository.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
