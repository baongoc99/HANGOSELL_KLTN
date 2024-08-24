using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position"); 
            List<ProductCategory> categories = categoryService.GetAllCategory();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            return View();
        }

        public IActionResult Create(ProductCategory category)
        {
            categoryService.AddCategory(category);
            return Redirect("/Admin/Category");
        }

        public IActionResult EditCategory(int id)
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            ProductCategory category = categoryService.GetCategoryById(id);
            return View(category);
        }

        public IActionResult Edit(ProductCategory category)
        {
            categoryService.UpdateCategory(category);
            return Redirect("/Admin/Category");
        }

        public IActionResult Delete(int id)
        {
            categoryService.DeleteCategory(id);
            return Redirect("/Admin/Category");
        }
    }
}
