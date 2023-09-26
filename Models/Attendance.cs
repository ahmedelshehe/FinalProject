using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Attendance
    {


        [Required(ErrorMessage ="You should enter arrival time")]
        [Display(Name ="Arrival Time")]
		[DataType(DataType.Time)]
		public DateTime ArrivalTime { get; set; }


        [Required(ErrorMessage = "You should enter departure time")]
        [Display(Name = "Departure Time")]
		[DataType(DataType.Time)]
		public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "You should enter date ")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        // When The Difference Between ArrivalTime And Departure Time is More Than 8 Hours => ExtraHours
        public TimeSpan ExtraHours => DepartureTime - ArrivalTime > TimeSpan.FromHours(8) ? DepartureTime - ArrivalTime - TimeSpan.FromHours(8) : TimeSpan.Zero;

        // When The Difference Between ArrivalTime And Departure Time is Less Than 8 Hours (Max 5 Hours) => DiscountHours
        public TimeSpan DiscountHours => ArrivalTime - DepartureTime < TimeSpan.FromHours(8) ? TimeSpan.FromHours(Math.Min((ArrivalTime - DepartureTime).TotalHours, 5)) : TimeSpan.Zero;

        // If The Difference Between ArrivalTime And Departure Time is Less Than 8 Hours and More Than 2 Hours
        // => IsAbsent is True Otherwise False
        public bool IsAbsent => ArrivalTime - DepartureTime < TimeSpan.FromHours(8) && (ArrivalTime - DepartureTime).TotalHours > 5;

        [ForeignKey("Employee")]        
        [Required(ErrorMessage = "You should choose an employee")]
        [Display(Name ="Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }  
    }
}
