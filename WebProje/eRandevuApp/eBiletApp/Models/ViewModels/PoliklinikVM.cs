using eRandevuApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class HastaneVM
    {
        //Poliklinik modelinin create işlemi için bir viewmodel oluşturuldu

        public int PoliklinikId { get; set; }

        [Display(Name = "Poliklinik Name")]
        public string PoliklinikAdi { get; set; }

        [Display(Name = "Poliklinik Hakkında")]
        [StringLength(10000,MinimumLength =100,ErrorMessage ="Poliklinik Açıklaması 100-10000 karakter arasında olmalıdır")]
        public string PoliklinikHakkinda { get; set; }

        [Display(Name ="Poliklinik Randevu Saatleri")]
        public string RandevuBaslamaSaati1 { get; set; }
        public string RandevuBaslamaSaati2 { get; set; }
        public string RandevuBaslamaSaati3 { get; set; }

        [Display(Name = "Poliklinik Fotoğrafı")]
        public string PoliklinikFotografi { get; set; }

        [Display(Name = "Poliklinik Türü")]
        public AnaBilimDali AnaBilimDali { get; set; }

        [Display(Name = "Poliklinik Ücreti")]
        public float FilmUcreti { get; set; }


        [Display(Name = "Poliklinik Doktorları")]
        /*Poliklinik modelimizde alttaki collection PoliklinikDoktor tipinde idi. Ancak many to many ilişkide ara tabloyla ilgili işlemleri yapabilmek için
         * bu listenin tipini int olarak değiştirdim ve View'de dseçilen oyuncuların ID'lerinin tutulmasını sağladım.
         */
        public ICollection<int> DoktorListesi { get; set; }

        [Display(Name = "Hastane Name")]
        public int HastaneId { get; set; }
        [Display(Name = "Bashekim Name")]
        public int BashekimId { get; set; }

    }
    
}
