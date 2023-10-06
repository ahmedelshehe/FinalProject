using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class WeekDaysViewModel
    {

        [Key]
        public int id { get; set; }
        public string Day { get; set; }
        public bool Checked { get; set; }
    }
}
