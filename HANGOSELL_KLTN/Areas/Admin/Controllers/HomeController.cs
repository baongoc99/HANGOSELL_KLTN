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
        private readonly OrderDetailService orderDetailService;

        public HomeController(CustomerService customerService, OrderService orderService, ProductService productService,
            OrderDetailService orderDetailService)
        {
            this.customerService = customerService;
            this.orderService = orderService;
            this.productService = productService;
            this.orderDetailService = orderDetailService;
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
            ViewData["tongproduct"] = productService.GetAllProduct().Count();



            return View();
        }


        public IActionResult Tongphantram()
        {
            List<OrderDetail> listorderdetel = orderDetailService.GetAllCategory();
            var locsptheoid = listorderdetel.GroupBy(od => od.ProductId)
                .Select(x => new
                {
                    productid = x.Key,
                    quantity = x.Sum(x => x.Quantity),
                }
                ).ToList();
            int tongsoluongmuaban = listorderdetel.Sum(muaproduct => muaproduct.Quantity);
            var phantramproduct = locsptheoid.Select(item => new
            {
                Products = productService.GetProductById(item.productid),
                phantramproduct = ((float)item.quantity / tongsoluongmuaban) * 100,
            })
                .OrderByDescending(p => p.phantramproduct).ToList();
            List<Object> result = new List<Object>();
            foreach (var item in phantramproduct)
            {
                item.Products.ProductCategory = null;
                Phantram phantram = new Phantram()
                {
                    product = item.Products,
                    tongdoanhthu = item.phantramproduct,
                };
                result.Add(phantram);
            }
            return Json(result);
        }

        private class Phantram
        {
            public Product product { get; set; }
            public float tongdoanhthu { get; set; }
        }

        public IActionResult Doanhthutheothang()
        {
            List<Order> orders = orderService.GetAllorder();

            var doanhthutheothang = orders.GroupBy(od => od.CreateDate.Month)
                .Select(g => new
                {
                    Thang = g.Key,
                    Tongdoanhthu = g.Sum(dt => dt.Total)
                }).ToList();
            List<object> result = new List<object>();
            foreach (var doanhthu in doanhthutheothang)
            {
                Doanhthuthangs doanhthuthangs = new Doanhthuthangs()
                {
                    Thang = doanhthu.Thang,
                    tongdoanhthu = (float)doanhthu.Tongdoanhthu,
                };
                result.Add(doanhthuthangs);
            }
            return Json(result);
        }

        private class Doanhthuthangs
        {
            public int Thang { get; set; }
            public float tongdoanhthu { get; set; }
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
