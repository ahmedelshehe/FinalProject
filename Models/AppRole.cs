using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class AppRole :IdentityRole
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="You should enter a role name")]
        public string Name { get; set; }

        public virtual IEnumerable<AppUser>? Users { get; set;}

        public virtual IEnumerable<Permission>? Permissions { get; set;}
    }
}
