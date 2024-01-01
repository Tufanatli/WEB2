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
    public class HastaneController : Controller
    {
        private readonly IHastaneRepository _repo;
        public HastaneController(IHastaneRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var Hastaneler = await _repo.ListAll();
            return View(Hastaneler);
        }


        [HttpPost]
        public IActionResult Create(IFormFile file, [Bind("HastaneId,HastaneFotografi,HastaneAdi,HastaneHakkinda")] Hastane s)
        {
            //Hastane resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Hastaneler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                s.HastaneFotografi = "~/images/Hastaneler/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {


                _repo.Add(s);
                return RedirectToAction(nameof(Index));

            }

            return View(s);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            var Hastane = _repo.GetById(id);

            if (Hastane == null)
            {
                return NotFound();
            }

            return View(Hastane);
        }


        public IActionResult Edit(int id)
        {

            var Hastane = _repo.GetById(id);
            if (Hastane == null)
            {
                return NotFound();
            }
            return View(Hastane);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("HastaneId,HastaneFotografi,HastaneAdi,HastaneHakkinda")] Hastane s, IFormFile file)
        {
            //Hastane resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Hastaneler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                s.HastaneFotografi = "~/images/Hastaneler/" + dosyaAdi;
            }

            if (id != s.HastaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.Update(id, s);

                return RedirectToAction(nameof(Index));
            }
            return View(s);
        }


        public IActionResult Delete(int id)
        {

            var Hastane = _repo.GetById(id);
            if (Hastane == null)
            {
                return NotFound();
            }

            return View(Hastane);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Hastane = _repo.GetById(id);
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
