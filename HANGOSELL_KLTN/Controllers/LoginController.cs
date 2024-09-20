using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            Employee employee = employeeService.CheckCodeAndPass(codeEmployee);
            var checkmatkhau = employeeService.VerifyPassword(employee.Password, password);
            if (checkmatkhau == PasswordVerificationResult.Success)
            {
                // Lưu thông tin người dùng vào session
                HttpContext.Session.SetInt32("Id", employee.Id);
                HttpContext.Session.SetString("CodeEmployee", employee.CodeEmployee.ToString());
                HttpContext.Session.SetString("EmployeeName", employee.EmployeeName);
                HttpContext.Session.SetString("Email", employee.Email);
                HttpContext.Session.SetString("DateOfBirth", employee.DateOfBirth.ToString("yyyy-MM-dd"));
                HttpContext.Session.SetString("PhoneNumber", employee.PhoneNumber);
                HttpContext.Session.SetString("Address", employee.Address);
                HttpContext.Session.SetString("JoinDate", employee.JoinDate.ToString("yyyy-MM-dd"));
                HttpContext.Session.SetString("Status", employee.Status.ToString());
                HttpContext.Session.SetString("Position", employee.Position);
                HttpContext.Session.SetString("Avatar", employee.Avatar);


                // Đăng nhập thành công, chuyển hướng đến trang chính
                return Redirect($"/Admin/Home/");
            }
            return Redirect($"/Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
