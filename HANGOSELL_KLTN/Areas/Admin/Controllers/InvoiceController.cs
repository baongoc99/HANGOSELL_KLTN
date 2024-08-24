using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public InvoiceController(OrderDetailCustomerService orderDetailCustomerService,
            CategoryService categoryService, OrderService orderService, CustomerService customerService, OrderDetailService orderDetailService)
        {
            this.orderDetailCustomerService = orderDetailCustomerService;
            this.categoryService = categoryService;
            this.orderService = orderService;
            this.customerService = customerService;
            this.orderDetailService = orderDetailService;
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

        public IActionResult BillPayment(int idcustomer, int id)
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            Order orderss = orderService.GetOrderByIdCustomer(idcustomer, id);
            Customer customer = customerService.GetCustomerById(idcustomer);

            List<OrderDetail> orderDetails = orderDetailService.GetOrderDetailByIdOrder(id);
            ViewData["TongTien"] = orderDetails.Sum(x => x.TotalPrice);
            ModelDataset modelDataset = new ModelDataset()
            {
                order = orderss,
                customer = customer,
                orderDetail = orderDetails,
            };
            return View(modelDataset);
        }
    }
}
