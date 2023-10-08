using Microsoft.AspNetCore.Identity;

namespace FinalProject.Controllers
{
    using FinalProject.Models;
    using FinalProject.RepoServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using FinalProject.Utilities;
	using Microsoft.AspNetCore.Authorization;

	[Authorize]
    public class AppRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IPermissionRepository permissionRepository;
        private readonly IAppRoleRepository appRoleRepository;
        public AppRoleController(RoleManager<AppRole> roleManager,IPermissionRepository repository ,IAppRoleRepository roleRepository)
        {
            permissionRepository = repository;
            _roleManager = roleManager;
            appRoleRepository = roleRepository;
        }

        // GET: AppRoleController/Index

        [AuthorizeByEntity("AppRole")]
        public ActionResult Index()
        {
            // Display a list of all roles
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        // GET: AppRoleController/Details/5
       [AuthorizeByPermission("AppRole", Operation.Show)]
        public ActionResult Details(string id)
        {
            var role = appRoleRepository.GetAppRoleWithPermissions(id);
            ViewBag.permissions = permissionRepository.GetPermissions();
            // Display details of a specific role
            return View(role);
        }

        // GET: AppRoleController/Create
        [AuthorizeByPermission("AppRole", Operation.Add)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppRoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("AppRole", Operation.Add)]
        public async Task<IActionResult> Create(string name)
        {
            // Create a new role
            var role = new AppRole(name)
            {
                Name = name,
                
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                // Redirect to the index page
                return RedirectToAction("Index");
            }
            else
            {
                // Display an error message
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }
        }

        // GET: AppRoleController/Edit/5
        [AuthorizeByPermission("AppRole", Operation.Update)]
        public ActionResult Edit(string id)
        {
            // Display the edit form for a specific role
            var role = appRoleRepository.GetAppRoleWithPermissions(id);
            ViewBag.permissions = permissionRepository.GetPermissions();
            return View(role);
        }

        // POST: AppRoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("AppRole", Operation.Update)]
        public async Task<IActionResult> Edit(string id, IFormCollection collection)
        {
            // Update the role
            var role = _roleManager.FindByIdAsync(id).Result;
            role.Name = collection["name"];
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                // Redirect to the index page
                return RedirectToAction("Index");
            }
            else
            {
                // Display an error message
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(role);
            }
        }

        // GET: AppRoleController/Delete/5
        [AuthorizeByPermission("AppRole", Operation.Delete)]
        public ActionResult Delete(string id)
        {
            // Display the delete confirmation page for a specific role
            var role = _roleManager.FindByIdAsync(id).Result;
            return View(role);
        }

        // POST: AppRoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       [AuthorizeByPermission("AppRole", Operation.Delete)]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            // Delete the role
            var role = _roleManager.FindByIdAsync(id).Result;
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                // Redirect to the index page
                return RedirectToAction("Index");
            }
            else
            {
                // Display an error message
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(role);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("AppRole", Operation.Update)]
        public IActionResult AddPermissions(string Id,[FromForm] Dictionary<string, int> formData)
        {
            // Get all the IDs of permissions submitted by the user.
            var permissionIds = formData.Values.ToList();
            var role = _roleManager.FindByIdAsync(Id).Result;
            List<Permission> NewPermissions = new List<Permission> { }; 
            if(role != null)
            {
                foreach (var permission in permissionIds)
                {
                    if(permission != 0)
                    {
                        var NewPermission =  permissionRepository.GetPermission(permission);
                        NewPermissions.Add(NewPermission);
                    }
                }
                permissionRepository.AddPermissionToRole(Id, NewPermissions);
            }
            return RedirectToAction("Index");
        }
    }
}
