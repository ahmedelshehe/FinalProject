using FinalProject.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Utilities
{

    public class UniqueDepartmentName : ValidationAttribute
    {
        private const string DefaultErrorMessage ="Please Enter Unique Value";
        private const string DefaultEmptyErrorMessage ="This Field is Required";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var applicationDbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (value == null)
                return new ValidationResult(ErrorMessage ?? DefaultEmptyErrorMessage);
            else
            {
                var isUnique =
                    applicationDbContext.Departments.FirstOrDefault(n => (string)value == n.Name);
                if (isUnique != null)
                {
                    return new ValidationResult(ErrorMessage ??DefaultErrorMessage);
                }
                
             }
            return ValidationResult.Success;
        }
    }

    public class UniqueEmployeeEmail : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Please Enter Unique Value";
        private const string DefaultEmptyErrorMessage = "This Field is Required";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var applicationDbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (value == null)
                return new ValidationResult(ErrorMessage ?? DefaultEmptyErrorMessage);
            else
            {
                var isUnique =
                    applicationDbContext.Employees.FirstOrDefault(n => (string)value == n.Email);
                if (isUnique != null)
                {
                    return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
                }

            }
            return ValidationResult.Success;
        }
    }

    public class UniqueEmployeeNationalId : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Please Enter Unique Value";
        private const string DefaultEmptyErrorMessage = "This Field is Required";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var applicationDbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (value == null)
                return new ValidationResult(ErrorMessage ?? DefaultEmptyErrorMessage);
            else
            {
                var isUnique =
                    applicationDbContext.Employees.FirstOrDefault(n => (string)value == n.NationalId);
                if (isUnique != null)
                {
                    return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
                }

            }
            return ValidationResult.Success;
        }
    }
}
