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
        private readonly QRCodeRequestService _qRCodeRequestService;
        private readonly ProductService _productService;
        public InvoiceController(OrderDetailCustomerService orderDetailCustomerService, IOptions<InvoiceViewModel> invoiceViewModel,
            CategoryService categoryService, OrderService orderService,
            CustomerService customerService, OrderDetailService orderDetailService,
            QRCodeRequestService qRCodeRequestService,
            VietQRService vietQRService, IConfiguration configuration, ProductService productService)
        {
            this.orderDetailCustomerService = orderDetailCustomerService;
            this.categoryService = categoryService;
            this.orderService = orderService;
            this.customerService = customerService;
            this.orderDetailService = orderDetailService;
            _vietQRService = vietQRService;
            _configuration = configuration;
            _invoiceViewModel = invoiceViewModel.Value;
            _qRCodeRequestService = qRCodeRequestService;
            _productService = productService;
        }


        public async Task<IActionResult> QrLisst()
        {
            List<QRCodeRequest> QRCodeRequestService = await _qRCodeRequestService.GetAllAsync();
            return Ok(QRCodeRequestService);
        }

        public async Task<IActionResult> TaoMaQR(int IdQRCode)
        {
            QRCodeRequest qRCodeRequest = await _qRCodeRequestService.GetByIdAsync(IdQRCode);

            List<OrderDetailCustomer> orderDetailCustomer = orderDetailCustomerService.GetAllOrderDetailCustomer();
            decimal totalAmount = 0;

            // Dùng vòng lặp để tính tổng số tiền
            foreach (var orderDetail in orderDetailCustomer)
            {
                totalAmount += orderDetail.TotalPrice;
            }

            // Làm tròn số tiền

            // Chuyển đổi số tiền đã làm tròn thành chuỗi không có dấu phân cách
            string formattedAmount = totalAmount.ToString("0", System.Globalization.CultureInfo.InvariantCulture);

            string qrCodeUrl = await _vietQRService.GenerateQRCodeAsync(formattedAmount, qRCodeRequest.AccountNo, qRCodeRequest.AccountName, qRCodeRequest.AcqId);
            var payload = new
            {
                accountNo = qRCodeRequest.AccountNo,
                accountName = qRCodeRequest.AccountName,
                acqId = qRCodeRequest.AcqId,
                QRCodeUrl = qrCodeUrl
            };
            return Ok(payload);
        }




        public IActionResult Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<Order> orders = orderService.GetAllorder().OrderByDescending(o => o.CreateDate).ToList(); // Thay thế OrderDate bằng thuộc tính bạn muốn sắp xếp
            
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


            // Tạo ModelDataset và truyền vào view
            var modelDataset = new ModelDataset
            {
                order = order,
                customer = customer,
                orderDetail = orderDetails,
            };

            return View(modelDataset);
        }


        public IActionResult DetailInvoice(int id)
        {
            List<OrderDetail> orderDetails = orderDetailService.GetOrderDetailByIdOrder(id);
            List<ModelDataset> modelDatasets = new List<ModelDataset>();
            foreach (var orderDetail in orderDetails)
            {
                orderDetail.Order = null;
                orderDetail.Product = null;
                Product product = _productService.GetProductById(orderDetail.ProductId);
                product.ProductCategory = null;
                ModelDataset modelDataset = new ModelDataset
                {
                    orderDetal = orderDetail,
                    product = product,
                };
                modelDatasets.Add(modelDataset);
            }
            return View(modelDatasets);
        }

        public IActionResult CreateTestInvoice()
        {
            return View(new InvoiceViewModel());
        }

        //    [HttpPost]
        //    public async Task<IActionResult> CreateInvoiceTest(InvoiceViewModel model)
        //    {

        //        var qrCodeUrl = await _vietQRService.GenerateQRCodeAsync(model.Amount);

        //        model.AccountNo = _configuration["VietQR:AccountNo"];
        //        model.AccountName = _configuration["VietQR:AccountName"];
        //        model.Description = _configuration["VietQR:Description"];
        //        model.QRCodeUrl = qrCodeUrl;

        //        return View("Invoice", model);

        //}
    }
}
