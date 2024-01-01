using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models
{
    public class PoliklinikDoktor
    {

        public int DoktorId  { get; set; }
        public int PoliklinikId { get; set; }

        public doktor doktor { get; set; }
        public Poliklinik Poliklinik { get; set; }

    }
}
