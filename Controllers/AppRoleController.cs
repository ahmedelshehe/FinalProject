using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    using FinalProject.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AppRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        public AppRoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: AppRoleController/Index
        public ActionResult Index()
        {
            // Display a list of all roles
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        // GET: AppRoleController/Details/5
        public ActionResult Details(string id)
        {
            // Display details of a specific role
            var role = _roleManager.FindByIdAsync(id).Result;
            return View(role);
        }

        // GET: AppRoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppRoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(string id)
        {
            // Display the edit form for a specific role
            var role = _roleManager.FindByIdAsync(id).Result;
            return View(role);
        }

        // POST: AppRoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Delete(string id)
        {
            // Display the delete confirmation page for a specific role
            var role = _roleManager.FindByIdAsync(id).Result;
            return View(role);
        }

        // POST: AppRoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

    }
}
