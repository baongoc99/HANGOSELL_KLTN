using HANGOSELL_KLTN.Models;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Localization;
using HANGOSELL_KLTN.Service;
using Microsoft.EntityFrameworkCore;
using HANGOSELL_KLTN.Data;

namespace HANGOSELL_KLTN.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProductService productService;
        private readonly ApplicationDbContext _context;
        private readonly StoreService storeService;
        private Task<Store> store;

        public HomeController(ProductService productService, ApplicationDbContext _context, StoreService storeService)
        {

            this.productService = productService;
            this._context = _context;
            this.storeService = storeService;
        }

        public IActionResult Index(string name)
        {
            List<ModelDataset> modelDatasetList = new List<ModelDataset>();

            List<Product> products = new List<Product>();
            if (name !=null) // Kiểm tra nếu có từ khóa tìm kiếm
            {
                products = productService.GetAllProduct().Where(p => p.Title == name).ToList();
            }
            else
            {
                products = productService.GetAllProduct();
            }
            int? CustomerId = HttpContext.Session.GetInt32("Id");
            float tongtien = 0;
            int soluong = 0;

            if (CustomerId > 0)
            {
                List<CartItem> cartItems = _context.CartItems.Where(item => item.CustomerId == CustomerId).ToList();
                foreach (CartItem cartItem in cartItems)
                {
                    cartItem.Customer = null;
                    tongtien += (float)(cartItem.quantity * cartItem.productPrice);
                    soluong += cartItem.quantity;
                }
            }
            ViewData["tongtien"] = tongtien;
            ViewData["soluong"] = soluong;
            List<ProductCategory> productsCategory = _context.ProductCategories.ToList();
            ModelDataset pc = new ModelDataset
            {
                products = products,
                categories = productsCategory
            };
            modelDatasetList.Add(pc);
            Store store =  storeService.GetStore();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;
            ViewData["ContactPerson"] = HttpContext.Session.GetString("ContactPerson");
            return View(modelDatasetList);
        }
        public async Task<IActionResult> Cart()
        {
            Store store = await storeService.GetStoreAsync();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;
            return View();
        }
        public async Task LoadStoreInfoAsync()
        {
            Store store = await storeService.GetStoreAsync();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;
        }
    }

}
