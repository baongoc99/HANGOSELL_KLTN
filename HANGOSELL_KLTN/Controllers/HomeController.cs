using HANGOSELL_KLTN.Models;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;

namespace HANGOSELL_KLTN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        //public IActionResult SetLanguage(string language)
        //{
        //    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
        //    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)),
        //    new CookieOptions()
        //    {
        //        Expires = DateTimeOffset.UtcNow.AddYears(1)
        //    });

        //    return Redirect(Request.Headers["Referer"].ToString());
        //} 

    }
}
