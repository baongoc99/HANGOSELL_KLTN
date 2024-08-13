using HANGOSELL_KLTN.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace HANGOSELL_KLTN.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Định nghĩa các DbSet cho từng thực thể (entity)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Adv> Adverts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ và ràng buộc cho các thực thể

            // Cấu hình cho thực thể Category
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Title)
                .IsUnique();

            // Cấu hình cho thực thể Product
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductCode)
                .IsUnique();

            // Cấu hình cho thực thể Order
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.Code)
                .IsUnique();

            // Cấu hình quan hệ giữa các thực thể
            modelBuilder.Entity<News>()
                .HasOne<Category>()
                .WithMany(c => c.News)
                .HasForeignKey(n => n.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.PriceSale)
                .HasColumnType("decimal(18,2)");

            // Seed dữ liệu mẫu cho các thực thể

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Electronics", Position = 1, SeoTitle = "Electronics Category", SeoKeyword = "electronics, gadgets", SeoDescription = "Find the latest electronics here." },
                new Category { Id = 2, Title = "Books", Position = 2, SeoTitle = "Books Category", SeoKeyword = "books, literature", SeoDescription = "Browse our collection of books." }
            );

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Customer" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Laptop", ProductCode = "LPT123", ProductCategoryId = 1, Price = 999.99m, Quantity = 10, SeoTitle = "High Performance Laptop", SeoKeyword = "laptop, electronics", SeoDescription = "A high-performance laptop for all your needs." },
                new Product { Id = 2, Title = "Novel", ProductCode = "NOV456", ProductCategoryId = 2, Price = 19.99m, Quantity = 100, SeoTitle = "Bestselling Novel", SeoKeyword = "novel, literature", SeoDescription = "A bestselling novel for avid readers." }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, CompanyName = "ABC Corporation", ContactPerson = "John Doe", Email = "john.doe@example.com", Password = "password123", PhoneNumber = "123-456-7890", Address = "123 Main St", CreateDate = DateTime.Now },
                new Customer { Id = 2, CompanyName = "XYZ Enterprises", ContactPerson = "Jane Smith", Email = "jane.smith@example.com", Password = "password456", PhoneNumber = "987-654-3210", Address = "456 Elm St", CreateDate = DateTime.Now }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, CodeEmployee = "EMP001", EmployeeName = "Alice Johnson", Email = "alice.johnson@example.com", Password = "password123", DateOfBirth = new DateTime(1985, 5, 15), PhoneNumber = "555-1234", Address = "789 Maple St", JoinDate = DateTime.Now, Status = true, RoleID = 1, Avatar = "alice.jpg", Position = "Manager" },
                new Employee { Id = 2, CodeEmployee = "EMP002", EmployeeName = "Bob Brown", Email = "bob.brown@example.com", Password = "password456", DateOfBirth = new DateTime(1990, 10, 20), PhoneNumber = "555-5678", Address = "321 Oak St", JoinDate = DateTime.Now, Status = true, RoleID = 2, Avatar = "bob.jpg", Position = "Sales Clerk" }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Code = "ORD001", CustomerName = "John Doe", Phone = "123-456-7890", Address = "123 Main St", TotalAmount = 1019.98m, Quantity = 2 },
                new Order { Id = 2, Code = "ORD002", CustomerName = "Jane Smith", Phone = "987-654-3210", Address = "456 Elm St", TotalAmount = 19.99m, Quantity = 1 }
            );

            // Seed Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, Amount = 1019.98m, EmployeeId = 1, Notes = null, OrderId = 1, PaymentDate = DateTime.Now, PaymentMethod = "Credit Card" },
                new Payment { Id = 2, Amount = 19.99m, EmployeeId = 2, Notes = null, OrderId = 2, PaymentDate = DateTime.Now, PaymentMethod = "PayPal" }
            );

            // Seed OrderDetails
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Price = 999.99m, Quantity = 1 },
                new OrderDetail { Id = 2, OrderId = 1, ProductId = 2, Price = 19.99m, Quantity = 1 },
                new OrderDetail { Id = 3, OrderId = 2, ProductId = 2, Price = 19.99m, Quantity = 1 }
            );

            // Seed News
            modelBuilder.Entity<News>().HasData(
                new News { Id = 1, Title = "Latest Tech News", Description = "Update on the latest technology trends.", Image = "tech-news.jpg", SeoTitle = "Tech News", SeoKeyword = "technology, news", SeoDescription = "Latest updates on technology.", CategoryId = 1 }
            );

            // Seed Posts
            modelBuilder.Entity<Posts>().HasData(
                new Posts { Id = 1, Title = "New Product Launch", Description = "Introducing our new product.", Image = "product-launch.jpg", SeoTitle = "Product Launch", SeoKeyword = "product, launch", SeoDescription = "New product launch details.", CategoryId = 1 }
            );

            // Seed Subscribes
            modelBuilder.Entity<Subscribe>().HasData(
                new Subscribe { Id = 1, Email = "subscriber@example.com", CreateDate = DateTime.Now }
            );

            // Seed SystemSettings
            modelBuilder.Entity<SystemSetting>().HasData(
                new SystemSetting { SettingKey = "SiteName", SettingValue = "My Shop", SettingDescription = "The name of the website" },
                new SystemSetting { SettingKey = "SiteUrl", SettingValue = "https://www.myshop.com", SettingDescription = "The URL of the website" }
            );

            // Seed ProductCategories
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Title = "Electronics", Description = "Electronic items", Icon = "electronics.png", SeoTitle = "Electronics Category", SeoKeyword = "electronics", SeoDescription = "Electronic products" },
                new ProductCategory { Id = 2, Title = "Books", Description = "Books and literature", Icon = "books.png", SeoTitle = "Books Category", SeoKeyword = "books", SeoDescription = "Books and literature" }
            );
        }
    }
}
