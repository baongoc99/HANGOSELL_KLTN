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
            List<Customer> customers = customerService.GetAllCustomer();
            return View(customers);
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        public IActionResult Create(Customer customer)
        {
            customerService.AddCustomer(customer);
            return Redirect("/Admin/Customer");
        }

        public IActionResult EditCustomer(int id)
        {
            Customer customer = customerService.GetCustomerById(id);
            return View(customer);
        }

        public IActionResult Edit(Customer customer)
        {
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
