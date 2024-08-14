using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Mvc;

namespace HANGOSELL_KLTN.Controllers
{
    public class LoginController : Controller
    {
        private readonly EmployeeService employeeService;
        public LoginController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult Login(string codeEmployee, string password)
        {
            Employee employee = employeeService.CheckCodeAndPass(codeEmployee, password);
            if (employee != null)
            {
                // Lưu thông tin người dùng vào session
                HttpContext.Session.SetString("CodeEmployee", employee.CodeEmployee.ToString());
                HttpContext.Session.SetInt32("Id", employee.Id);
                HttpContext.Session.SetString("EmployeeName", employee.EmployeeName);

                // Đăng nhập thành công, chuyển hướng đến trang chính
                return Redirect($"/Admin/Home/");
            }
            return Redirect($"/Home");
        }
    }
}
