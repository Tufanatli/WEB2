using eRandevuApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories.Abstract
{
    public interface IHastaneRepository
    {
        Hastane GetById(int id);
        void Add(Hastane Hastane);
        void Delete(int id);
        Hastane Update(int id, Hastane hastaneSon);
        Task<IEnumerable<Hastane>> ListAll();
    }
}
