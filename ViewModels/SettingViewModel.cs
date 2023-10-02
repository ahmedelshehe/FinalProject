using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class SettingViewModel
    {
        [Key]
        public int id { get; set; }
        public int Extra { get; set; }

        public int Discount { get; set; }

    }
}
