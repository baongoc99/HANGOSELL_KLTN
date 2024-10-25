using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HANGOSELL_KLTN.Controllers
{
    public class ShopController : Controller
    {
        private readonly StoreService storeService;
        private readonly ProductService productService;
        private readonly ApplicationDbContext _context;

        public ShopController(StoreService storeService, ProductService productService, ApplicationDbContext applicationDbContext)
        {
            this.storeService = storeService;
            this.productService = productService;
            this._context = applicationDbContext;
        }
        public async Task<IActionResult> ContactUs()
        {
            Store store = await storeService.GetStoreAsync();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;
            return View();
        }
        public async Task<IActionResult> DetailProduct(int id)
        {
            Store store = await storeService.GetStoreAsync();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;

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


            Product product = productService.GetProductById(id);


            return View(product);
        }
        public async Task<IActionResult> ListProduct(int idcategory, string name, string sortOrder)
        {
            Store store = await storeService.GetStoreAsync();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;
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
            List<ProductCategory> listProductcategory = _context.ProductCategories.ToList();

            List<ModelDataset> ListModelDataset = new List<ModelDataset>();

            List<Product> products = new List<Product>();

            if (idcategory > 0)
            {
                products = _context.Products.Where(p => p.ProductCategoryId == idcategory).ToList();
            }
            else
            {
                products = productService.GetAllProducts();
            }
            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder == "asc")
                {
                    products = products.OrderBy(p => p.Price).ToList(); // Giá từ thấp $ến cao
                }
                else if (sortOrder == "desc")
                {
                    products = products.OrderByDescending(p => p.Price).ToList(); // Giá từ cao $ến thấp
                }
            }
            ViewData["tongproduct"] =products.Count;
            ModelDataset modelDataset = new ModelDataset()
            {
                categories = listProductcategory,
                products = products
            };
            ListModelDataset.Add(modelDataset);


            return View(ListModelDataset);
        }
    }
}
