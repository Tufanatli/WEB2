using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories
{
    public class BashekinRepository : IBashekimRepository
    {
        private readonly RandevuDbContext _context;
        public BashekinRepository(RandevuDbContext context)
        {
            _context = context;
        }
        public void Add(Bashekim bashekim)
        {
            _context.Add(bashekim);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekBashekim = _context.Bashekimler.FirstOrDefault(m => m.BashekimId == id);
            _context.Bashekimler.Remove(silinecekBashekim);
            _context.SaveChanges();
        }

        public Bashekim GetById(int id)
        {
            var y = _context.Bashekimler.FirstOrDefault(m => m.BashekimId == id);
            return y;
        }

        public async Task<IEnumerable<Bashekim>> ListAll()
        {
            var liste = await _context.Bashekimler.ToListAsync();
            return liste;
        }

        public Bashekim Update(int id, Bashekim bashekimSon)
        {
            _context.Update(bashekimSon);
            _context.SaveChanges();
            return bashekimSon;
        }
    }
}
