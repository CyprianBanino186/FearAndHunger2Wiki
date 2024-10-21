using Microsoft.AspNetCore.Mvc;
using FearAndHunger2Wiki.Models;
using FearAndHunger2Wiki.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FearAndHunger2Wiki.Controllers
{
    public class ArtykulyController : Controller
    {
        private readonly JsonFileArtykulyRepository _artykułyRepository;
        private readonly JsonFilePostaciRepository _postaciRepository;

        public ArtykulyController()
        {
            var artykulyFilePath = Path.Combine(Directory.GetCurrentDirectory(), "artykuly.json");
            _artykułyRepository = new JsonFileArtykulyRepository(artykulyFilePath);

            var postaciFilePath = Path.Combine(Directory.GetCurrentDirectory(), "postaci.json");
            _postaciRepository = new JsonFilePostaciRepository(postaciFilePath);
        }

        public IActionResult Index()
        {
            var artykuly = _artykułyRepository.GetArtykuly();
            return View(artykuly);
        }

        public IActionResult Create()
        {
            return View(new Artykul());
        }

        [HttpPost]
        public IActionResult Create(Artykul artykul)
        {
            if (ModelState.IsValid)
            {
                var artykuly = _artykułyRepository.GetArtykuly();
                artykul.Id = artykuly.Any() ? artykuly.Max(a => a.Id) + 1 : 1; // Przypisz nowe ID
                artykuly.Add(artykul);
                _artykułyRepository.SaveArtykuly(artykuly);
                return RedirectToAction("Index");
            }
            return View(artykul);
        }

        public IActionResult Edit(int id)
        {
            var artykuly = _artykułyRepository.GetArtykuly();
            var artykul = artykuly.FirstOrDefault(a => a.Id == id);
            if (artykul == null)
            {
                return NotFound();
            }
            return View(artykul);
        }

        [HttpPost]
        public IActionResult Edit(Artykul artykul)
        {
            if (ModelState.IsValid)
            {
                var artykuly = _artykułyRepository.GetArtykuly();
                var index = artykuly.FindIndex(a => a.Id == artykul.Id);
                if (index >= 0)
                {
                    artykuly[index] = artykul; // Zaktualizuj artykuł
                    _artykułyRepository.SaveArtykuly(artykuly);
                    return RedirectToAction("Index");
                }
            }
            return View(artykul);
        }

        public IActionResult Delete(int id)
        {
            var artykuly = _artykułyRepository.GetArtykuly();
            var artykul = artykuly.FirstOrDefault(a => a.Id == id);
            if (artykul == null)
            {
                return NotFound();
            }
            return View(artykul);
        }

        [HttpPost]
        public IActionResult Delete(Artykul artykul)
        {
            var artykuly = _artykułyRepository.GetArtykuly();
            var updatedArtykuly = artykuly.Where(a => a.Id != artykul.Id).ToList(); // Usunięcie artykułu
            _artykułyRepository.SaveArtykuly(updatedArtykuly);

            // Usuwanie powiązanej postaci
            var postaci = _postaciRepository.GetPostaci();
            var updatedPostaci = postaci.Where(p => p.Id != artykul.Id).ToList(); // Usuwanie postaci
            _postaciRepository.SavePostaci(updatedPostaci);

            return RedirectToAction("Index");
        }
    }
}
