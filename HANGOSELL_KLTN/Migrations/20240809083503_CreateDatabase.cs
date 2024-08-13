using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HANGOSELL_KLTN.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Adv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Adv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoKeyword = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoKeyword = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Subscribe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Subscribe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_SystemSetting",
                columns: table => new
                {
                    SettingKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SettingDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_SystemSetting", x => x.SettingKey);
                });

            migrationBuilder.CreateTable(
                name: "tb_News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoKeyword = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_News_tb_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tb_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoKeyword = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Posts_tb_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tb_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    IsSale = table.Column<bool>(type: "bit", nullable: false),
                    IsFeature = table.Column<bool>(type: "bit", nullable: false),
                    IsHot = table.Column<bool>(type: "bit", nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoKeyword = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Product_tb_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "tb_ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeEmployee = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Employee_tb_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "tb_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tb_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tb_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Payment_tb_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tb_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Payment_tb_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tb_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_Category",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Description", "ModifiedBy", "ModifiedDate", "Position", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, "Find the latest electronics here.", "electronics, gadgets", "Electronics Category", "Electronics" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 2, "Browse our collection of books.", "books, literature", "Books Category", "Books" }
                });

            migrationBuilder.InsertData(
                table: "tb_Customer",
                columns: new[] { "Id", "Address", "CompanyName", "ContactPerson", "CreateBy", "CreateDate", "Email", "ModifiedBy", "ModifiedDate", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "ABC Corporation", "John Doe", null, new DateTime(2024, 8, 9, 15, 35, 2, 851, DateTimeKind.Local).AddTicks(9937), "john.doe@example.com", null, null, "password123", "123-456-7890" },
                    { 2, "456 Elm St", "XYZ Enterprises", "Jane Smith", null, new DateTime(2024, 8, 9, 15, 35, 2, 851, DateTimeKind.Local).AddTicks(9947), "jane.smith@example.com", null, null, "password456", "987-654-3210" }
                });

            migrationBuilder.InsertData(
                table: "tb_Order",
                columns: new[] { "Id", "Address", "Code", "CreateBy", "CreateDate", "CustomerName", "ModifiedBy", "ModifiedDate", "Phone", "Quantity", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "123 Main St", "ORD001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", null, null, "123-456-7890", 2, 1019.98m },
                    { 2, "456 Elm St", "ORD002", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", null, null, "987-654-3210", 1, 19.99m }
                });

            migrationBuilder.InsertData(
                table: "tb_ProductCategory",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Description", "Icon", "ModifiedBy", "ModifiedDate", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronic items", "electronics.png", null, null, "Electronic products", "electronics", "Electronics Category", "Electronics" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books and literature", "books.png", null, null, "Books and literature", "books", "Books Category", "Books" }
                });

            migrationBuilder.InsertData(
                table: "tb_Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "tb_Subscribe",
                columns: new[] { "Id", "CreateDate", "Email" },
                values: new object[] { 1, new DateTime(2024, 8, 9, 15, 35, 2, 852, DateTimeKind.Local).AddTicks(92), "subscriber@example.com" });

            migrationBuilder.InsertData(
                table: "tb_SystemSetting",
                columns: new[] { "SettingKey", "SettingDescription", "SettingValue" },
                values: new object[,]
                {
                    { "SiteName", "The name of the website", "My Shop" },
                    { "SiteUrl", "The URL of the website", "https://www.myshop.com" }
                });

            migrationBuilder.InsertData(
                table: "tb_Employee",
                columns: new[] { "Id", "Address", "Avatar", "CodeEmployee", "CreateBy", "CreateDate", "DateOfBirth", "Email", "EmployeeName", "JoinDate", "ModifiedBy", "ModifiedDate", "Password", "PhoneNumber", "Position", "RoleID", "Status" },
                values: new object[,]
                {
                    { 1, "789 Maple St", "alice.jpg", "EMP001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice Johnson", new DateTime(2024, 8, 9, 15, 35, 2, 851, DateTimeKind.Local).AddTicks(9971), null, null, "password123", "555-1234", "Manager", 1, true },
                    { 2, "321 Oak St", "bob.jpg", "EMP002", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob Brown", new DateTime(2024, 8, 9, 15, 35, 2, 851, DateTimeKind.Local).AddTicks(9974), null, null, "password456", "555-5678", "Sales Clerk", 2, true }
                });

            migrationBuilder.InsertData(
                table: "tb_News",
                columns: new[] { "Id", "CategoryId", "CreateBy", "CreateDate", "Description", "Detail", "Image", "ModifiedBy", "ModifiedDate", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Update on the latest technology trends.", null, "tech-news.jpg", null, null, "Latest updates on technology.", "technology, news", "Tech News", "Latest Tech News" });

            migrationBuilder.InsertData(
                table: "tb_Posts",
                columns: new[] { "Id", "CategoryId", "CreateBy", "CreateDate", "Description", "Detail", "Image", "ModifiedBy", "ModifiedDate", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introducing our new product.", null, "product-launch.jpg", null, null, "New product launch details.", "product, launch", "Product Launch", "New Product Launch" });

            migrationBuilder.InsertData(
                table: "tb_Product",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Description", "Detail", "Image", "IsFeature", "IsHome", "IsHot", "IsSale", "ModifiedBy", "ModifiedDate", "Price", "PriceSale", "ProductCategoryId", "ProductCode", "Quantity", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, false, false, false, null, null, 999.99m, null, 1, "LPT123", 10, "A high-performance laptop for all your needs.", "laptop, electronics", "High Performance Laptop", "Laptop" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, false, false, false, null, null, 19.99m, null, 2, "NOV456", 100, "A bestselling novel for avid readers.", "novel, literature", "Bestselling Novel", "Novel" }
                });

            migrationBuilder.InsertData(
                table: "tb_OrderDetail",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 999.99m, 1, 1 },
                    { 2, 1, 19.99m, 2, 1 },
                    { 3, 2, 19.99m, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "tb_Payment",
                columns: new[] { "Id", "Amount", "EmployeeId", "Notes", "OrderId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 1019.98m, 1, null, 1, new DateTime(2024, 8, 9, 15, 35, 2, 852, DateTimeKind.Local).AddTicks(17), "Credit Card" },
                    { 2, 19.99m, 2, null, 2, new DateTime(2024, 8, 9, 15, 35, 2, 852, DateTimeKind.Local).AddTicks(19), "PayPal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Category_Title",
                table: "tb_Category",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Employee_RoleID",
                table: "tb_Employee",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_News_CategoryId",
                table: "tb_News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Order_Code",
                table: "tb_Order",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_OrderDetail_OrderId",
                table: "tb_OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OrderDetail_ProductId",
                table: "tb_OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Payment_EmployeeId",
                table: "tb_Payment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Payment_OrderId",
                table: "tb_Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Posts_CategoryId",
                table: "tb_Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Product_ProductCategoryId",
                table: "tb_Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Product_ProductCode",
                table: "tb_Product",
                column: "ProductCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Adv");

            migrationBuilder.DropTable(
                name: "tb_Contact");

            migrationBuilder.DropTable(
                name: "tb_Customer");

            migrationBuilder.DropTable(
                name: "tb_News");

            migrationBuilder.DropTable(
                name: "tb_OrderDetail");

            migrationBuilder.DropTable(
                name: "tb_Payment");

            migrationBuilder.DropTable(
                name: "tb_Posts");

            migrationBuilder.DropTable(
                name: "tb_Subscribe");

            migrationBuilder.DropTable(
                name: "tb_SystemSetting");

            migrationBuilder.DropTable(
                name: "tb_Product");

            migrationBuilder.DropTable(
                name: "tb_Employee");

            migrationBuilder.DropTable(
                name: "tb_Order");

            migrationBuilder.DropTable(
                name: "tb_Category");

            migrationBuilder.DropTable(
                name: "tb_ProductCategory");

            migrationBuilder.DropTable(
                name: "tb_Role");
        }
    }
}
