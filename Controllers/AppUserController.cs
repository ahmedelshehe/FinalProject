using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using FinalProject.Utilities;


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

        public IActionResult Index()
        {
			var users = userRepository.GetUsers();
            return View(users);
        }

        // GET: AppUserController/Details/5
        [AuthorizeByPermission("AppUser", Operation.Show)]

        public IActionResult Details(string id)
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



        [AuthorizeByPermission("AppUser", Operation.Add)]

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
      [AuthorizeByPermission("AppUser", Operation.Add)]

        public async Task<IActionResult> Create([Bind("UserName,Email,EmpId,RoleAppId")] AppUser user,string NewPassword)
        {
            if (ModelState.IsValid)
            {  var hasher = new PasswordHasher<AppUser>();
                var allEmps = employeeRepository.GetEmployees().Where(e => e.UserId == null).ToList();
                ViewBag.Emps = allEmps;
                var allRolesOfUser = appRoleRepository.getAllRoles().ToList();
                ViewBag.AllRules = allRolesOfUser;
                var hashedPassword = hasher.HashPassword(null, NewPassword); 
                user.PasswordHash = hashedPassword;
                var createUserResult = await userManager.CreateAsync(user);

                if (createUserResult.Succeeded)
                {
                    var updatedEmp = employeeRepository.GetEmployee(user.EmpId);
                    updatedEmp.Email = user.Email;
                    updatedEmp.Password = hashedPassword;
                    employeeRepository.UpdateEmployee(user.EmpId, updatedEmp);
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
        [AuthorizeByPermission("AppUser", Operation.Update)]

        public async Task<IActionResult> Edit(string id)

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
        [AuthorizeByPermission("AppUser", Operation.Update)]

        public async Task<IActionResult> Edit(string id, [Bind("AppId,UserName,Email","RoleAppId")] AppUser user)
        {

            var allRolesOfUser = appRoleRepository.getAllRoles().ToList();
            ViewBag.AllRules = allRolesOfUser;
            if (ModelState.IsValid)
            {
                userRepository.UpdateUser(id, user);
                return RedirectToAction("Index");
            }

            return View(user);
        }
        [AuthorizeByPermission("AppUser", Operation.Delete)]

        // GET: AppUserController/Delete/5
        public async Task<IActionResult> Delete(string id)
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
        [AuthorizeByPermission("AppUser", Operation.Delete)]

        public async  Task<IActionResult> Delete(string Id, IFormCollection collection)
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
