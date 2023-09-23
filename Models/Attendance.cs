using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Attendance
    {

        [Required]
        public TimeOnly ArrivalTime { get; set; }

        [Required]
        public TimeOnly DepartureTime { get; set; }

        [Required]
        public DateOnly Date { get; set; }


        // When The Difference Between ArrivalTime And Departure Time is More Than 8 Hours => ExtraHours
        public TimeSpan ExtraHours => DepartureTime - ArrivalTime > TimeSpan.FromHours(8) ? DepartureTime - ArrivalTime - TimeSpan.FromHours(8) : TimeSpan.Zero;

        // When The Difference Between ArrivalTime And Departure Time is Less Than 8 Hours (Max 2 Hours) => DiscountHours
        public TimeSpan DiscountHours => ArrivalTime - DepartureTime < TimeSpan.FromHours(8) ? TimeSpan.FromHours(Math.Min((ArrivalTime - DepartureTime).TotalHours, 2)) : TimeSpan.Zero;

        // If The Difference Between ArrivalTime And Departure Time is Less Than 8 Hours and More Than 2 Hours
        // => IsAbsent is True Otherwise False
        public bool IsAbsent => ArrivalTime - DepartureTime < TimeSpan.FromHours(8) && (ArrivalTime - DepartureTime).TotalHours > 2;

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }  
    }
}
