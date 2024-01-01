using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories
{
    public class HastaneRepository : IHastaneRepository
    {
        private readonly RandevuDbContext _context;
        public HastaneRepository(RandevuDbContext context)
        {
            _context = context;
        }
        public void Add(Hastane Hastane)
        {
            _context.Add(Hastane);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekHastane = _context.Hastaneler.FirstOrDefault(m => m.HastaneId == id);
            _context.Hastaneler.Remove(silinecekHastane);
            _context.SaveChanges();
        }

        public Hastane GetById(int id)
        {
            var s = _context.Hastaneler.FirstOrDefault(m => m.HastaneId == id);
            return s;
        }

        public async Task<IEnumerable<Hastane>> ListAll()
        {
            var liste = await _context.Hastaneler.ToListAsync();
            return liste;
        }

        public Hastane Update(int id, Hastane hastaneSon)
        {
            _context.Update(hastaneSon);
            _context.SaveChanges();
            return hastaneSon;
        }
    }
}
