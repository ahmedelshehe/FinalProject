using FinalProject.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalProject.ViewModels
{
    public class EmployeeAttendanceVM
    {
        [Required(ErrorMessage = "You should enter arrival time")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }
        [Required(ErrorMessage = "You should enter departure time")]
        [Display(Name = "Departure Time")]
		[DataType(DataType.Time)]
		public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "You should enter date ")]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }
        [Required(ErrorMessage = "You should enter the first name")]
        [MaxLength(10, ErrorMessage = "You should enter at most 10 Letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should enter the last name")]
        [MaxLength(10, ErrorMessage = "You should enter at most 10 Letters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "You should enter a department name")]
        [UniqueDepartmentName(ErrorMessage = "Department name already exists")]
        public string DeptName { get; set; }
        public int EmployeeId { get; set; }



    }
}
