using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class AppRole
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual IEnumerable<Permission>? Permissions { get; set;}
        public virtual IEnumerable<AppUser>? Users { get; set;}
    }
}
