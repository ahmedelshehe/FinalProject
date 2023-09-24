using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            return View(DepartmentRepository.GetDepartments());
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var department = DepartmentRepository.GetDepartment(id);
            ViewBag.AllEmployees = department.Employees;
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentRepository.InsertDepartment(department);
                return RedirectToAction(nameof(Index));
            }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DepartmentRepository.GetDepartment(id));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentRepository.UpdateDepartment(id, department);
                return RedirectToAction(nameof(Index));
            }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(DepartmentRepository.GetDepartment(id));
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                DepartmentRepository.DeleteDepartment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
