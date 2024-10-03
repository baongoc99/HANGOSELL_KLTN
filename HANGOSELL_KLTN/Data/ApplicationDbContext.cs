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
		public DbSet<Role> Roles { get; set; }
		public DbSet<Customer> Customers { get; set; }
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
		public DbSet<QRCodeRequest> QRCodeRequests { get; set; }
		public DbSet<Store> Stores { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Cấu hình quan hệ và ràng buộc cho các thực thể
			modelBuilder.Entity<Role>()
				.HasMany(r => r.Employees) // Một Role có nhiều Employee
				.WithOne(e => e.Role)       // Một Employee chỉ thuộc một Role
				.HasForeignKey(e => e.RoleId) // Khóa ngoại RoleID trong bảng Employee
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict); // Hạn chế việc xóa vai trò nếu có nhân viên liên quan

			modelBuilder.Entity<Role>()
				.HasMany(r => r.Customers) // Một Role có nhiều Customer
				.WithOne(c => c.Role)      // Một Customer chỉ thuộc một Role
				.HasForeignKey(c => c.RoleId) // Khóa ngoại RoleId trong bảng Customer
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);


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

			//// Dữ liệu cho ProductCategory
			//modelBuilder.Entity<ProductCategory>().HasData(new List<ProductCategory>
			//{
			//	new ProductCategory { Id = 1, Title = "Áo", Description = "Các loại áo thời trang", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 2, Title = "Quần", Description = "Các loại quần thời trang", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 3, Title = "Giày", Description = "Giày dép thời trang", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 4, Title = "Phụ kiện", Description = "Phụ kiện thời trang", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 5, Title = "Đồ lót", Description = "Đồ lót thời trang", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 6, Title = "Đầm", Description = "Đầm thời trang", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 7, Title = "Áo khoác", Description = "Áo khoác thời trang", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 8, Title = "Thời trang nam", Description = "Thời trang nam", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 9, Title = "Thời trang nữ", Description = "Thời trang nữ", CreateDate = DateTime.Now },
			//	new ProductCategory { Id = 10, Title = "Thời trang trẻ em", Description = "Thời trang trẻ em", CreateDate = DateTime.Now }
			//});


			//// Seed Roles
			//modelBuilder.Entity<Role>().HasData(
			//	new Role { Id = 1, RoleName = "Admin" },
			//	new Role { Id = 2, RoleName = "Employee" },
			//	new Role { Id = 3, RoleName = "Customer" }
			//);

			//// Seed data for Product
			//modelBuilder.Entity<Product>().HasData(new List<Product>
			//{
			//	new Product { Id = 1, Title = "Áo thun trắng", ProductCode = "AT01", ProductCategoryId = 1, Description = "Áo thun trắng cotton thoải mái", Detail = "Áo thun trắng, chất liệu cotton 100%, dễ dàng kết hợp với nhiều trang phục.", Image = "images/products/ao_thun_trang.jpg", Price = 150000, PriceSale = null, Quantity = 100, CreateDate = DateTime.Now },
			//	new Product { Id = 2, Title = "Quần jeans xanh", ProductCode = "QJ01", ProductCategoryId = 2, Description = "Quần jeans xanh, thời trang và bền bỉ", Detail = "Quần jeans màu xanh, chất liệu dày dặn, phong cách trẻ trung.", Image = "images/products/quan_jeans_xanh.jpg", Price = 250000, PriceSale = 200000, Quantity = 50, CreateDate = DateTime.Now },
			//	new Product { Id = 3, Title = "Giày thể thao", ProductCode = "GT01", ProductCategoryId = 3, Description = "Giày thể thao, phù hợp cho mọi hoạt động", Detail = "Giày thể thao với thiết kế năng động, thoáng khí.", Image = "images/products/giai_the_thao.jpg", Price = 350000, PriceSale = 300000, Quantity = 75, CreateDate = DateTime.Now },
			//	new Product { Id = 4, Title = "Mũ lưỡi trai", ProductCode = "MLT01", ProductCategoryId = 4, Description = "Mũ lưỡi trai thời trang", Detail = "Mũ lưỡi trai phong cách, có thể điều chỉnh kích cỡ.", Image = "images/products/mu_luoi_trai.jpg", Price = 80000, PriceSale = null, Quantity = 200, CreateDate = DateTime.Now },
			//	new Product { Id = 5, Title = "Đồ lót nữ", ProductCode = "DLN01", ProductCategoryId = 5, Description = "Đồ lót nữ mềm mại và thoải mái", Detail = "Đồ lót nữ, chất liệu cotton, tạo cảm giác dễ chịu.", Image = "images/products/do_lot_nu.jpg", Price = 120000, PriceSale = null, Quantity = 150, CreateDate = DateTime.Now },
			//	new Product { Id = 6, Title = "Đầm dạ hội", ProductCode = "DH01", ProductCategoryId = 6, Description = "Đầm dạ hội sang trọng", Detail = "Đầm dạ hội, thiết kế đẹp mắt, phù hợp cho các sự kiện.", Image = "images/products/dam_da_hội.jpg", Price = 600000, PriceSale = 500000, Quantity = 30, CreateDate = DateTime.Now },
			//	new Product { Id = 7, Title = "Áo khoác nữ", ProductCode = "AKN01", ProductCategoryId = 7, Description = "Áo khoác nữ thời trang", Detail = "Áo khoác nữ ấm áp, thiết kế thời trang.", Image = "images/products/ao_khoac_nu.jpg", Price = 400000, PriceSale = null, Quantity = 50, CreateDate = DateTime.Now },
			//	new Product { Id = 8, Title = "Thời trang nam", ProductCode = "TN01", ProductCategoryId = 8, Description = "Thời trang nam đa dạng", Detail = "Bộ sưu tập thời trang nam phong cách.", Image = "images/products/thoi_trang_nam.jpg", Price = 500000, PriceSale = null, Quantity = 60, CreateDate = DateTime.Now },
			//	new Product { Id = 9, Title = "Thời trang nữ", ProductCode = "TN02", ProductCategoryId = 9, Description = "Thời trang nữ đẹp mắt", Detail = "Bộ sưu tập thời trang nữ mới nhất.", Image = "images/products/thoi_trang_nu.jpg", Price = 450000, PriceSale = 400000, Quantity = 70, CreateDate = DateTime.Now },
			//	new Product { Id = 10, Title = "Thời trang trẻ em", ProductCode = "TT01", ProductCategoryId = 10, Description = "Thời trang trẻ em đáng yêu", Detail = "Bộ sưu tập thời trang trẻ em phong cách.", Image = "images/products/thoi_trang_tre_em.jpg", Price = 200000, PriceSale = null, Quantity = 80, CreateDate = DateTime.Now }
			//});


			//// Seed Customers
			//modelBuilder.Entity<Customer>().HasData(new List<Customer>
			//{
			//	new Customer { Id = 1, CompanyName = "Khách lẻ", ContactPerson = "Khách hàng", Email = "khachle@company.com", Password = "password1", PhoneNumber = "0123456789", Address = "Không xác định" },
			//	new Customer { Id = 2, CompanyName = "Công ty ABC", ContactPerson = "Nguyễn Văn A", Email = "abc@company.com", Password = "password2", PhoneNumber = "0987654321", Address = "123 Đường ABC, TP.HCM" },
			//	new Customer { Id = 3, CompanyName = "Công ty XYZ", ContactPerson = "Trần Thị B", Email = "xyz@company.com", Password = "password3", PhoneNumber = "0123456780", Address = "456 Đường XYZ, TP.HCM" },
			//	new Customer { Id = 4, CompanyName = "Công ty DEF", ContactPerson = "Lê Văn C", Email = "def@company.com", Password = "password4", PhoneNumber = "0987654312", Address = "789 Đường DEF, TP.HCM" },
			//	new Customer { Id = 5, CompanyName = "Công ty GHI", ContactPerson = "Phạm Thị D", Email = "ghi@company.com", Password = "password5", PhoneNumber = "0123456790", Address = "321 Đường GHI, TP.HCM" },
			//	new Customer { Id = 6, CompanyName = "Công ty JKL", ContactPerson = "Nguyễn Văn E", Email = "jkl@company.com", Password = "password6", PhoneNumber = "0987654301", Address = "654 Đường JKL, TP.HCM" },
			//	new Customer { Id = 7, CompanyName = "Công ty MNO", ContactPerson = "Trần Thị F", Email = "mno@company.com", Password = "password7", PhoneNumber = "0123456700", Address = "987 Đường MNO, TP.HCM" },
			//	new Customer { Id = 8, CompanyName = "Công ty PQR", ContactPerson = "Lê Văn G", Email = "pqr@company.com", Password = "password8", PhoneNumber = "0987654320", Address = "159 Đường PQR, TP.HCM" },
			//	new Customer { Id = 9, CompanyName = "Công ty STU", ContactPerson = "Phạm Thị H", Email = "stu@company.com", Password = "password9", PhoneNumber = "0123456781", Address = "753 Đường STU, TP.HCM" },
			//	new Customer { Id = 10, CompanyName = "Công ty VWX", ContactPerson = "Nguyễn Văn I", Email = "vwx@company.com", Password = "password10", PhoneNumber = "0987654322", Address = "951 Đường VWX, TP.HCM" }
			//});


			//// Seed Employees
			//modelBuilder.Entity<Employee>().HasData(new List<Employee>
			//{
			//	new Employee { Id = 1, CodeEmployee = "AD001", EmployeeName = "Admin", Email = "admin@lena.com", Password = "admin123", DateOfBirth = new DateTime(1990, 1, 1), PhoneNumber = "0901234567", Address = "123 Đường ABC, TP.HCM", JoinDate = new DateTime(2020, 1, 1), Status = true, RoleId = 1, Avatar = "admin_avatar.png", Position = "Admin" },
			//	new Employee { Id = 2, CodeEmployee = "QL001", EmployeeName = "Nguyễn Văn A", Email = "a@lena.com", Password = "password", DateOfBirth = new DateTime(1995, 2, 2), PhoneNumber = "0907654321", Address = "456 Đường XYZ, TP.HCM", JoinDate = new DateTime(2021, 2, 1), Status = true, RoleId = 2, Avatar = "a_avatar.png", Position = "Quản lý" },
			//	new Employee { Id = 3, CodeEmployee = "NV001", EmployeeName = "Trần Thị B", Email = "b@lena.com", Password = "password", DateOfBirth = new DateTime(1992, 3, 3), PhoneNumber = "0912345678", Address = "789 Đường DEF, TP.HCM", JoinDate = new DateTime(2021, 3, 1), Status = true, RoleId = 3, Avatar = "b_avatar.png", Position = "Nhân viên" },
			//	new Employee { Id = 4, CodeEmployee = "NV002", EmployeeName = "Lê Văn C", Email = "c@lena.com", Password = "password", DateOfBirth = new DateTime(1994, 4, 4), PhoneNumber = "0923456789", Address = "321 Đường GHI, TP.HCM", JoinDate = new DateTime(2021, 4, 1), Status = true, RoleId = 3, Avatar = "c_avatar.png", Position = "Nhân viên" },
			//	new Employee { Id = 5, CodeEmployee = "NV003", EmployeeName = "Phạm Thị D", Email = "d@lena.com", Password = "password", DateOfBirth = new DateTime(1990, 5, 5), PhoneNumber = "0934567890", Address = "654 Đường JKL, TP.HCM", JoinDate = new DateTime(2021, 5, 1), Status = true, RoleId = 3, Avatar = "d_avatar.png", Position = "Nhân viên" },
			//	new Employee { Id = 6, CodeEmployee = "NV004", EmployeeName = "Nguyễn Văn E", Email = "e@lena.com", Password = "password", DateOfBirth = new DateTime(1988, 6, 6), PhoneNumber = "0945678901", Address = "987 Đường MNO, TP.HCM", JoinDate = new DateTime(2021, 6, 1), Status = true, RoleId = 3, Avatar = "e_avatar.png", Position = "Nhân viên" },
			//	new Employee { Id = 7, CodeEmployee = "NV005", EmployeeName = "Trần Thị F", Email = "f@lena.com", Password = "password", DateOfBirth = new DateTime(1993, 7, 7), PhoneNumber = "0956789012", Address = "159 Đường PQR, TP.HCM", JoinDate = new DateTime(2021, 7, 1), Status = true, RoleId = 3, Avatar = "f_avatar.png", Position = "Nhân viên" },
			//	new Employee { Id = 8, CodeEmployee = "NV006", EmployeeName = "Lê Văn G", Email = "g@lena.com", Password = "password", DateOfBirth = new DateTime(1995, 8, 8), PhoneNumber = "0967890123", Address = "753 Đường STU, TP.HCM", JoinDate = new DateTime(2021, 8, 1), Status = true, RoleId = 3, Avatar = "g_avatar.png", Position = "Nhân viên" },
			//	new Employee { Id = 9, CodeEmployee = "NV007", EmployeeName = "Phạm Thị H", Email = "h@lena.com", Password = "password", DateOfBirth = new DateTime(1991, 9, 9), PhoneNumber = "0978901234", Address = "369 Đường VWX, TP.HCM", JoinDate = new DateTime(2021, 9, 1), Status = true, RoleId = 3, Avatar = "h_avatar.png", Position = "Nhân viên" },
			//	new Employee { Id = 10, CodeEmployee = "NV008", EmployeeName = "Nguyễn Văn I", Email = "i@lena.com", Password = "password", DateOfBirth = new DateTime(1989, 10, 10), PhoneNumber = "0989012345", Address = "852 Đường YZA, TP.HCM", JoinDate = new DateTime(2021, 10, 1), Status = true, RoleId = 3, Avatar = "i_avatar.png", Position = "Nhân viên" }
			//});

			//modelBuilder.Entity<QRCodeRequest>().HasData(new List<QRCodeRequest>
			//{
			//	new QRCodeRequest { Id = 1, AccountNo = "34509092002", AccountName = "NGUYEN BAO NGOC", AcqId = "970422", AddInfo = "Thông tin bổ sung 1", Template = "Template1", CreatedAt = DateTime.Now },
			//	new QRCodeRequest { Id = 2, AccountNo = "0913710873", AccountName = "NGUYEN BAO NGOC", AcqId = "970422", AddInfo = "Thông tin bổ sung 2", Template = "Template2", CreatedAt = DateTime.Now },
			//});



		}
	}
}
