using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        public virtual IEnumerable<Employee>? Employees { get; set; }
    }
}
