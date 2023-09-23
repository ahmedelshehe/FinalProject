using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class AppUser :IdentityUser
    {
        [Key]
        public int Id {  get; set; }
        [Required(ErrorMessage = "You should enter an employee")]
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        public virtual Employee? Employee { get; set; }


    }
}
