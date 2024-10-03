using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models;
using HANGOSELL_KLTN.Models.EF;
using HANGOSELL_KLTN.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HANGOSELL_KLTN.Areas.Login.Controllers
{
	[Area("Login")]
	public class LoginController : Controller
	{
		private readonly AccountService AccountService;
		private readonly ApplicationDbContext _context;

		public LoginController(AccountService AccountService, ApplicationDbContext context)
		{
			this.AccountService = AccountService;
			this._context = context;
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Register(Customer customer, string password, string password_confirmation)
		{
			try
			{
				// Kiểm tra mật khẩu nhập lại
				if (password != password_confirmation)
				{
					ModelState.AddModelError(string.Empty, "Passwords do not match.");
					return View(customer);
				}

				// Kiểm tra email đã tồn tại chưa
				var existingCustomer = _context.Customers.FirstOrDefault(c => c.Email == customer.Email);
				if (existingCustomer != null)
				{
					ModelState.AddModelError(string.Empty, "Email already exists.");
					return View(customer);
				}

				// Mã hóa mật khẩu bằng IPasswordHasher từ AccountService
				customer.Password = AccountService.HashPasswordCustomer(customer, password);

				// Gán vai trò mặc định cho customer (RoleID là vai trò Customer)
				var customerRole = _context.Roles.FirstOrDefault(r => r.RoleName == "Customer");
				if (customerRole != null)
				{
					customer.RoleId = customerRole.Id;
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Role Customer not found.");
					return View(customer);
				}

				// Lưu customer vào database
				_context.Customers.Add(customer);
				_context.SaveChanges();

				return RedirectToAction("Login", "Login");
			}
			catch (Exception ex)
			{
				return View(customer);
			}
		}

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm Customer
                var customer = _context.Customers.FirstOrDefault(c => c.Email == model.Email);
                if (customer != null)
                {
                    var result = AccountService.VerifyPassword(customer.Password, model.Password);
                    if (result == PasswordVerificationResult.Success)
                    {
                        // Đăng nhập thành công, tạo Claims
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, customer.ContactPerson), // Tên
                    new Claim(ClaimTypes.Email, customer.Email), // Email
                    new Claim("Position", "Customer") // Vai trò hoặc vị trí
                };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            // Các tùy chọn về thời gian lưu trữ phiên đăng nhập
                            IsPersistent = true // Để phiên đăng nhập tồn tại sau khi đóng trình duyệt
                        };

                        // Thực hiện đăng nhập
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                        // Điều hướng đến view của Customer
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                }

                // Tìm Admin
                var admin = _context.Employees.FirstOrDefault(a => a.Email == model.Email);
                if (admin != null)
                {
                    var result = AccountService.VerifyPassword(admin.Password, model.Password);
                    if (result == PasswordVerificationResult.Success)
                    {
                        // Đăng nhập thành công, tạo Claims
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.EmployeeName), // Tên
                    new Claim(ClaimTypes.Email, admin.Email), // Email
                    new Claim("Position", admin.Position) // Vai trò hoặc vị trí
                };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };

                        // Thực hiện đăng nhập
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                        // Điều hướng đến view của Admin
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                }

                // Nếu không tìm thấy hoặc mật khẩu không đúng
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }


        //[HttpPost]
        //public IActionResult Login(string codeEmployee, string password)
        //{
        //	Employee employee = AccountService.CheckCodeAndPass(codeEmployee);
        //	var checkmatkhau = AccountService.VerifyPassword(employee.Password, password);
        //	if (checkmatkhau == PasswordVerificationResult.Success)
        //	{
        //		// Lưu thô	ng tin người dùng vào session
        //		HttpContext.Session.SetInt32("Id", employee.Id);
        //		HttpContext.Session.SetString("CodeEmployee", employee.CodeEmployee.ToString());
        //		HttpContext.Session.SetString("EmployeeName", employee.EmployeeName);
        //		HttpContext.Session.SetString("Email", employee.Email);
        //		HttpContext.Session.SetString("DateOfBirth", employee.DateOfBirth.ToString("yyyy-MM-dd"));
        //		HttpContext.Session.SetString("PhoneNumber", employee.PhoneNumber);
        //		HttpContext.Session.SetString("Address", employee.Address);
        //		HttpContext.Session.SetString("JoinDate", employee.JoinDate.ToString("yyyy-MM-dd"));
        //		HttpContext.Session.SetString("Status", employee.Status.ToString());
        //		HttpContext.Session.SetString("Position", employee.Position);
        //		HttpContext.Session.SetString("Avatar", employee.Avatar);

        //		// Đăng nhập thành công, chuyển hướng đến trang chính
        //		return Redirect($"/Admin/Home/");
        //	}
        //	return Redirect($"/Home");
        //}

  //      public IActionResult Logout()
		//{
		//	HttpContext.Session.Clear();
		//	return RedirectToAction("Login", "Home");
		//}
		public string MD5Hash(string input)
		{
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2"));
				}
				return sb.ToString();
			}
		}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

    }
}
