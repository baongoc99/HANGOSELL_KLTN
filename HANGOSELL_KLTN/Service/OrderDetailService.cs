using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace HANGOSELL_KLTN.Service
{
    public class OrderDetailService
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetAllCategory()
        {
            return _context.OrderDetails.ToList();
        }
        public void AddCOrder(OrderDetail OrderDetail)
        {
            _context.OrderDetails.Add(OrderDetail);
            _context.SaveChanges();
        }
        public OrderDetail GetOrderDetailById(int id)
        {
            return _context.OrderDetails.FirstOrDefault(p => p.Id == id);
        }
        public List<OrderDetail> GetOrderDetailByIdOrder(int id)
        {
            return _context.OrderDetails
                           .Where(p => p.OrderId == id)
                           .Include(p => p.Product) // Bao gồm thông tin về Product
                           .ToList();
        }



        public void UpdateCategory(OrderDetail OrderDetail)
        {
            var existingemployee = _context.OrderDetails.SingleOrDefault(u => u.Id == OrderDetail.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(OrderDetail);
            }
            else
            {
                _context.OrderDetails.Update(OrderDetail);
            }
            _context.SaveChanges();
        }

    }

}
