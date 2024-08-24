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
        public DbSet<ProductCategory> Categories { get; set; }
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
        public DbSet<OrderDetailCustomer> OrderDetailCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ và ràng buộc cho các thực thể

            // Cấu hình cho thực thể Category
            modelBuilder.Entity<ProductCategory>()
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

            /*// Cấu hình quan hệ giữa các thực thể
            modelBuilder.Entity<News>()
                .HasOne<ProductCategory>()
                .WithMany(c => c.News)
                .HasForeignKey(n => n.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);*/

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

            /*modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");*/

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.PriceSale)
                .HasColumnType("decimal(18,2)");

            // Seed dữ liệu mẫu cho các thực thể

            // Seed Categories
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    Id = 1,
                    Title = "Áo Thun",
                    Description = "Áo thun các loại.",
                    Icon = "icon-t-shirt",
                    SeoTitle = "Áo Thun",
                    SeoKeyword = "ao thun, ao phông",
                    SeoDescription = "Áo thun đa dạng mẫu mã và màu sắc."
                },
                new ProductCategory
                {
                    Id = 2,
                    Title = "Quần Jeans",
                    Description = "Quần jeans thời trang.",
                    Icon = "icon-jeans",
                    SeoTitle = "Quần Jeans",
                    SeoKeyword = "quan jeans, jeans",
                    SeoDescription = "Quần jeans phù hợp với nhiều phong cách."
                }
            );

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Customer" }
            );

            // Seed data for Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Áo Thun Trắng",
                    ProductCode = "AT01",
                    ProductCategoryId = 1,
                    Description = "Áo thun trắng đơn giản, thoải mái.",
                    Price = 150000,
                    Quantity = 100,
                    IsHome = true,
                    IsSale = false,
                    IsFeature = true,
                    IsHot = false,
                    SeoTitle = "Áo Thun Trắng",
                    SeoKeyword = "ao thun trang, thun",
                    SeoDescription = "Áo thun trắng với chất liệu vải cao cấp."
                },
                new Product
                {
                    Id = 2,
                    Title = "Quần Jeans Xanh",
                    ProductCode = "QJ01",
                    ProductCategoryId = 2,
                    Description = "Quần jeans xanh, kiểu dáng trẻ trung.",
                    Price = 250000,
                    Quantity = 50,
                    IsHome = false,
                    IsSale = true,
                    IsFeature = false,
                    IsHot = true,
                    SeoTitle = "Quần Jeans Xanh",
                    SeoKeyword = "quan jeans xanh, jeans",
                    SeoDescription = "Quần jeans xanh với thiết kế hiện đại."
                }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    CompanyName = "Công ty TNHH ABC",
                    ContactPerson = "Nguyễn Văn A",
                    Email = "a.nguyen@abc.com",
                    Password = "hashed_password_1", // Ensure this is hashed in a real application
                    PhoneNumber = "0912345678",
                    Address = "123 Đường ABC, TP.HCM"
                },
                new Customer
                {
                    Id = 2,
                    CompanyName = "Công ty CP XYZ",
                    ContactPerson = "Trần Thị B",
                    Email = "b.tran@xyz.com",
                    Password = "hashed_password_2", // Ensure this is hashed in a real application
                    PhoneNumber = "0987654321",
                    Address = "456 Đường DEF, Hà Nội"
                }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    CodeEmployee = "EMP001",
                    EmployeeName = "Nguyễn Văn A",
                    Email = "a.nguyen@example.com",
                    Password = "hashed_password_1", // Ensure this is hashed in a real application
                    DateOfBirth = new DateTime(1990, 5, 20),
                    PhoneNumber = "0912345678",
                    Address = "123 Đường ABC, TP.HCM",
                    JoinDate = new DateTime(2021, 1, 15),
                    Status = true, // Assuming Status is a boolean
                    RoleID = 1, // Reference to Role table
                    Avatar = "avatar1.png",
                    Position = "Senior Developer"
                },
                new Employee
                {
                    Id = 2,
                    CodeEmployee = "EMP002",
                    EmployeeName = "Trần Thị B",
                    Email = "b.tran@example.com",
                    Password = "hashed_password_2", // Ensure this is hashed in a real application
                    DateOfBirth = new DateTime(1985, 8, 10),
                    PhoneNumber = "0987654321",
                    Address = "456 Đường DEF, Hà Nội",
                    JoinDate = new DateTime(2020, 6, 25),
                    Status = false, // Assuming Status is a boolean
                    RoleID = 2, // Reference to Role table
                    Avatar = "avatar2.png",
                    Position = "Junior Developer"
                }
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

        }
    }
}
