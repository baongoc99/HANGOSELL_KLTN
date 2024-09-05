using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly CustomerService customerService;
        private readonly OrderService orderService;
        private readonly ProductService productService;

        public HomeController(CustomerService customerService, OrderService orderService, ProductService productService)
        {
            this.customerService = customerService;
            this.orderService = orderService;
            this.productService = productService;
        }
        public IActionResult Index()
        {
            ViewData["CodeEmployee"] = HttpContext.Session.GetString("CodeEmployee");
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["DateOfBirth"] = HttpContext.Session.GetString("DateOfBirth");
            ViewData["JoinDate"] = HttpContext.Session.GetString("JoinDate");
            ViewData["PhoneNumber"] = HttpContext.Session.GetString("PhoneNumber");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");


            ViewData["tongcustomer"] = customerService.GetAllCustomer().Count();
            ViewData["tongdoanhthu"] = orderService.GetAllorder().Sum(x => x.Total);
            ViewData["tongorder"] = orderService.GetAllorder().Count();
            ViewData["tongproduct"]= productService.GetAllProduct().Count();

            return View();
        }


        public IActionResult SetLanguage(string language)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)),
            new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });

            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
