using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly OrderDetailService orderDetailService;
        private readonly ProductService productService;
        private readonly CustomerService customerService;
        private readonly OrderDetailCustomerService orderDetailCustomerService;
        private readonly PaymentService paymentService;
        public OrderController(OrderService orderService,
            OrderDetailService orderDetailService,
            ProductService productService,
            CustomerService customerService,
            OrderDetailCustomerService orderDetailCustomerService,
            PaymentService paymentService)
        {
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.productService = productService;
            this.customerService = customerService;
            this.orderDetailCustomerService = orderDetailCustomerService;
            this.paymentService = paymentService;
        }


        public ActionResult Addorderdetals(int idproduct)
        {

            OrderDetailCustomer check = orderDetailCustomerService.GetOrderDetailCustomerByIdproduct(idproduct);
            Product product = productService.GetProductById(idproduct);
            if (check == null)
            {
                OrderDetailCustomer orderDetailCustomer = new OrderDetailCustomer();
                orderDetailCustomer.ProductId = idproduct;
                orderDetailCustomer.Quantity = 1;
                orderDetailCustomer.TotalPrice = product.Price * orderDetailCustomer.Quantity;
                orderDetailCustomerService.AddOrderDetailCustomer(orderDetailCustomer);
                /// update số lượng
                product.Quantity -= 1;
                productService.UpdateProduct(product);
                return Redirect("/admin/invoice/CreateInvoice");

            }
            else
            {
                check.Quantity += 1;
                check.TotalPrice = product.Price * check.Quantity;
                orderDetailCustomerService.UpdateOrderDetailCustomer(check);
                product.Quantity -= 1;
                productService.UpdateProduct(product);
                return Redirect("/admin/invoice/CreateInvoice");

            }
        }
        public IActionResult DeleteorderDetailCustomer(int id, int idproduct)
        {
            OrderDetailCustomer orderDetailCustomer = orderDetailCustomerService.GetOrderDetailCustomerById(id);
            Product product = productService.GetProductById(idproduct);
            product.Quantity = orderDetailCustomer.Quantity + product.Quantity;
            productService.UpdateProduct(product);
            orderDetailCustomerService.DeleteOrderDetailCustomers(id);
            return Redirect("/admin/invoice/CreateInvoice");
        }
        public string GenerateOrderCode()
        {
            // Giả sử bạn $ã có danh sách các mã $ơn hàng hiện tại
            var lastOrder = orderService.GetCode();

            int nextNumber;
            if (lastOrder != null)
            {
                // Lấy số từ mã cuối cùng
                string lastCode = lastOrder.Code.Substring(2); // Loại bỏ "HD"
                nextNumber = int.Parse(lastCode) + 1; // Tăng lên 1
            }
            else
            {
                nextNumber = 100; // Bắt $ầu từ 100 nếu không có mã nào trước $ó
            }

            // Tạo mã mới với tiền tố "HD" và $ịnh dạng "00000" (thêm số 0 phía trước nếu cần)
            string newOrderCode = "HD" + nextNumber.ToString("D5");

            return newOrderCode;
        }

        public IActionResult ThanhToan(Customer customer)
        {
            if (customer.CompanyName != null)
            {
                customer.CompanyName = customer.CompanyName.ToString();
            }
            else
            {
                customer.CompanyName = "Khách lẻ";
            }
            /// nếu khách hàng (lER)
            Customer customer1 = customerService.GetCustomerById(customer.Id);
            customer.ContactPerson = customer1.ContactPerson;
            if (customer.CompanyName != null)
            {
                customer.CompanyName = customer1.CompanyName;
            }
            else
            {
                customer.CompanyName = "Khách lẻ";
            }
            customer.Email = customer1.Email;
            customer.PhoneNumber = customer1.PhoneNumber;
            customer.Address = customer1.Address;
            customer.Password = customer1.Password;
            customer.ModifiedDate = DateTime.Now;
            List<OrderDetailCustomer> orderDetailCustomer = orderDetailCustomerService.GetAllOrderDetailCustomer();
            decimal total = orderDetailCustomer.Sum(o => o.TotalPrice);
            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.Address = customer1.Address;
            order.Code = GenerateOrderCode();
            order.CustomerId = customer1.Id;
            order.Status = "Đã hoàn thành";
            order.Total = total;
            order.Quantity = 1;
            order.Phone = customer1.PhoneNumber;
            order.StartDatetime = DateTime.Now;
            int idorder = orderService.AddCOrder(order);
            foreach (var orderdetal in orderDetailCustomer)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = orderdetal.Quantity,
                    TotalPrice = orderdetal.TotalPrice,
                    StartDattetime = DateTime.Now,
                    OrderId = idorder,
                    ProductId = orderdetal.ProductId
                };

                orderDetailService.AddCOrder(orderDetail);
                orderDetailCustomerService.DeleteOrderDetailCustomers(orderdetal.Id);
            }
            Payment payment = new Payment
            {
                PaymentDate = DateTime.Now,
                Amount = total,
                OrderId = idorder,
                PaymentMethod = "",
                EmployeeId = HttpContext.Session.GetInt32("Id").Value
            };
            paymentService.AddCPayment(payment);
            return Redirect($"/admin/invoice/BillPayment/?idcustomer={customer1.Id}&id={idorder}");
        }
        public IActionResult updatedatdat(int id)
        {
            Order order = orderService.GetOrderById(id);
            order.Status = "Đang giao hàng";
            orderService.UpdateCategory(order);
            return Redirect($"/admin/invoice");
        }
        public IActionResult updategiaohang(int id)
        {
            Order order = orderService.GetOrderById(id);
            order.Status = "Đã giao";
            orderService.UpdateCategory(order);
            return Redirect($"/admin/invoice");
        }
    }
}
