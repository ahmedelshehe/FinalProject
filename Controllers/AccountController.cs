using FinalProject.Models;
using FinalProject.RepoServices;
using FinalProject.Utilities;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IEmailService emailService;

        public IEmployeeRepository EmployeeRepository { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager , IEmployeeRepository employeeRepository, IUserRepository userRepository, IEmailService emailService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            EmployeeRepository = employeeRepository;
            this.emailService = emailService;
        }




        [Authorize]
        [AuthorizeByPermission("AppUser",Operation.Add)]
        public async Task<IActionResult> AddUser(int id)
        {
            var emp_user = EmployeeRepository.GetEmployee(id);
            AppUser userDbModel = new AppUser();
            var hasher = new PasswordHasher<AppUser>();
            userDbModel.Email = emp_user.Email;
            userDbModel.PasswordHash = hasher.HashPassword(null, emp_user.Password);
            userDbModel.EmpId = id;
            userDbModel.UserName = emp_user.FirstName + emp_user.Id;

            var createUser = await userManager.CreateAsync(userDbModel);
            if (createUser.Succeeded)
            {
                emp_user.UserId = userManager.Users.FirstOrDefault(e => e.EmpId == id).Id;
                EmployeeRepository.UpdateEmployee(id, emp_user);
                EmailDto newMail = new EmailDto()
                {
                    Subject = "Account Created",
                    To = emp_user.Email,
                    Body = $@"
            <h1>Account Created</h1>
            <p>Dear {emp_user.FirstName},</p>
            <p>Your account has been created successfully. Please use the following credentials to log in:</p>
            <ul>
                <li>Email: {emp_user.Email}</li>
                <li>Password: {emp_user.Password}</li>
            </ul>
            <p>Thank you for using our system.</p>
            "
                };
                emailService.SendEmail(newMail);
                return RedirectToAction("Index", "Employee");
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

                        return RedirectToAction("Dashboard", "Profile");
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
