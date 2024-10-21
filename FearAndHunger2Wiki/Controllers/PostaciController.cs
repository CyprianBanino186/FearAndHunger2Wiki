using Microsoft.AspNetCore.Mvc;
using FearAndHunger2Wiki.Models;
using FearAndHunger2Wiki.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FearAndHunger2Wiki.Controllers
{
    public class PostaciController : Controller
    {
        private readonly JsonFilePostaciRepository _postaciRepository;

        public PostaciController(JsonFilePostaciRepository postaciRepository)
        {
            _postaciRepository = postaciRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Postac postac)
        {
            var postaci = _postaciRepository.GetPostaci();
            postac.Id = postaci.Count > 0 ? postaci.Max(p => p.Id) + 1 : 1;
            postaci.Add(postac);
            _postaciRepository.SavePostaci(postaci);
            return RedirectToAction("Show", new { id = postac.Id });
        }

        public IActionResult Show(int id)
        {
            var postaci = _postaciRepository.GetPostaci();
            var postac = postaci.FirstOrDefault(p => p.Id == id);
            return View(postac);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var postaci = _postaciRepository.GetPostaci();
            var updatedPostaci = postaci.Where(p => p.Id != id).ToList();
            _postaciRepository.SavePostaci(updatedPostaci);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var postaci = _postaciRepository.GetPostaci();
            var postac = postaci.FirstOrDefault(p => p.Id == id);
            if (postac == null)
            {
                return NotFound();
            }
            return View(postac);
        }

        [HttpPost]
        public IActionResult Edit(Postac postac)
        {
            if (ModelState.IsValid)
            {
                var postaci = _postaciRepository.GetPostaci();
                var existingPostac = postaci.FirstOrDefault(p => p.Id == postac.Id);

                if (existingPostac != null)
                {
                    existingPostac.Imie = postac.Imie;
                    existingPostac.Wiek = postac.Wiek;
                    existingPostac.Alias = postac.Alias;
                    existingPostac.Krewni = postac.Krewni;
                    existingPostac.MiejsceUrodzenia = postac.MiejsceUrodzenia;
                    existingPostac.RokUrodzenia = postac.RokUrodzenia;
                    existingPostac.Fabula = postac.Fabula;
                    existingPostac.Lokacja = postac.Lokacja;
                    existingPostac.Rekrutowanie = postac.Rekrutowanie;
                    existingPostac.Obrazek = postac.Obrazek;
                    existingPostac.Obrazek2 = postac.Obrazek2;
                    existingPostac.StatyText = postac.StatyText;
                    existingPostac.StatAtak = postac.StatAtak;
                    existingPostac.StatObrona = postac.StatObrona;
                    existingPostac.StatMAtak = postac.StatMAtak;
                    existingPostac.StatMObrona = postac.StatMObrona;
                    existingPostac.StatZwinność = postac.StatZwinność;
                    existingPostac.StatSzczęście = postac.StatSzczęście;

                    _postaciRepository.SavePostaci(postaci);
                    return RedirectToAction("Show", new { id = postac.Id });
                }
            }
            return View(postac);
        }

        public IActionResult Index()
        {
            var postaci = _postaciRepository.GetPostaci();
            return View(postaci);
        }
    }
}
