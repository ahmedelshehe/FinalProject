using FinalProject.Models;
using FinalProject.RepoServices;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Middleware
{
    public class PermissionsMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<AppUser> userManager, IAppRoleRepository appRoleRepository)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userId = userManager.GetUserId(context.User);

                var user = await userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var appRole = appRoleRepository.GetAppRoleWithPermissions(user.RoleAppId);

                    if (appRole != null)
                    {
                        context.Items.Add("Role", appRole.Name);
						if (appRole.Name == "Admin")
						{
							context.Items.Add("CanViewPermissions", true);
						}

						var permissions = appRole.Permissions;

                        context.Items.Add("Permissions", permissions.ToList());
                    }
                }
            }

            await _next(context);
        }
    }
}
