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
            List<Category> categories = categoryService.GetAllCategory();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        public IActionResult Create(Category category)
        {
            categoryService.AddCategory(category);
            return Redirect("/Admin/Category/IndexCategory");
        }

        public IActionResult EditCategory(int id)
        {
            Category category = categoryService.GetCategoryById(id);
            return View(category);
        }

        public IActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return Redirect("/Admin/Category/IndexCategory");
        }

        public IActionResult Delete(int id)
        {
            categoryService.DeleteCategory(id);
            return Redirect("/Admin/Category/IndexCategory");
        }
    }
}
