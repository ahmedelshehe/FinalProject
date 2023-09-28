using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Utilities
{
	public class AuthorizeByPermission : AuthorizeAttribute , IAuthorizationFilter
	{
		private readonly string Name;
		private readonly Operation Operation;

		public AuthorizeByPermission(string name ,Operation operation)
		{
			Name = name;
			Operation = operation;
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
			var hasPermission = userPermissions.Any(p => p.Operation == Operation && p.Name == Name);

			if (!hasPermission)
			{
				context.Result = new ForbidResult();
				return;
			}
		}
	} 


	
}
