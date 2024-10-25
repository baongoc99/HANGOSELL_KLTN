using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;

namespace HANGOSELL_KLTN.Service
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateCustomer(Customer customer)
        {
            // Tìm kiếm khách hàng hiện có trong cơ sở dữ liệu dựa trên Id của $ối tượng customer truyền vào.
            var existingcustomer = _context.Customers.SingleOrDefault(u => u.Id == customer.Id);

            // Nếu tìm thấy khách hàng (khác null)
            if (existingcustomer != null)
            {
                // Cập nhật tất cả các thuộc tính của $ối tượng existingcustomer bằng các giá trị của $ối tượng customer.
                _context.Entry(existingcustomer).CurrentValues.SetValues(customer);
            }
            else
            {
                // Nếu không tìm thấy khách hàng với Id tương ứng, hàm sẽ thực hiện cập nhật bằng cách thêm hoặc cập nhật $ối tượng customer vào DbSet.
                _context.Customers.Update(customer);
            }

            // Lưu lại các thay $ổi vào cơ sở dữ liệu.
            _context.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var customers = _context.Customers.Find(id);
            if (customers != null)
            {
                _context.Customers.Remove(customers);
                _context.SaveChanges();
            }

        }
        public Customer CheckCodeAndPass(string codecustomer)
        {
            Customer Employee = _context.Customers.FirstOrDefault(u => u.CompanyName == codecustomer || u.Email == codecustomer);
            return Employee;
        }
    }
}
