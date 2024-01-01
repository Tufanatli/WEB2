using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using eRandevuApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories
{
    public class PoliklinikRepository : IPoliklinikRepository
    {
        private readonly RandevuDbContext _context;
        public PoliklinikRepository(RandevuDbContext context)
        {
            _context = context;
        }

        public void Add(Poliklinik Poliklinik)
        {
            _context.Add(Poliklinik);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekPoliklinik = _context.poliklinikler.FirstOrDefault(m => m.PoliklinikId == id);
            var ilgilisepet = _context.Sepetler.Where(b => b.Poliklinik.PoliklinikId == silinecekPoliklinik.PoliklinikId).AsEnumerable();
            foreach (var sp in ilgilisepet)
            {
                var s = sp;
                _context.Sepetler.Remove(s);
            }
  
            _context.poliklinikler.Remove(silinecekPoliklinik);
            _context.SaveChanges();

        }

        public async Task PoliklinikEkle(HastaneVM fvm)
        {
            var Poliklinik = new Poliklinik();
            Poliklinik.PoliklinikAdi = fvm.PoliklinikAdi;
            Poliklinik.RandevuBaslamaSaati1 = fvm.RandevuBaslamaSaati1;
            Poliklinik.RandevuBaslamaSaati2 = fvm.RandevuBaslamaSaati2;
            Poliklinik.RandevuBaslamaSaati3 = fvm.RandevuBaslamaSaati3;
            Poliklinik.PoliklinikFotografi = fvm.PoliklinikFotografi;
            Poliklinik.PoliklinikHakkinda = fvm.PoliklinikHakkinda;
            Poliklinik.AnaBilimDali = fvm.AnaBilimDali;
            Poliklinik.FilmUcreti=fvm.FilmUcreti;
            Poliklinik.HastaneId = fvm.HastaneId;
            Poliklinik.BashekimId = fvm.BashekimId;
            await _context.poliklinikler.AddAsync(Poliklinik);
            await _context.SaveChangesAsync();

            foreach(var doktor in fvm.DoktorListesi) //doktorlistesi doktor id'lerini tutuyor
            {
                var poliklinikdoktor = new PoliklinikDoktor();
                poliklinikdoktor.PoliklinikId = Poliklinik.PoliklinikId;
                poliklinikdoktor.DoktorId = doktor;
                await _context.PolikliniklerDoktorlar.AddAsync(poliklinikdoktor);
            }
            await _context.SaveChangesAsync();
            
        }

        public  Poliklinik PoliklinikGetir(int id)
        {
            var PoliklinikGetir =  _context.poliklinikler
                .Include(fo => fo.PolikliniklerDoktorlar).ThenInclude(o => o.doktor)
                .Include(s => s.Hastane)
                .Include(y => y.Bashekim)
                .FirstOrDefault(m => m.PoliklinikId == id);
            return   PoliklinikGetir;
        }

        public async Task PoliklinikGuncelle(HastaneVM fvm)
        {
            var poliklinikBul = await _context.poliklinikler.FirstOrDefaultAsync(m => m.PoliklinikId == fvm.PoliklinikId);


            if (poliklinikBul != null)
            {
                poliklinikBul.PoliklinikAdi = fvm.PoliklinikAdi;
                poliklinikBul.RandevuBaslamaSaati1 = fvm.RandevuBaslamaSaati1;
                poliklinikBul.RandevuBaslamaSaati2 = fvm.RandevuBaslamaSaati2;
                poliklinikBul.RandevuBaslamaSaati3 = fvm.RandevuBaslamaSaati3;
                poliklinikBul.PoliklinikFotografi = fvm.PoliklinikFotografi;
                poliklinikBul.PoliklinikHakkinda = fvm.PoliklinikHakkinda;
                poliklinikBul.AnaBilimDali = fvm.AnaBilimDali;
                poliklinikBul.FilmUcreti = fvm.FilmUcreti;
                poliklinikBul.HastaneId = fvm.HastaneId;
                poliklinikBul.BashekimId = fvm.BashekimId;
                await _context.SaveChangesAsync();
            }
                

                var oncekiDoktorlar = _context.PolikliniklerDoktorlar.Where(m => m.PoliklinikId == fvm.PoliklinikId).ToList();
                _context.PolikliniklerDoktorlar.RemoveRange(oncekiDoktorlar);
                await _context.SaveChangesAsync();

            foreach (var doktor in fvm.DoktorListesi) 
            {
                var poliklinikdoktor = new PoliklinikDoktor();
                poliklinikdoktor.PoliklinikId = fvm.PoliklinikId;
                poliklinikdoktor.DoktorId = doktor;
                await _context.PolikliniklerDoktorlar.AddAsync(poliklinikdoktor);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<PoliklinikVeriLists> poliklinikVerileri()
        {
            var veriler = new PoliklinikVeriLists();
            veriler.Hastaneler = await _context.Hastaneler.ToListAsync();
            veriler.Bashekimler = await _context.Bashekimler.ToListAsync();
            veriler.Doktorlar = await _context.Doktorlar.ToListAsync();
            return veriler;
        }

        public Poliklinik GetById(int id)
        {
            var f = _context.poliklinikler.FirstOrDefault(m => m.PoliklinikId == id);
            return f;
        }
        
        public async Task<IEnumerable<Poliklinik>> ListAll()
        {
            var liste = await _context.poliklinikler.ToListAsync();
            return liste;
        }

        public async Task<IEnumerable<Poliklinik>> ListAll(params Expression<Func<Poliklinik, object>>[] i)
        {
            IQueryable<Poliklinik> sorgu = _context.Set<Poliklinik>();
            sorgu= i.Aggregate(sorgu,(current,prop)=>current.Include(prop));
            return await sorgu.ToListAsync();

        }

        public Poliklinik Update(int id, Poliklinik poliklinikSon)
        {
            _context.Update(poliklinikSon);
            _context.SaveChanges();
            return poliklinikSon;
        }
    }
}
