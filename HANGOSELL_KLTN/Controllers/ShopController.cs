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
        public ShopController(StoreService storeService)
        {
            this.storeService = storeService;
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
        public async Task<IActionResult> DetailProduct()
        {
            Store store = await storeService.GetStoreAsync();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;
            return View();
        }
        public async Task<IActionResult> ListProduct()
        {
            Store store = await storeService.GetStoreAsync();
            ViewData["emailstore"] = store.Email;
            ViewData["logo"] = store.Logo;
            ViewData["PhoneNumber"] = store.PhoneNumber;
            ViewData["Address"] = store.Address;
            return View();
        }
    }
}
