using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class Hastane
    {
        public int HastaneId { get; set; }
        [Display(Name = "Hastane Logo")]
        public string HastaneFotografi { get; set; }

        [Required(ErrorMessage = "Lütfen Hastane adını giriniz!")]
        [Display(Name = "Hastane Name")]
        public string HastaneAdi { get; set; }

        [Required(ErrorMessage = "Lütfen hakkında alanını tam doldurunuz!")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Hakkında alanı 5 ila 1000 karakter arasında olmalıdır!")]
        [Display(Name = "Hastane Hakkında")]
        public string HastaneHakkinda { get; set; }

        public ICollection<Poliklinik> poliklinikler { get; set; }
    }
}
