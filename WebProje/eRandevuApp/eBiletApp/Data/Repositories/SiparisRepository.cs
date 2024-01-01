using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories
{
    public class RandevuRepository : IRandevuRepository
    {
        private readonly RandevuDbContext _context;
        public RandevuRepository(RandevuDbContext context)
        {
            _context = context;
        }

        public async Task RandevuyuKaydet(ICollection<Sepet> urunler, string kullaniciId, string kullaniciEmail)
        {
            var randevu = new Randevu();

            randevu.KullaniciId = kullaniciId;
            randevu.KullaniciEmail = kullaniciEmail;

            await _context.Randevular.AddAsync(randevu);
            await _context.SaveChangesAsync();

            foreach(var urun in urunler)
            {
                var randevuPoliklinik = new RandevuPoliklinik()
                {
                    Adet = urun.Adet,
                    PoliklinikId = urun.Poliklinik.PoliklinikId,
                    Fiyat = urun.Poliklinik.FilmUcreti,
                    RandevuId = randevu.RandevuId
                };
                await _context.RandevuPoliklinikler.AddAsync(randevuPoliklinik);
                await _context.SaveChangesAsync();
            }
          
        }

        public async Task<ICollection<Randevu>> RandevulariGetir(string kullaniciId, string rol)
        {
            var randevular = await _context.Randevular.Include(m => m.RandevuPoliklinikler).ThenInclude(m => m.Poliklinik).Include(m=>m.Kullanici).ToListAsync();
            if(rol!="Admin")
            {
                randevular = randevular.Where(m => m.KullaniciId == kullaniciId).ToList();
            }
            return randevular;
        }
    }
}
