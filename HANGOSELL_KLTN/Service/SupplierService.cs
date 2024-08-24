/*using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;

namespace HANGOSELL_KLTN.Service
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }
        public void AddSupplier(Supplier customer)
        {
            _context.Suppliers.Add(customer);
            _context.SaveChanges();
        }
        public Supplier GetSupplierById(int id)
        {
            return _context.Suppliers.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateSupplier(Supplier customer)
        {
            // Tìm kiếm khách hàng hiện có trong cơ sở dữ liệu dựa trên Id của đối tượng Supplier truyền vào.
            var existingcustomer = _context.Suppliers.SingleOrDefault(u => u.Id == customer.Id);

            // Nếu tìm thấy khách hàng (khác null)
            if (existingcustomer != null)
            {
                // Cập nhật tất cả các thuộc tính của đối tượng existingcustomer bằng các giá trị của đối tượng customer.
                _context.Entry(existingcustomer).CurrentValues.SetValues(customer);
            }
            else
            {
                // Nếu không tìm thấy khách hàng với Id tương ứng, hàm sẽ thực hiện cập nhật bằng cách thêm hoặc cập nhật đối tượng Supplier vào DbSet.
                _context.Suppliers.Update(customer);
            }

            // Lưu lại các thay đổi vào cơ sở dữ liệu.
            _context.SaveChanges();
        }
        public void DeleteSupplier(int id)
        {
            var customers = _context.Suppliers.Find(id);
            if (customers != null)
            {
                _context.Suppliers.Remove(customers);
                _context.SaveChanges();
            }

        }
    }
}
*/