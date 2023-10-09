using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Attendance
    {


        [Required(ErrorMessage = "You should enter arrival time")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        //public TimeOnly ArrivalTime { get; set; }
        public DateTime ArrivalTime { get; set; }


        [Required(ErrorMessage = "You should enter departure time")]
        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
       // public TimeOnly DepartureTime { get; set; }
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "You should enter date ")]
        [DataType(DataType.Date)]
        //public DateOnly Date { get; set; }
        public DateTime Date { get; set; }


        // When The Difference Between ArrivalTime And Departure Time is More Than 8 Hours => ExtraHours
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ExtraHours { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int DiscountHours { get; private set; }

        // If The Difference Between ArrivalTime And Departure Time is Less Than 8 Hours and More Than 2 Hours
        // => IsAbsent is True Otherwise False
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool IsAbsent { get; private set; } = true;

        [ForeignKey("Employee")]
        [Required(ErrorMessage = "You should choose an employee")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}