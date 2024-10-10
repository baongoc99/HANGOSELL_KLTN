using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HANGOSELL_KLTN.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        private readonly OrderService orderService;
        private readonly StoreService storeService;

        private readonly OrderDetailService orderDetailService;
        private readonly ProductService productService;
        private readonly CustomerService customerService;
        public CartController(IHttpContextAccessor httpContextAccessor, ApplicationDbContext applicationDbContext,
            OrderService orderService,
            OrderDetailService orderDetailService,
            ProductService productService,
            CustomerService customerService,
            StoreService storeService)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = applicationDbContext;
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.productService = productService;
            this.customerService = customerService;
            this.storeService = storeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListCart()
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                int CustomerId = HttpContext.Session.GetInt32("Id").Value;
                List<CartItem> cartItems = _context.CartItems.Where(item => item.CustomerId == CustomerId).ToList();
                float tongtien = 0;
                int soluong = 0;
                foreach (CartItem cartItem in cartItems)
                {
                    cartItem.Customer = null;
                    tongtien += (float)(cartItem.quantity * cartItem.productPrice);
                    soluong += cartItem.quantity;
                }

                ViewData["tongtien"] = tongtien;
                ViewData["soluong"] = soluong;
                Store store = await storeService.GetStoreAsync();
                ViewData["emailstore"] = store.Email;
                ViewData["logo"] = store.Logo;
                ViewData["PhoneNumber"] = store.PhoneNumber;
                ViewData["Address"] = store.Address;
                ViewData["ContactPerson"] = HttpContext.Session.GetString("ContactPerson");

                return View(cartItems);
            }
            else
            {
                return Redirect($"/login");

            }
        }


        [HttpGet]
        public IActionResult GetCartItemsJson()
        {
            List<CartItem> cartItems = GetCartItems();
            return Json(cartItems);
        }
        private List<CartItem> GetCartItems()
        {
            var cartItemsJson = _httpContextAccessor.HttpContext.Session.GetString("CartItems");

            List<CartItem> cartItemList = new List<CartItem>();

            if (!string.IsNullOrEmpty(cartItemsJson))
            {
                cartItemList = JsonSerializer.Deserialize<List<CartItem>>(cartItemsJson);
            }

            return cartItemList;
        }
        private void SaveCartItems(List<CartItem> cartItems)
        {
            var serializedCartItems = JsonSerializer.Serialize(cartItems);
            _httpContextAccessor.HttpContext.Session.SetString("CartItems", serializedCartItems);
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, string productName, decimal price, int quantitys, string anhsps)
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                int CustomerId = HttpContext.Session.GetInt32("Id").Value;

                // Lấy danh sách các sản phẩm hiện có trong giỏ hàng từ database
                List<CartItem> cartItems = _context.CartItems.ToList();

                // Kiểm tra xem sản phẩm đã có trong giỏ hàng hay chưa
                var existingItem = cartItems.FirstOrDefault(item => item.productId == productId && item.CustomerId == CustomerId);

                if (existingItem != null)
                {
                    // Nếu sản phẩm đã tồn tại, cập nhật số lượng và giá
                    existingItem.quantity += quantitys;
                    // Cập nhật lại sản phẩm trong cơ sở dữ liệu
                    _context.CartItems.Update(existingItem);
                }
                else
                {
                    // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới sản phẩm
                    var newItem = new CartItem
                    {
                        productId = productId,
                        productName = productName,
                        productPrice = price,
                        quantity = quantitys,
                        anhsp = anhsps,
                        CustomerId = CustomerId,
                    };

                    // Thêm sản phẩm mới vào giỏ hàng
                    _context.CartItems.Add(newItem);
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();

                return Json(new { success = true, message = "Sản phẩm đã được thêm vào giỏ hàng thành công!" });
            }
            else
            {
                return Redirect($"/login");
            }
        }


        public IActionResult UpdateQuantity(int productId)
        {
            int CustomerId = HttpContext.Session.GetInt32("Id").Value;

            List<CartItem> cartItems = _context.CartItems
                                                      .Where(item => item.CustomerId == CustomerId)
                                                      .ToList();
            var existingItem = cartItems.FirstOrDefault(item => item.productId == productId && item.CustomerId == CustomerId); // Tìm sản phẩm theo productId

            if (existingItem != null)
            {
                // Tăng số lượng sản phẩm lên 1
                existingItem.quantity += 1;
            }

            _context.CartItems.Update(existingItem);
            _context.SaveChanges();

            return Redirect("/cart/Listcart"); // Chuyển hướng đến trang danh sách giỏ hàng
        }
        public IActionResult DeleteQuantity(int productId)
        {
            int CustomerId = HttpContext.Session.GetInt32("Id").Value;

            List<CartItem> cartItems = _context.CartItems
                                                                 .Where(item => item.CustomerId == CustomerId)
                                                                 .ToList();
            var existingItem = cartItems.FirstOrDefault(item => item.productId == productId && item.CustomerId == CustomerId); // Tìm sản phẩm theo productId
            if (existingItem != null)
            {
                // Giảm số lượng sản phẩm

                if (existingItem.quantity == 1)
                {
                    _context.CartItems.Remove(existingItem);
                    _context.SaveChanges();
                }
                else
                {
                    existingItem.quantity -= 1;
                    _context.CartItems.Update(existingItem);
                    _context.SaveChanges();
                }
            }



            return Redirect("/cart/Listcart"); // Chuyển hướng đến trang danh sách giỏ hàng
        }
        public string GenerateOrderCode()
        {
            // Giả sử bạn đã có danh sách các mã đơn hàng hiện tại
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
                nextNumber = 100; // Bắt đầu từ 100 nếu không có mã nào trước đó
            }

            // Tạo mã mới với tiền tố "HD" và định dạng "00000" (thêm số 0 phía trước nếu cần)
            string newOrderCode = "HD" + nextNumber.ToString("D5");

            return newOrderCode;
        }

        public IActionResult DatHang()
        {
            int CustomerId = HttpContext.Session.GetInt32("Id").Value;
            List<CartItem> cartItems = _context.CartItems
                                                                .Where(item => item.CustomerId == CustomerId)
                                                                .ToList();
            Customer customer = customerService.GetCustomerById(CustomerId);
            decimal total = cartItems.Sum(o => o.productPrice * o.quantity);
            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.Address = customer.Address;
            order.Code = GenerateOrderCode();
            order.CustomerId = CustomerId;
            order.Status = "Đã đặt";
            order.Total = total;
            order.Quantity = 1;
            order.Phone = customer.PhoneNumber;
            order.StartDatetime = DateTime.Now;
            int idorder = orderService.AddCOrder(order);
            foreach (CartItem item in cartItems)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = item.quantity,
                    TotalPrice = item.quantity * item.productPrice,
                    StartDattetime = DateTime.Now,
                    OrderId = idorder,
                    ProductId = item.productId,
                };
                orderDetailService.AddCOrder(orderDetail);
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }
            
            return Redirect("/cart/Listcart");
        }

    }
}
