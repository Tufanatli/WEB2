using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Models.ViewModels
{
    public class PoliklinikVeriLists
    {
        public PoliklinikVeriLists()
        {
            Doktorlar = new List<doktor>();
            Bashekimler = new List<Bashekim>();
            Hastaneler = new List<Hastane>();
        }

        public List<doktor> Doktorlar { get; set; }
        public List<Bashekim> Bashekimler { get; set; }
        public List<Hastane> Hastaneler { get; set; }
    }
}
