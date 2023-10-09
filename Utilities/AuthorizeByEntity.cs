using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Utilities
{
	public class AuthorizeByEntity : AuthorizeAttribute , IAuthorizationFilter
	{
		private readonly string Name;

		public AuthorizeByEntity(string name)
		{
			Name = name;
		}
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (!context.HttpContext.User.Identity.IsAuthenticated)
			{
				context.Result = new UnauthorizedResult();
				return;
			}

			// Check if the user has the required operation permission
			var userPermissions = (List<Permission>)context.HttpContext.Items["Permissions"];
			var hasAnyPermission = userPermissions == null ? false :
				userPermissions.Any(p => p.Name == Name);

			if (!hasAnyPermission)
			{
                context.Result = new RedirectToActionResult("Error", "Home",new {code =403 } );

                return;
			}
		}
	} 


	
}
