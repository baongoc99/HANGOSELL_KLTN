using HANGOSELL_KLTN.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HANGOSELL_KLTN.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListCart()
        {
            List<CartItem> cartItems = GetCartItems();
            return View(cartItems);
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
        public IActionResult AddToCart(int productId, string productName, Decimal price, int quantitys, string anhsps)
        {
            List<CartItem> cartItems = GetCartItems();
            var existingItem = cartItems.FirstOrDefault(item => item.productId == productId);

            if (existingItem != null)
            {
                int previousQuantity = existingItem.quantity;

                existingItem.quantity += quantitys;

                if (previousQuantity != existingItem.quantity)
                {
                    existingItem.productPrice = existingItem.quantity * price;
                }
            }
            else
            {
                cartItems.Add(new CartItem { productId = productId, productName = productName, productPrice = quantitys * price, quantity = quantitys, anhsp = anhsps });
            }
            SaveCartItems(cartItems);
            return Json(new { success = true, message = "Sản phẩm đã được thêm vào giỏ hàng thành công!" });
        }

        public IActionResult UpdateQuantity(int productId)
        {
            List<CartItem> cartItems = GetCartItems(); // Lấy danh sách các sản phẩm trong giỏ hàng
            var existingItem = cartItems.FirstOrDefault(item => item.productId == productId); // Tìm sản phẩm theo productId

            if (existingItem != null)
            {
                // Tăng số lượng sản phẩm lên 1
                existingItem.quantity += 1;
            }

            SaveCartItems(cartItems); // Lưu lại giỏ hàng
            return Redirect("/cart/Listcart"); // Chuyển hướng đến trang danh sách giỏ hàng
        }
        public IActionResult DeleteQuantity(int productId)
        {
            List<CartItem> cartItems = GetCartItems(); // Lấy danh sách các sản phẩm trong giỏ hàng
            var existingItem = cartItems.FirstOrDefault(item => item.productId == productId); // Tìm sản phẩm theo productId

            if (existingItem != null)
            {
                // Giảm số lượng sản phẩm
                existingItem.quantity -= 1;

                if (existingItem.quantity <= 0)
                {
                    cartItems.Remove(existingItem); // Xóa sản phẩm nếu số lượng <= 0
                }
            }

            SaveCartItems(cartItems); // Lưu lại giỏ hàng

            return Redirect("/cart/Listcart"); // Chuyển hướng đến trang danh sách giỏ hàng
        }

    }
}
