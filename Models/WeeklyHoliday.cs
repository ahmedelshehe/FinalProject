using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class WeeklyHoliday
    {
        public string Holiday { get; set; }

        [ForeignKey("GenrealSetting")]
        public int Genral_Id { get; set; }
        public GeneralSetting? GenrealSetting { get; set; }
    }
}
