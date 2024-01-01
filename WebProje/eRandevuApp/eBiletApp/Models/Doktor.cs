using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class doktor
    {
        public int DoktorId { get; set; }
        //[Required(ErrorMessage ="Lütfen fotoğraf seçiniz")]
        [Display(Name="Fotoğrafı")]
        public string DoktorFotografi { get; set; }

        [Required(ErrorMessage = "Lütfen isim giriniz")]
        [StringLength(40,MinimumLength = 5,ErrorMessage ="Ad Soyad 5 ila 40 karakter arasında olmalıdır!")]
        [Display(Name = "Name Soyadı")]
        public string DoktorAdSoyad { get; set; }

        [Required(ErrorMessage = "Lütfen hakkında alanını tam doldurunuz!")]
        [Display(Name = "Hakkında")]
        [StringLength(1000,MinimumLength = 5,  ErrorMessage = "Hakkında alanı 5 ila 1000 karakter arasında olmalıdır!")]
        public string DoktorHakkinda { get; set; }

        public ICollection<PoliklinikDoktor> PolikliniklerDoktorlar { get; set; }
    }
}
