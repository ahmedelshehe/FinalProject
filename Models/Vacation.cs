using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinalProject.Models;

namespace FinalProject.Models
{
        public enum VacationTypes { Sick ,Casual ,Paternity , Other }
        public class Vacation
        {

        [Required(ErrorMessage ="You should choose startdate")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "You should choose enddate")]

        public DateTime? EndDate { get; set; }

        // public int VacationDays {  }

        public VacationTypes VacationType { get; set; } 
        public bool Approved { get; set; } = false;

        [ForeignKey("Employee")]
        [Required(ErrorMessage = "You should choose an employee")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

    }
}
