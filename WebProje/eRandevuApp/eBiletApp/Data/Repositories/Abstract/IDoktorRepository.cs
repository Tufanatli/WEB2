using eRandevuApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories.Abstract
{
    public interface IDoktorRepository
    {
        doktor GetById(int id);
        void Add(doktor doktor);
        void Delete(int id);
        doktor Update(int id,doktor doktorSon);
        Task<IEnumerable<doktor>> ListAll();

    }
}
