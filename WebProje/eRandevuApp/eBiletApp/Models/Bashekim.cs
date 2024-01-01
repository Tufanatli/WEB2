using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class Bashekim
    {
        public int BashekimId { get; set; }

        [Display(Name="Fotoğraf")]
        public string BashekimFotografi { get; set; }

        [Required(ErrorMessage = "Lütfen bashekim ismi giriniz")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Ad Soyad 5 ila 40 karakter arasında olmalıdır!")]
        [Display(Name = "Name Soyadı")]
        public string BashekimAdSoyad { get; set; }

        [Required(ErrorMessage = "Lütfen hakkında alanını tam doldurunuz!")]
        [Display(Name = "Hakkında")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Hakkında alanı 5 ila 1000 karakter arasında olmalıdır!")]
        public string BashekimHakkinda { get; set; }

        public ICollection<Poliklinik> poliklinikler { get; set; }
    }
}
