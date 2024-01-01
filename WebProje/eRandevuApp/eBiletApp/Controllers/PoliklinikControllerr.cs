using eRandevuApp.Data;
using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Controllers
{
    [Authorize(Roles =Roller.Admin)]
    public class PoliklinikController : Controller
    {
        private readonly IPoliklinikRepository _repo;
        public PoliklinikController(IPoliklinikRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var poliklinikler = await _repo.ListAll(m => m.Hastane);
            return View(poliklinikler);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            var Poliklinik = _repo.PoliklinikGetir(id);

            if (Poliklinik == null)
            {
                return NotFound();
            }

            return View(Poliklinik);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            //Poliklinik eklenirken seçilmesi gereken Hastane,doktor,bashekim listeleri
            var poliklinikVerileri = await _repo.poliklinikVerileri();
            ViewData["HastaneId"] = new SelectList(poliklinikVerileri.Hastaneler, "HastaneId", "HastaneAdi");
            ViewData["DoktorId"] = new SelectList(poliklinikVerileri.Doktorlar, "DoktorId", "DoktorAdSoyad");
            ViewData["BashekimId"] = new SelectList(poliklinikVerileri.Bashekimler, "BashekimId", "BashekimAdSoyad");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, HastaneVM Poliklinik)
        {
            var poliklinikVerileri = await _repo.poliklinikVerileri();
            ViewData["HastaneId"] = new SelectList(poliklinikVerileri.Hastaneler, "HastaneId", "HastaneAdi");
            ViewData["DoktorId"] = new SelectList(poliklinikVerileri.Doktorlar, "DoktorId", "DoktorAdSoyad");
            ViewData["BashekimId"] = new SelectList(poliklinikVerileri.Bashekimler, "BashekimId", "BashekimAdSoyad");


            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/poliklinikler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
               Poliklinik.PoliklinikFotografi = "~/images/poliklinikler/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {

                await _repo.PoliklinikEkle(Poliklinik);

                return RedirectToAction(nameof(Index));
            }
            
            return View(Poliklinik);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var Poliklinik =  _repo.PoliklinikGetir(id);

            var poliklinikSon = new HastaneVM();
            poliklinikSon.PoliklinikId = Poliklinik.PoliklinikId;
            poliklinikSon.PoliklinikAdi = Poliklinik.PoliklinikAdi;
            poliklinikSon.RandevuBaslamaSaati1 = Poliklinik.RandevuBaslamaSaati1;
            poliklinikSon.RandevuBaslamaSaati2 = Poliklinik.RandevuBaslamaSaati2;
            poliklinikSon.RandevuBaslamaSaati3 = Poliklinik.RandevuBaslamaSaati3;
            poliklinikSon.PoliklinikFotografi = Poliklinik.PoliklinikFotografi;
            poliklinikSon.PoliklinikHakkinda = Poliklinik.PoliklinikHakkinda;
            poliklinikSon.AnaBilimDali = Poliklinik.AnaBilimDali;
            poliklinikSon.FilmUcreti = Poliklinik.FilmUcreti;
            poliklinikSon.DoktorListesi = Poliklinik.PolikliniklerDoktorlar.Select(m => m.DoktorId).ToList();
            poliklinikSon.HastaneId = Poliklinik.HastaneId;
            poliklinikSon.BashekimId = Poliklinik.BashekimId;


            var poliklinikVerileri = await _repo.poliklinikVerileri();
            ViewData["HastaneId"] = new SelectList(poliklinikVerileri.Hastaneler, "HastaneId", "HastaneAdi");
            ViewData["DoktorId"] = new SelectList(poliklinikVerileri.Doktorlar, "DoktorId", "DoktorAdSoyad");
            ViewData["BashekimId"] = new SelectList(poliklinikVerileri.Bashekimler, "BashekimId", "BashekimAdSoyad");
            return View(poliklinikSon);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, HastaneVM Poliklinik, int id)
        {
            var poliklinikVerileri = await _repo.poliklinikVerileri();
            ViewData["HastaneId"] = new SelectList(poliklinikVerileri.Hastaneler, "HastaneId", "HastaneAdi");
            ViewData["DoktorId"] = new SelectList(poliklinikVerileri.Doktorlar, "DoktorId", "DoktorAdSoyad");
            ViewData["BashekimId"] = new SelectList(poliklinikVerileri.Bashekimler, "BashekimId", "BashekimAdSoyad");


            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/poliklinikler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                Poliklinik.PoliklinikFotografi = "~/images/poliklinikler/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {

                await _repo.PoliklinikGuncelle(Poliklinik);

                return RedirectToAction(nameof(Index));
            }

            return View(Poliklinik);
        }

        public IActionResult Delete(int id)
        {
            var Poliklinik = _repo.PoliklinikGetir(id);
            if (Poliklinik == null)
            {
                return NotFound();
            }

            return View(Poliklinik);

        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Poliklinik = _repo.GetById(id);
            _repo.Delete(id); //id'ye göre bulunan filmi, filmrepository'deki delete metodunun içindeki remove'a vererek silme işlemi gerçekleştirir. 
            return RedirectToAction(nameof(Index));

        }

        [AllowAnonymous]
        public async Task<IActionResult> AramaSonucu(string arananPoliklinik)
        {
            var poliklinikler = await  _repo.ListAll(m => m.Hastane);
            if (string.IsNullOrEmpty(arananPoliklinik) == true) 
                return View("Index", poliklinikler);


             var sonuc = poliklinikler.Where(m => m.PoliklinikAdi.Contains(arananPoliklinik)).ToList();
            return View("Index", sonuc);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult MultiLang(string culture,string url)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(url);
        }

    }
}
