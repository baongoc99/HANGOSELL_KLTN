using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HANGOSELL_KLTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;
        private readonly RoleService roleService;
        public EmployeeController(EmployeeService employeeService, RoleService roleService)
        {
            this.employeeService = employeeService;
            this.roleService = roleService;
        }
        public IActionResult Index()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<Employee> employees = employeeService.GetAllEmployee();
            return View(employees);
        }


        public IActionResult Editpassword(int Idemployee, string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            Employee employee = employeeService.GetEmployeeById(Idemployee);
            var checkmatkhau = employeeService.VerifyPassword(employee.Password, CurrentPassword);

            if (checkmatkhau != PasswordVerificationResult.Success)
            {
                return Json(new { success = false, message = "Mật khẩu hiện tại không đúng!" });
            }
            if (NewPassword != ConfirmPassword)
            {
                return Json(new { success = false, message = "Nhập lại mật khẩu mới không đúng!" });
            }
            string mahoamatkhau = employeeService.HashPassword(NewPassword);
            employee.Password = mahoamatkhau;
            employeeService.UpdateEmployee(employee);
            return Json(new { success = true, message = "Cập nhật mật khẩu thành công!" });
        }

        // Hiển thị giao diện lưới (Grid) danh sách người dùng
        public IActionResult GridEmployee()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
                ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
                ViewData["Position"] = HttpContext.Session.GetString("Position");
                List<Employee> employees = employeeService.GetAllEmployee();
                return View(employees);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult CreateEmployee()
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");

            List<Role> rolelist = roleService.GetAllRoles();
            List<ModelDataset> modeldata = new List<ModelDataset>();
            foreach (Role role in rolelist)
            {
                ModelDataset model = new ModelDataset()
                {
                    role = role,
                };
                modeldata.Add(model);
            }

            return View(modeldata);
        }
        public IActionResult Create(Employee employee, IFormFile image)
        {
            if (image != null)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return Redirect($"/Admin/UserRoles/IndexUserRoles");
                }
                // Ensure unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
                // Create directory if it doesn't exist
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                try
                {
                    // Save the file
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
                catch (Exception ex)
                {
                    // Handle file saving exceptions
                    // Optionally log the error and return an appropriate view
                    return RedirectToAction("Error", "Home");
                }
                var relativePath = Path.Combine("images", uniqueFileName).Replace("\\", "/");
                employee.Avatar = relativePath;
            }
            else
            {
                employee.Avatar = "images/default.jpg";
            }
            string mahoamatkhau = employeeService.HashPassword(employee.Password);
            employee.Password = mahoamatkhau;
            employee.Status = true;
            Employee employee1 = employeeService.GetEmployeeByCodeEmployee(employee.CodeEmployee);
            if (employee1 == null)
            {
                employeeService.AddEmployee(employee);
                return Redirect("/Admin/Employee");
            }
            else
            {
                return Redirect("/Admin/Employee/CreateEmployee");

            }
        }

        public IActionResult EditEmployee(int id)
        {
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");
            List<Role> roles = roleService.GetAllRoles();

            Employee employee = employeeService.GetEmployeeById(id);
            ModelDataset model = new ModelDataset()
            {
                employee = employee,
                roles = roles
            };

            return View(model);
        }
        public IActionResult Edit(Employee employee, IFormFile image)
        {
            Employee employee1 = employeeService.GetEmployeeById(employee.Id);
            if (image != null)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return Redirect($"/Admin/Employee/Index");
                }
                // Ensure unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
                // Create directory if it doesn't exist
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                try
                {
                    // Save the file
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
                catch (Exception ex)
                {
                    // Handle file saving exceptions
                    // Optionally log the error and return an appropriate view
                    return RedirectToAction("Error", "Home");
                }
                var relativePath = Path.Combine("images", uniqueFileName).Replace("\\", "/");
                employee.Avatar = relativePath;
            }
            else
            {
                employee.Avatar = "images/default.jpg";
            }
            employee.Password = employee1.Password;
            employeeService.UpdateEmployee(employee);
            return Redirect("/Admin/Employee");
        }
        public IActionResult Delete(int id)
        {
            employeeService.DeleteEmployee(id);
            return Redirect("/Admin/Employee");
        }
        public IActionResult ProfilePage()
        {
            int id = HttpContext.Session.GetInt32("Id").Value;

            // Nếu đã đăng nhập, lưu thông tin người dùng vào ViewData
            ViewData["EmployeeName"] = HttpContext.Session.GetString("EmployeeName");
            ViewData["Avatar"] = HttpContext.Session.GetString("Avatar");
            ViewData["Position"] = HttpContext.Session.GetString("Position");

            Employee employee = employeeService.GetEmployeeById(id);
            return View(employee);
        }


        public IActionResult EditProfile(Employee model)
        {
            // Xử lý chỉnh sửa hồ sơ
            return RedirectToAction("Index");
        }
    }
}
