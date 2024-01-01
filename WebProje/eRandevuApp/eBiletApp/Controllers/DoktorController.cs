using eRandevuApp.Data;
using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eRandevuApp.Controllers
{
    [Authorize(Roles = Roller.Admin)]
    public class DoktorController : Controller
    {

        private readonly IDoktorRepository _repo;

        public DoktorController(IDoktorRepository repo)
        {
            _repo = repo;
        }
        [AllowAnonymous]
        public async  Task<IActionResult> Index()
        {
            var Doktorlar = await _repo.ListAll();
            return View(Doktorlar);
        }

        [HttpPost]
        public  IActionResult Create(IFormFile file,[Bind("DoktorId,DoktorFotografi,DoktorAdSoyad,DoktorHakkinda")] doktor o)
        { 
            //doktor resmini upload etmek için
            if (file!=null&&file.Length > 0)
            {
                    string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Doktorlar"));
                    using(var fileStream=new FileStream(Path.Combine(path,dosyaAdi),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    o.DoktorFotografi = "~/images/Doktorlar/"+ dosyaAdi;
            }

            if (ModelState.IsValid)
            {     
               
                
                    _repo.Add(o);
                    return RedirectToAction(nameof(Index));
                
            }

            return View(o);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            var doktor =  _repo.GetById(id);
                
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        public  IActionResult Edit(int id)
        {

            var doktor = _repo.GetById(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DoktorId,DoktorFotografi,DoktorAdSoyad,DoktorHakkinda")] doktor o, IFormFile file)
        {
            //doktor resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Doktorlar"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                o.DoktorFotografi = "~/images/Doktorlar/" + dosyaAdi;
            }

            if (id != o.DoktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {               
                _repo.Update(id, o);
                
                return RedirectToAction(nameof(Index));
            }
            return View(o);
        }


        
        public IActionResult Delete(int id)
        {

            var doktor = _repo.GetById(id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var doktor = _repo.GetById(id);
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
