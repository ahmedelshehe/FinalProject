using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public enum Operation { Add , Show , Update ,Delete}
    public class Permission 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You should enter permission name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should choose an operation")]
        [EnumDataType(typeof(Operation), ErrorMessage = "Invalid Operation value.")]
        public Operation Operation { get; set; }

        public virtual IEnumerable<AppRole>? AppRoles { get; set; }
    }
}
