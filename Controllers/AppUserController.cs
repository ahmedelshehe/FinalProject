using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IUserRepository userRepository;
        private readonly IEmployeeRepository employeeRepository;

        public AppUserController(UserManager<AppUser> userManager, IUserRepository userRepository,IEmployeeRepository _employeeRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            employeeRepository = _employeeRepository;
        }

        // GET: AppUserController
        public  IActionResult Index()
        {
            var users = userRepository.GetUsers();
            return View(users);
        }

        // GET: AppUserController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: AppUserController/Create


        public IActionResult Create()
        {
            var allEmps = employeeRepository.GetEmployees().Where(e => e.UserId == null).ToList();
            ViewBag.Emps = allEmps;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,Password,EmpId")] AppUser user)
        {
            if (ModelState.IsValid)
            {
                var allEmps = employeeRepository.GetEmployees().Where(e => e.UserId == null).ToList();
                ViewBag.Emps = allEmps;
                var createUserResult = await userManager.CreateAsync(user);
                if (createUserResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in createUserResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(user);
        }
    
    public async Task<IActionResult> Edit(int id)
        {
            var user = userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: AppUserController/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppId,UserName,Email")] AppUser user)
        {
            if (id != user.AppId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                userRepository.UpdateUser(id, user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: AppUserController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: AppUserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
