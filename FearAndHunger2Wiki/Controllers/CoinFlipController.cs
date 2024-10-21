using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class CoinFlipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
