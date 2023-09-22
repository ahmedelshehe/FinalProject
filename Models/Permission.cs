using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public enum Operation { Add , Show , Update ,Delete}
    public class Permission : IdentityRoleClaim<string>
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Operation field is required.")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid Operation value.")]
        public Operation Operation { get; set; }


    }
}
