using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private readonly StoreService _storeService;
        private readonly BankAccountService _bankAccountService; // Dịch vụ tài khoản ngân hàng


        public StoreController(StoreService storeService, BankAccountService bankAccountService)
        {
            _storeService = storeService;
            _bankAccountService = bankAccountService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");

            var store = await _storeService.GetStoreAsync();
            List<QRCodeRequest> bankAccounts = _bankAccountService.GetAllBankAccounts(); // Lấy danh sách tài khoản ngân hàng


            var model = new ModelDataset
            {
                store = store ?? new Store(), // Khởi tạo đối tượng Store nếu null
                qRCodeRequests = bankAccounts
            };

            return View(model);
        }


        public IActionResult EditorAddStore(Store store, IFormFile Logo, int Id)
        {
            if (Id > 0)
            {
                Store store1 = _storeService.GetStoreById(Id);
                if (store1 != null)
                {
                    store1.Logo = SaveImage(Logo);
                    store1.Email = store.Email;
                    store1.PhoneNumber = store.PhoneNumber;
                    store1.Address = store.Address;
                    store1.StoreName = store.StoreName;
                    _storeService.UpdateStore(store1);
                }
            }
            else
            {
                store.Logo = SaveImage(Logo);
                _storeService.CreateStore(store);
            }
            return RedirectToAction("Index");
        }
        private string SaveImage(IFormFile image)
        {
            if (image != null)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    throw new InvalidOperationException("Invalid image file type");
                }

                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                return Path.Combine("images", uniqueFileName).Replace("\\", "/");
            }
            return "images/default.jpg";
        }
    }
}
