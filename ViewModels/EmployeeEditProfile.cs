using FinalProject.Utilities;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{


    public class EmployeeEditProfile
    {
        [Required(ErrorMessage = "You should enter the first name")]
        [MaxLength(10, ErrorMessage = "You should enter at most 10 Letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should enter the last name")]
        [MaxLength(10, ErrorMessage = "You should enter at most 10 Letters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You should enter the old password")]
        [Display(Name = "Old Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You should enter the new password")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        public string Street { get; set; }

        [Required(ErrorMessage = "You should enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "You should enter a country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "You should enter a birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [AgeRange(ErrorMessage = "Age should be between 20 and 60 years.")]
        public DateTime BirthDate { get; set; }

    }

}