using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class OfficialVacation 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="You should enter title of vacation")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "You should enter letters only")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public string? UserId;

        public virtual AppUser? User { get; set; }

    }
}
