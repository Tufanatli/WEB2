using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public string KullaniciEmail { get; set; }
        public string KullaniciId { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        public Kullanici Kullanici { get; set; }
        public ICollection<RandevuPoliklinik> RandevuPoliklinikler { get; set; }
    }
}
