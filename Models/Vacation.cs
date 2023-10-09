using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinalProject.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using System.Runtime.Intrinsics.X86;
using FinalProject.Utilities;

namespace FinalProject.Models
{
        public enum VacationTypes { Sick ,Casual ,Paternity , Other }
        public enum VacationStatus { Pending, Approved, Rejected }

    public class Vacation
    {
        [Key]
		[Required(ErrorMessage ="You should choose startdate")]
        [DataType(DataType.Date)]
/*        [YesterdayOrToday]
*/        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "You should choose enddate")]
		[DataType(DataType.Date)]
        [EndDateAfterStartDateAttribute(errorMessage:  "End Date can not be before start date")]
		public DateTime EndDate { get; set; }

        public VacationStatus Status { get; set; } = VacationStatus.Pending;

        TimeSpan _vacationDuration { get
            {
                return EndDate.Date.Subtract(StartDate.Date);
            } }
        public int VacationDays {
			get
			{
				if (StartDate.Date == EndDate.Date)
				{
					return 1;
				}
				else
				{
					return (int)_vacationDuration.Days + 1;
				}
			}
		}

        public VacationTypes VacationType { get; set; } 

        [ForeignKey("Employee")]
        [Required(ErrorMessage = "You should choose an employee")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

        public string Description { get; set; }
    }
}
