using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class PhoneNumber
    {

        [Required(ErrorMessage ="You should enter a phone number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11,ErrorMessage ="Phone numbers should be 11 digits")]
        [MinLength(11,ErrorMessage ="Phone numbers should be 11 digits")]
        public string Number { get; set; }

        [Required(ErrorMessage = "You should enter an employee")]
        [ForeignKey("Employee")] 
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
