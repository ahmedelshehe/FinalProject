using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public IEmployeeRepository EmployeeRepository { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager , IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            EmployeeRepository = employeeRepository;
        }





        public async Task<IActionResult> AddUser(int id)
        {
            var emp_user = EmployeeRepository.GetEmployee(id);
            AppUser userDbModel = new AppUser();
            var hasher = new PasswordHasher<AppUser>();
            userDbModel.Email =emp_user.Email;
            userDbModel.PasswordHash = hasher.HashPassword(null, emp_user.Password);
            userDbModel.EmpId = id;
            userDbModel.UserName = emp_user.FirstName + emp_user.Id;

            var createUser = await userManager.CreateAsync(userDbModel);
            if (createUser.Succeeded)
            {
                return RedirectToAction( "Index", "Employee");
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }

        }

        


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
			return RedirectToAction("Login", "Account");
		}

		[HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = null;

                // Check if the login input is an email or username
                if (model.Email.Contains("@"))
                {
                    user = await userManager.FindByEmailAsync(model.Email);
                }
                else
                {
                    user = await userManager.FindByNameAsync(model.Email);
                }

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (signInResult.Succeeded)
                    {
                        // Add user information to cookies
                        HttpContext.Response.Cookies.Append("LoggedInUser", user.Email);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

    }
}
