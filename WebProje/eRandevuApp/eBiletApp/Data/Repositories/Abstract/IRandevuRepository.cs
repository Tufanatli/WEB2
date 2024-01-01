using eRandevuApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories.Abstract
{
    public interface IRandevuRepository
    {
        Task<ICollection<Randevu>> RandevulariGetir(string kullaniciId, string rol);
        Task RandevuyuKaydet(ICollection<Sepet> urunler, string kullaniciId, string kullaniciEmail);
    }
}
