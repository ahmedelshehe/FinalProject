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
    public class EndDateAfterStartDateAttribute : ValidationAttribute
    {
        public EndDateAfterStartDateAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
            {
                return new ValidationResult(ErrorMessage);
            }

            DateTime endDate = (DateTime)value;

            // Get the StartDate property value.
            DateTime startDate = (DateTime)validationContext.ObjectInstance.GetType().GetProperty("StartDate").GetValue(validationContext.ObjectInstance);

            if (endDate < startDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    public class YesterdayOrToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
            {
                return new ValidationResult("Start Date can be atmost yesterday .");
                
            }

            DateTime date = (DateTime)value;

            if(date >= DateTime.Today.AddDays(-1))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Start Date can be atmost yesterday .");
            }
        }
    }
    public class AgeRangeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime birthDate = (DateTime)value;
			DateTime today = DateTime.Today;
			int age = today.Year - birthDate.Year;

			if (birthDate > today.AddYears(-age))
				age--;

			if (age < 20 || age > 60)
				return new ValidationResult("Age should be between 20 and 60 years.");

			return ValidationResult.Success;
		}
	}
}
