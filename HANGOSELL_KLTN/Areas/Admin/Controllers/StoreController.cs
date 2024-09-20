using HANGOSELL_KLTN.Models.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private readonly StoreService _storeService;

        public StoreController(StoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");

            var store = await _storeService.GetStoreAsync();
            var qRCodeRequest = await _storeService.GetQRCodeRequestAsync() ?? new QRCodeRequest();

            var model = new ModelDataset
            {
                store = store ?? new Store(), // Khởi tạo đối tượng Store nếu null
                qRCodeRequest = qRCodeRequest
            };

            return View(model);
        }
        public async Task<IActionResult> EditStore(Store model, IFormFile logo)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả về trang chỉnh sửa với các lỗi
                return View("Index", new ModelDataset { store = await _storeService.GetStoreAsync() });
            }

            var result = await _storeService.UpdateStoreAsync(model, logo);
            if (!result)
            {
                // Nếu không cập nhật thành công, chuyển hướng hoặc trả về lỗi
                return NotFound();
            }

            // Sau khi lưu thành công, chuyển hướng hoặc trả về trang nào đó
            return RedirectToAction("Index");
        }
    }
}
