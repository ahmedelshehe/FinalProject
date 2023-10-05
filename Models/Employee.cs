using FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public enum Gender { Male, Female }

    public class Employee
    {
        [Key]
        public int Id { get; set; }
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The {0} field can only contain letters.")]
		[Required(ErrorMessage = "You should enter the first name")]
        [MaxLength(10,ErrorMessage = "You should enter at most 10 Letters")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should enter the last name")]
        [MaxLength(10, ErrorMessage = "You should enter at most 10 Letters")]
        [Display(Name = "Last Name")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The {0} field can only contain letters.")]
		public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; } = "12345678";

        public int AvailableVacations { get; set; } = 21;
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The {0} field can only contain letters.")]
		public string Street { get; set; }

        [Required(ErrorMessage = "You should enter a city")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The {0} field can only contain letters.")]
		public string City { get; set; }

        [Required(ErrorMessage = "You should enter a country")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The {0} field can only contain letters.")]
		public string Country { get; set; }

        [Required(ErrorMessage = "You should choose a gender")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid Gender value.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "You should enter a birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
/*		[AgeRange(ErrorMessage = "Age should be between 20 and 60 years.")]
*/		public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - BirthDate.Year;
                if (BirthDate > now.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        [Required(ErrorMessage = "You should enter a contract date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]

		public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "You should enter an email")]
        [DataType(DataType.EmailAddress)]
        [UniqueEmployeeEmail(ErrorMessage = "Email Address already exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should enter a national id")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "National Id must be exactly 14 digits.")]
        [UniqueEmployeeNationalId(ErrorMessage ="National Id already exists")]
        public string NationalId { get; set; }


        [Required(ErrorMessage = "You should enter a salary")]
        [Range(5000,500000,ErrorMessage ="You should enter a salary between 5K and 500K")]
        public double Salary { get; set; }


        // Navigation Properties

        // MultivaluedAttribute
        public virtual ICollection<PhoneNumber>? PhoneNumbers { get; set; }


        // Employee's Departments
        [ForeignKey("Department")]
        [Display(Name ="Departments")]
        public int DeptID { get; set; }

        public virtual Department? Department { get; set; }

        // Employee's Attendance Records
        [ForeignKey("User")]
        public string? UserId { get; set; }

        public virtual AppUser? User { get; set; } 
        public virtual IEnumerable<Attendance>? Attendances { get; set; }
        public virtual IEnumerable<Vacation>? Vacations { get; set; }
    }
}
