using Microsoft.AspNetCore.Mvc;
using FearAndHunger2Wiki.Models;

namespace FearAndHunger2Wiki.Controllers
{
    public class UzytkownicyController : Controller
    {
        public IActionResult Rejestracja()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rejestracja(Uzytkownik uzytkownik)
        {
            // Logika rejestracji użytkownika
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logowanie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logowanie(Uzytkownik uzytkownik)
        {
            // Logika logowania użytkownika
            return RedirectToAction("Index", "Home");
        }
    }
}
