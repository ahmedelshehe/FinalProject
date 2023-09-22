using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class AppUser :IdentityUser
    {
        [Key]
        public int Id {  get; set; }
        public int EmpId { get; set; }
        public virtual Employee Employee { get; set; }  

        public virtual IEnumerable<Role> Roles { get; set;}
    }
}
