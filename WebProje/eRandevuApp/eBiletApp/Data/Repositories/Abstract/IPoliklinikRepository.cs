using eRandevuApp.Models;
using eRandevuApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eRandevuApp.Data.Repositories.Abstract
{
    public interface IPoliklinikRepository
    {
        Poliklinik GetById(int id);
        void Add(Poliklinik Poliklinik);
        void Delete(int id);
        Poliklinik Update(int id, Poliklinik poliklinikSon);
        Task<IEnumerable<Poliklinik>> ListAll();
        Task<IEnumerable<Poliklinik>> ListAll(params Expression<Func<Poliklinik, object>>[] i);
        Task<PoliklinikVeriLists> poliklinikVerileri();
        Task PoliklinikEkle(HastaneVM fvm);
        Task PoliklinikGuncelle(HastaneVM fvm);
        Poliklinik PoliklinikGetir(int id);
    
    }
}
