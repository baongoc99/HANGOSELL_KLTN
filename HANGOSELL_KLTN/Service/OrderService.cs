using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace HANGOSELL_KLTN.Service
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAllorder()
        {
            return _context.Orders.Include(e => e.Customer).ToList();
        }
        public int AddCOrder(Order Order)
        {
            _context.Orders.Add(Order);
            _context.SaveChanges();
            return Order.Id;
        }
        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(p => p.Id == id);
        }
        public Order GetCode()
        {
            return _context.Orders.OrderByDescending(o => o.Code).FirstOrDefault();
        }

        public Order GetOrderByIdCustomer(int idcustomer, int id)
        {
            return _context.Orders.FirstOrDefault(p => p.CustomerId == idcustomer && p.Id == id);
        }

        public void UpdateCategory(Order Order)
        {
            var existingemployee = _context.Orders.SingleOrDefault(u => u.Id == Order.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(Order);
            }
            else
            {
                _context.Orders.Update(Order);
            }
            _context.SaveChanges();
        }

    }
}
