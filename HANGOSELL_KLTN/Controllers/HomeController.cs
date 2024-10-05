using HANGOSELL_KLTN.Models;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using HANGOSELL_KLTN.Service;

namespace HANGOSELL_KLTN.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProductService productService;
        public HomeController(ProductService productService)
        {

            this.productService = productService;
        }

        public IActionResult Index()
        {
            List<Product> products = productService.GetAllProduct();
            return View(products);
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
