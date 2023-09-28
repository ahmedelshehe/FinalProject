using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;

namespace FinalProject.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionController(IPermissionRepository repository)
        {
            permissionRepository = repository;
        }

        // GET: Permissions
        public async Task<IActionResult> Index()
        {
            return View(permissionRepository.GetPermissions().ToList());
        }

        // GET: Permissions/Details/5
        [AuthorizeByPermission("Permission", Operation.Show)]

        public async Task<IActionResult> Details(int id)
        {
            var permission = permissionRepository.GetPermission(id);

            return View(permission);
        }

        // GET: Permissions/Create
        [AuthorizeByPermission("Permission", Operation.Add)]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("Permission", Operation.Add)]

        public IActionResult Create(Permission permission)
        {
            if (ModelState.IsValid)
            {
                permissionRepository.InsertPermission(permission);
                return RedirectToAction(nameof(Index));
            }
            return View(permission);
        }

        // GET: Permissions/Edit/5
        [AuthorizeByPermission("Permission", Operation.Update)]

        public async Task<IActionResult> Edit(int id)
        {
            var permission = permissionRepository.GetPermission(id);
            if (permission == null)
            {
                return NotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("Permission", Operation.Update)]

        public async Task<IActionResult> Edit(Permission permission)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    permissionRepository.UpdatePermission(permission.Id,permission);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionExists(permission.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(permission);
        }

        // GET: Permissions/Delete/5
        [AuthorizeByPermission("Permission", Operation.Delete)]

        public async Task<IActionResult> Delete(int id)
        {

            var permission = permissionRepository.GetPermission(id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeByPermission("Permission", Operation.Delete)]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var permission = permissionRepository.GetPermission(id);
            if (permission != null)
            {
                permissionRepository.DeletePermission(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionExists(int id)
        {
          return (permissionRepository.GetPermissions()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
