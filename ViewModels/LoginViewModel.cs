using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You should enter an email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}