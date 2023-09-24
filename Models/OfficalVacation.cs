using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class OfficalVacation 
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }

        [ForeignKey("User")]
        public string UserId;

        public virtual AppUser User { get; set; }

    }
}
