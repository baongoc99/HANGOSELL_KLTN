using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;
        public ProductController(ProductService productService, CategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<Product> products = productService.GetAllProduct();
            return View(products);
        }
        public IActionResult GteAllProduct(string name)
        {
            List<Product> listproduct;
            if (string.IsNullOrEmpty(name))
            {
                // Nếu không có từ khóa, lấy tất cả sản phẩm
                listproduct = productService.GetAllProducts();
            }
            else
            {
                // Nếu có từ khóa, lọc sản phẩm theo tiêu đề chứa từ khóa
                listproduct = productService.GetAllProducts()
                    .Where(p => p.Title.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            return Json(listproduct);
        }

        public IActionResult CreateProduct()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<ModelDataset> ModelDatasetlist = new List<ModelDataset>();
            List<ProductCategory> categorylisst = categoryService.GetAllCategory();

            foreach (var category in categorylisst)
            {
                ModelDataset modelDataset = new ModelDataset()
                {
                    category = category,
                };
                ModelDatasetlist.Add(modelDataset);
            }
            return View(ModelDatasetlist);
        }

        public IActionResult Create(Product product, IFormFile image)
        {
            try
            {
                product.Image = SaveImage(image);
                productService.AddProduct(product);
                return Redirect("/Admin/Product");
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult Createaddproduct(Product product)
        {
            productService.AddProduct(product);
            return Redirect("/Admin/Invoice/CreateInvoice");
        }

        public IActionResult EditProduct(int id)
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            Product product = productService.GetProductById(id);
            List<ProductCategory> categories = categoryService.GetAllCategory();
            ModelDataset modelDataset = new ModelDataset()
            {
                product = product,
                categories = categories
            };
            return View(modelDataset);
        }

        public IActionResult Edit(Product product, IFormFile image)
        {
            try
            {
                product.Image = SaveImage(image);
                productService.UpdateProduct(product);
                return Redirect("/Admin/Product");
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return Redirect("/Admin/Product");
        }

        private string SaveImage(IFormFile image)
        {
            if (image != null)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    throw new InvalidOperationException("Invalid image file type");
                }

                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                return Path.Combine("images", uniqueFileName).Replace("\\", "/");
            }
            return "images/default.jpg";
        }
    }
}
