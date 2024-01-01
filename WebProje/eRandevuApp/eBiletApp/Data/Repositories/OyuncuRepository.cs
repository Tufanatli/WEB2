using eRandevuApp.Data;
using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories
{
    public class DoktorRepository : IDoktorRepository
    {
        private readonly RandevuDbContext _context;
        public DoktorRepository(RandevuDbContext context)
        {
            _context = context;
        }
        public void Add(doktor doktor)
        {
            
            _context.Add(doktor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekDoktor = _context.Doktorlar.FirstOrDefault(m => m.DoktorId == id);
            _context.Doktorlar.Remove(silinecekDoktor);
            _context.SaveChanges();
        }

        public doktor GetById(int id)
        {
            var o = _context.Doktorlar.FirstOrDefault(m => m.DoktorId == id);
            return o;
        }

        public async Task<IEnumerable<doktor>> ListAll()
        {
            var liste = await _context.Doktorlar.ToListAsync();
            return liste;
        }

        public doktor Update(int id, doktor doktorSon)
        {
            _context.Update(doktorSon);
            _context.SaveChanges();
            return doktorSon;
        }

    }
}
