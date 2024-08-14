using HANGOSELL_KLTN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HANGOSELL_KLTN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
