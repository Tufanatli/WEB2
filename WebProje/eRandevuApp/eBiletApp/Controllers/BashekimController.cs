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
    public class BashekimController : Controller
    {
        private readonly IBashekimRepository _repo;

        public BashekimController(IBashekimRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var bashekimler = await _repo.ListAll(); ;
            return View(bashekimler);

        }

        [HttpPost]
        public IActionResult Create(IFormFile file, [Bind("BashekimId,BashekimFotografi,BashekimAdSoyad,BashekimHakkinda")] Bashekim y)
        {
            //Bashekim resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Bashekimler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                y.BashekimFotografi = "~/images/Bashekimler/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {


                _repo.Add(y);
                return RedirectToAction(nameof(Index));

            }

            return View(y);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            var bashekim = _repo.GetById(id);

            if (bashekim == null)
            {
                return NotFound();
            }

            return View(bashekim);
        }

        public IActionResult Edit(int id)
        {

            var bashekim = _repo.GetById(id);
            if (bashekim == null)
            {
                return NotFound();
            }
            return View(bashekim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BashekimId,BashekimFotografi,BashekimAdSoyad,BashekimHakkinda")] Bashekim y, IFormFile file)
        {
            //Bashekim resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Bashekimler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
               y.BashekimFotografi = "~/images/Bashekimler/" + dosyaAdi;
            }

            if (id != y.BashekimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.Update(id, y);

                return RedirectToAction(nameof(Index));
            }
            return View(y);
        }

        public IActionResult Delete(int id)
        {

            var bashekim = _repo.GetById(id);
            if (bashekim == null)
            {
                return NotFound();
            }

            return View(bashekim);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bashekim = _repo.GetById(id);
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
