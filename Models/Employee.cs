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

        [Required(ErrorMessage = "The FirstName field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Street field is required.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The Gender field is required.")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid Gender value.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The BirthDate field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The ContractDate field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The NationalId field is required.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "National Id must be exactly 14 digits.")]
        public string NationalId { get; set; }


        [Required(ErrorMessage = "The Salary field is required.")]
        public double Salary { get; set; }


        // Navigation Properties

        // MultivaluedAttribute
        public virtual ICollection<PhoneNumber>? PhoneNumbers { get; set; }


        // Employee's Departments
        [ForeignKey("Department")]
        public int DeptID { get; set; }

        public virtual Department? Department { get; set; }

        // Employee's Attendance Recors
        public virtual IEnumerable<Attendance> Attendances { get; set; }

    }
}
