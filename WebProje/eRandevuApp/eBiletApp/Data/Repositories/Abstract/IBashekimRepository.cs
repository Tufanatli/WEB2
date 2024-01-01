using eRandevuApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories.Abstract
{
    public interface IBashekimRepository
    {
        Bashekim GetById(int id);
        void Add(Bashekim bashekim);
        void Delete(int id);
        Bashekim Update(int id, Bashekim bashekimSon);
        Task<IEnumerable<Bashekim>> ListAll();
    }
}
