using eRandevuApp.Data;
using eRandevuApp.Data.Repositories;
using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eRandevuApp.Controllers
{
    [Authorize]
    public class RandevuController : Controller
    {
        private readonly IRandevuRepository _randevuRepo;
        private readonly SepetRepository _sepetRepo;
        private readonly IPoliklinikRepository _filmRepo;

        public RandevuController(IRandevuRepository siparisRepo,SepetRepository sepetRepo, IPoliklinikRepository filmRepo)
        {
            _randevuRepo = siparisRepo;
            _sepetRepo = sepetRepo;
            _filmRepo = filmRepo;
        }


        public IActionResult Index()
        {
            //Alışveriş Sepeti Actionı
            var sepettekiler = _sepetRepo.SepeteEklenenler();
            _sepetRepo.Sepettekiler = sepettekiler;

            var svm = new SepetVM();
            svm.SepetRepo = _sepetRepo;
            svm.ToplamTutar = _sepetRepo.SepetToplamTutar();

            return View(svm);
        }

        public async Task< IActionResult> TumRandevular()
        {
            //claim based, role based'ten farklı olarak talep bazlı bir yöntemdir.
            string kullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier); //claim type nameidentifier ile id bulunabilir
            string rol = User.FindFirstValue(ClaimTypes.Role);
            var randevular = await _randevuRepo.RandevulariGetir(kullaniciId,rol);
            return View(randevular);
        }

        public RedirectToActionResult SepeteEkleArtir(int id)
        {
            var Poliklinik = _filmRepo.PoliklinikGetir(id);
            if (Poliklinik != null)
            {               
                _sepetRepo.SepeteEkle(Poliklinik);
            }
            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult SepettenCikarAzalt(int id)
        {
            var Poliklinik = _filmRepo.PoliklinikGetir(id);
            if (Poliklinik != null)
            {
                _sepetRepo.SepettenCikar(Poliklinik);
            }
            return RedirectToAction(nameof(Index));
        }

       public async Task<IActionResult> RandevuyuTamamla()
        {
            var urunler = _sepetRepo.SepeteEklenenler();
            //claim based, role based'ten farklı olarak talep bazlı bir yöntemdir.
            string kullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier); //claim type nameidentifier ile id bulunabilir
            string kullaniciEmail = User.FindFirstValue(ClaimTypes.Email);

           await _randevuRepo.RandevuyuKaydet(urunler, kullaniciId, kullaniciEmail);
           await _sepetRepo.SepetiBosalt();
            return View("RandevuTamamlandi");
        }
    }
}
