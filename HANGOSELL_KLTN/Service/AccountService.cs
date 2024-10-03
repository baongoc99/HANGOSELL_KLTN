using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HANGOSELL_KLTN.Service
{
    public class AccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Employee> _passwordHasherEmployee;
		private readonly IPasswordHasher<Customer> _passwordHasherCustomer;

		public AccountService(ApplicationDbContext context, IPasswordHasher<Employee> passwordHasherEmployee, IPasswordHasher<Customer> passwordHasherCustomer)
        {
            _context = context;
			_passwordHasherEmployee = passwordHasherEmployee;
            _passwordHasherCustomer = passwordHasherCustomer;
        }

        public string HashPassword(string password)
        {
            return _passwordHasherEmployee.HashPassword(null, password);
        }
        public PasswordVerificationResult VerifyPassword(string hashedPassword, string providedPassword)
        {
            try
            {
                return _passwordHasherEmployee.VerifyHashedPassword(null, hashedPassword, providedPassword);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"x pass: {ex.Message}");
                return PasswordVerificationResult.Failed;
            }
        }
		public string HashPasswordCustomer(Customer customer, string password)
		{
			return _passwordHasherCustomer.HashPassword(customer, password);
		}

		public Employee CheckCodeAndPass(string codeEmployee)
        {
            Employee Employee = _context.Employees.FirstOrDefault(u => u.CodeEmployee == codeEmployee || u.Email == codeEmployee);
            return Employee;
        }
        public List<Employee> GetAllEmployee()
        {
            return _context.Employees.Include(e => e.Role).ToList();
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Include(e => e.Role).FirstOrDefault(p => p.Id == id);
        }
        public Employee GetEmployeeByCodeEmployee(string CodeEmployee)
        {
            return _context.Employees.FirstOrDefault(p => p.CodeEmployee == CodeEmployee);
        }

        public Employee GetEmployeeByIdandCurrentPasswordEmployee(string CurrentPassword, int id)
        {
            return _context.Employees.FirstOrDefault(p => p.Password == CurrentPassword && p.Id == id);
        }


        public void UpdateEmployee(Employee employee)
        {
            var existingemployee = _context.Employees.SingleOrDefault(u => u.Id == employee.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(employee);
            }
            else
            {
                _context.Employees.Update(employee);
            }
            _context.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            var employeedelete = _context.Employees.Find(id);
            if (employeedelete != null)
            {
                _context.Employees.Remove(employeedelete);
                _context.SaveChanges();
            }

        }
    }
}
