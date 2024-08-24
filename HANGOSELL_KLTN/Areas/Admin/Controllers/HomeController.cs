using HANGOSELL_KLTN.Models.EF;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["CodeEmployee"] = HttpContext.Session.GetString("CodeEmployee");
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["DateOfBirth"] = HttpContext.Session.GetString("DateOfBirth");
            ViewData["JoinDate"] = HttpContext.Session.GetString("JoinDate");
            ViewData["PhoneNumber"] = HttpContext.Session.GetString("PhoneNumber");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
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
        //public IActionResult SetLanguage(LanguageViewModel language)
        //{
        //    if (string.IsNullOrEmpty(language.Lang))
        //    {
        //        throw new ArgumentException("Lang cannot be null or empty.", nameof(language.Lang));
        //    }

        //    Response.Cookies.Append(
        //        CookieRequestCultureProvider.DefaultCookieName,
        //        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language.Lang)),
        //        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        //    );

        //    var returnUrl = language.ReturnUrl ?? Url.Action("Index", "Home");
        //    return Redirect(returnUrl);

    }
}
