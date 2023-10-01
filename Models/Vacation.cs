using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinalProject.Models;

namespace FinalProject.Models
{
        public enum VacationTypes { Sick ,Casual ,Paternity , Other }
        public enum VacationStatus { Pending, Approved, Rejected }

    public class Vacation
        {

        [Key]
		[Required(ErrorMessage ="You should choose startdate")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "You should choose enddate")]

        public DateTime? EndDate { get; set; }

        public VacationStatus Status { get; set; } = VacationStatus.Pending;

        TimeSpan _vacationDuration { get
            {
                return EndDate.Value.Subtract(StartDate.Value);
            } }
        public int VacationDays { get {
                return (int)_vacationDuration.TotalDays;
            } }

        public VacationTypes VacationType { get; set; } 

        [ForeignKey("Employee")]
        [Required(ErrorMessage = "You should choose an employee")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

        public string Description { get; set; }
    }
}
