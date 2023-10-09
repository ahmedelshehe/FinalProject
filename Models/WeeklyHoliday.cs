using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class WeeklyHoliday
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "You should enter letters only")]
        public string Holiday { get; set; }

        [ForeignKey("GenrealSetting")]
        public int Genral_Id { get; set; }
        public GeneralSetting? GenrealSetting { get; set; }
    }
}
