using HANGOSELL_KLTN.Models;
using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceController : Controller
    {
        private readonly OrderDetailCustomerService orderDetailCustomerService;
        private readonly CategoryService categoryService;
        private readonly OrderService orderService;
        private readonly CustomerService customerService;
        private readonly OrderDetailService orderDetailService;
        private readonly VietQRService _vietQRService;
        private readonly IConfiguration _configuration;
        private readonly InvoiceViewModel _invoiceViewModel;
        public InvoiceController(OrderDetailCustomerService orderDetailCustomerService, IOptions<InvoiceViewModel> invoiceViewModel,
            CategoryService categoryService, OrderService orderService, CustomerService customerService, OrderDetailService orderDetailService, VietQRService vietQRService, IConfiguration configuration)
        {
            this.orderDetailCustomerService = orderDetailCustomerService;
            this.categoryService = categoryService;
            this.orderService = orderService;
            this.customerService = customerService;
            this.orderDetailService = orderDetailService;
            _vietQRService = vietQRService;
            _configuration = configuration;
            _invoiceViewModel = invoiceViewModel.Value;
        }
        public IActionResult Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<Order> orders = orderService.GetAllorder();
            return View(orders);
        }

        public IActionResult CreateInvoice()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<OrderDetailCustomer> orderDetailCustomers = orderDetailCustomerService.GetAllOrderDetailCustomer();
            ViewData["TongTien"] = orderDetailCustomers.Sum(x => x.TotalPrice);
            List<ProductCategory> categories = categoryService.GetAllCategory();

            ModelDataset modelDataset = new ModelDataset()
            {
                orderDetailCustomers = orderDetailCustomers,
                categories = categories
            };
            return View(modelDataset);
        }

        public async Task<IActionResult> BillPaymentAsync(int idcustomer, int id)
        {
            // Lấy thông tin nhân viên từ session
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");

            // Lấy thông tin đơn hàng và khách hàng
            Order order = orderService.GetOrderByIdCustomer(idcustomer, id);
            Customer customer = customerService.GetCustomerById(idcustomer);

            // Lấy chi tiết đơn hàng
            List<OrderDetail> orderDetails = orderDetailService.GetOrderDetailByIdOrder(id);
            ViewData["TongTien"] = orderDetails.Sum(x => x.TotalPrice);

            decimal totalAmount = orderDetails.Sum(x => x.TotalPrice);

            // Tạo URL mã QR
            string qrCodeUrl = await _vietQRService.GenerateQRCodeAsync(totalAmount);

            // Tạo instance của InvoiceViewModel với dữ liệu cần thiết
            var invoiceViewModel = new InvoiceViewModel
            {
                AccountNo = _configuration["VietQR:AccountNo"], // Có thể lấy từ cấu hình
                AccountName = _configuration["VietQR:AccountName"], // Có thể lấy từ cấu hình
                Amount = totalAmount,
                Description = _configuration["VietQR:Description"], // Có thể lấy từ cấu hình
                QRCodeUrl = qrCodeUrl
            };

            // Tạo ModelDataset và truyền vào view
            var modelDataset = new ModelDataset
            {
                order = order,
                customer = customer,
                orderDetail = orderDetails,
                invoiceViewModel = invoiceViewModel
            };

            return View(modelDataset);
        }

        public IActionResult CreateTestInvoice()
        {
            return View(new InvoiceViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceTest(InvoiceViewModel model)
        {

            var qrCodeUrl = await _vietQRService.GenerateQRCodeAsync(model.Amount);

            model.AccountNo = _configuration["VietQR:AccountNo"];
            model.AccountName = _configuration["VietQR:AccountName"];
            model.Description = _configuration["VietQR:Description"];
            model.QRCodeUrl = qrCodeUrl;

            return View("Invoice", model);

        }
    }
}
