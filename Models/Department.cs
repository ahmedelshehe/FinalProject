using FinalProject.Utilities;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You should enter a department name")]
        [UniqueDepartmentName(ErrorMessage ="Department name already exists")]
        public string Name { get; set; } 

        public virtual IEnumerable<Employee>? Employees { get; set; }
    }
}
