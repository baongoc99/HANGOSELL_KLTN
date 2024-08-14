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
            var existingcustomer = _context.Customers.SingleOrDefault(u => u.Id == customer.Id);
            if (existingcustomer != null)
            {
                _context.Entry(existingcustomer).CurrentValues.SetValues(customer);
            }
            else
            {
                _context.Customers.Update(customer);
            }
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
    }
}
