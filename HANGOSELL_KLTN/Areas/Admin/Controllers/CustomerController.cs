using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly CustomerService customerService;
        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<Customer> customers = customerService.GetAllCustomer();
            return View(customers);
        }

        public IActionResult GetAllKhachHang()
        {
            List<Customer> customerlist = customerService.GetAllCustomer();
            return Json(customerlist);
        }
        public IActionResult GetKhachHangById(int id)
        {
            Customer customer = customerService.GetCustomerById(id);
            return Json(customer);
        }
        public IActionResult CreateCustomer()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            return View();
        }

        public IActionResult Create(Customer customer)
        {
            customerService.AddCustomer(customer);
            return Redirect("/Admin/Customer");
        }
        public IActionResult CreateCustomersss(Customer customer)
        {
            customer.Password = "123456789";
            customerService.AddCustomer(customer);
            return Redirect("/Admin/Invoice/CreateInvoice");
        }

        public IActionResult EditCustomer(int id)
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            Customer customer = customerService.GetCustomerById(id);
            return View(customer);
        }

        public IActionResult Edit(Customer customer)
        {
            Customer customer1 = customerService.GetCustomerById(customer.Id);
            customer.Password = customer1.Password;
            customerService.UpdateCustomer(customer);
            return Redirect("/Admin/Customer");
        }

        public IActionResult Delete(int id)
        {
            customerService.DeleteCustomer(id);
            return Redirect("/Admin/Customer");
        }
    }
}
