/*using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly SupplierService supplierService;
        public SupplierController(SupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public IActionResult Index()
        {
            List<Supplier> suppliers = supplierService.GetAllSupplier();
            return View(suppliers);
        }

        public IActionResult CreateSupplier()
        {
            return View();
        }

        public IActionResult Create(Supplier supplier)
        {
            supplierService.AddSupplier(supplier);
            return Redirect("/Admin/Supplier");
        }

        public IActionResult EditSupplier(int id)
        {
            Supplier supplier = supplierService.GetSupplierById(id);
            return View(supplier);
        }

        public IActionResult Edit(Supplier supplier)
        {
            supplierService.UpdateSupplier(supplier);
            return Redirect("/Admin/Supplier");
        }

        public IActionResult Delete(int id)
        {
            supplierService.DeleteSupplier(id);
            return Redirect("/Admin/Supplier");
        }
    }
}
*/