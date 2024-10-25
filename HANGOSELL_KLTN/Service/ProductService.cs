using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace HANGOSELL_KLTN.Service
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProduct()
        {
            return _context.Products.Include(p =>p.ProductCategory).ToList();
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Include(s => s.ProductCategory).FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            // Tìm kiếm sản phẩm hiện có trong cơ sở dữ liệu dựa trên Id của $ối tượng product truyền vào.
            var existingProduct = _context.Products.SingleOrDefault(p => p.Id == product.Id);

            // Nếu tìm thấy sản phẩm (khác null)
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).CurrentValues.SetValues(product);

                // Lưu lại các thay $ổi vào cơ sở dữ liệu.
                _context.SaveChanges();
            }
            else
            {
                _context.Products.Update(product);
                // Nếu không tìm thấy sản phẩm với Id tương ứng, có thể ném một ngoại lệ hoặc xử lý theo cách khác tùy theo yêu cầu.
                throw new ArgumentException("Product not found");
            }
        }
        public void DeleteProduct(int id)
        {
            var products = _context.Products.Find(id);
            if (products != null)
            {
                _context.Products.Remove(products);
                _context.SaveChanges();
            }

        }
    }
}
