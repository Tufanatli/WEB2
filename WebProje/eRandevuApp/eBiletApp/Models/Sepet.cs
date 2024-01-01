using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class Sepet
    {
        public int SepetId { get; set; }
        public int Adet { get; set; }
        public Poliklinik Poliklinik { get; set; }

        public string SepetNo { get; set; }
    }
}
