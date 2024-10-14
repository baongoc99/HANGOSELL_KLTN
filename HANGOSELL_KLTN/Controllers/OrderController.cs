using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;
using HANGOSELL_KLTN.Data;


namespace HANGOSELL_KLTN.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly StoreService storeService;
        private readonly ProductService _productService;
        private readonly OrderDetailService orderDetailService;


        public OrderController(OrderService orderService, ApplicationDbContext applicationDbContext, StoreService storeService
            , ProductService productService, OrderDetailService orderDetailService)
        {
            this.orderService = orderService;
            this.applicationDbContext = applicationDbContext;
            this.storeService = storeService;
            _productService = productService;
            this.orderDetailService = orderDetailService;   
        }
        public IActionResult ListOrderDetail(int id)
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
        public async Task<IActionResult> Listorder()
        {
            if (HttpContext.Session.GetInt32("Id") != null)
            {
                int CustomerId = HttpContext.Session.GetInt32("Id").Value;
                List<Order> lisstorder = applicationDbContext.Orders
                    .Where(o => o.CustomerId == CustomerId)
                    .OrderByDescending(o => o.CreateDate) // Thay thế OrderDate bằng thuộc tính bạn muốn sắp xếp
                    .ToList();
                lisstorder[0].Customer = null;
                lisstorder[0].OrderDetails = null;
                Store store = await storeService.GetStoreAsync();
                ViewData["emailstore"] = store.Email;
                ViewData["logo"] = store.Logo;
                ViewData["PhoneNumber"] = store.PhoneNumber;
                ViewData["Address"] = store.Address;
                ViewData["ContactPerson"] = HttpContext.Session.GetString("ContactPerson");

                return View(lisstorder);
            }
            else
            {
                return Redirect($"/login");

            }
        }
        public IActionResult updategiaohang(int id)
        {
            Order order = orderService.GetOrderById(id);
            order.Status = "Đã nhận hàng";
            orderService.UpdateCategory(order);
            return Redirect($"/order/Listorder");
        }
    }
}