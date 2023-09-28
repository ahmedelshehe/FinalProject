using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IUserRepository userRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAppRoleRepository appRoleRepository;

        public AppUserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager, IUserRepository userRepository,IEmployeeRepository _employeeRepository, IAppRoleRepository roleRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            employeeRepository = _employeeRepository;
            appRoleRepository = roleRepository;
            this.roleManager = roleManager;

        }

        // GET: AppUserController
        public  IActionResult Index()
        {
            var users = userRepository.GetUsers();
            return View(users);
        }

        // GET: AppUserController/Details/5
        public IActionResult Details(int id)
        {
            var user =  userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            var roleName = user.Role != null ? user.Role.Name : "";

            ViewData["RoleName"] = roleName;

            return View(user);
        }




        public IActionResult Create()
        {
            var allEmps = employeeRepository.GetEmployees().Where(e => e.UserId == null).ToList();
            ViewBag.Emps = allEmps;
            var allRolesOfUser = appRoleRepository.getAllRoles().ToList();
            ViewBag.AllRules = allRolesOfUser;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,Password,EmpId,RoleAppId")] AppUser user)
        {
            if (ModelState.IsValid)
            {
                var allEmps = employeeRepository.GetEmployees().Where(e => e.UserId == null).ToList();
                ViewBag.Emps = allEmps;
                var allRolesOfUser = appRoleRepository.getAllRoles().ToList();
                ViewBag.AllRules = allRolesOfUser;
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
            var allRolesOfUser = appRoleRepository.getAllRoles().ToList();
            ViewBag.AllRules = allRolesOfUser;
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
        public async Task<IActionResult> Edit(int id, [Bind("AppId,UserName,Email","RoleAppId")] AppUser user)
        {

            var allRolesOfUser = appRoleRepository.getAllRoles().ToList();
            ViewBag.AllRules = allRolesOfUser;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Delete(int Id, IFormCollection collection)
        {
            var user = userRepository.GetUser(Id);
            if(user != null)
            {
                await userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
