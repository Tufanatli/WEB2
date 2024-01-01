using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class RandevuPoliklinik
    {
        public int RandevuPoliklinikId { get; set; }
        public float Fiyat { get; set; }
        public int Adet { get; set; }

        public int PoliklinikId { get; set; }
        [ForeignKey("PoliklinikId")]
        public Poliklinik Poliklinik { get; set; }

        public int RandevuId { get; set; }
        [ForeignKey("RandevuId")]
        public Randevu Randevu { get; set; }
    }
}
