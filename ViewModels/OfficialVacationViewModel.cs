using FinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class OfficialVacationViewModel
    {
        [Key]
        public int Id { set; get; }
        [Required(ErrorMessage = "please Enter the name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please Enter the Date")]
        [DataType(DataType.Date, ErrorMessage = "please Enter the Right Date")]
        public DateTime Date { get; set; }

        public List<OfficialVacation>? offvac { get; set; }
    }
}
