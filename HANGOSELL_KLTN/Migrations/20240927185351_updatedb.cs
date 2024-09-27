using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HANGOSELL_KLTN.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_Subscribe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_SystemSetting",
                keyColumn: "SettingKey",
                keyValue: "SiteName");

            migrationBuilder.DeleteData(
                table: "tb_SystemSetting",
                keyColumn: "SettingKey",
                keyValue: "SiteUrl");

            migrationBuilder.InsertData(
                table: "QRCodeRequests",
                columns: new[] { "Id", "AccountName", "AccountNo", "AcqId", "AddInfo", "CreatedAt", "Template" },
                values: new object[,]
                {
                    { 1, "NGUYEN BAO NGOC", "34509092002", "970422", "Thông tin bổ sung 1", new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6909), "Template1" },
                    { 2, "NGUYEN BAO NGOC", "0913710873", "970422", "Thông tin bổ sung 2", new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6913), "Template2" }
                });

            migrationBuilder.UpdateData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "ContactPerson", "Email", "Password", "PhoneNumber" },
                values: new object[] { "Không xác định", "Khách hàng", "khachle@company.com", "password1", "0123456789" });

            migrationBuilder.UpdateData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CompanyName", "ContactPerson", "Email", "Password" },
                values: new object[] { "123 Đường ABC, TP.HCM", "Công ty ABC", "Nguyễn Văn A", "abc@company.com", "password2" });

            migrationBuilder.UpdateData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CompanyName", "ContactPerson", "Email", "Password", "PhoneNumber" },
                values: new object[] { "456 Đường XYZ, TP.HCM", "Công ty XYZ", "Trần Thị B", "xyz@company.com", "password3", "0123456780" });

            migrationBuilder.InsertData(
                table: "tb_Customer",
                columns: new[] { "Id", "Address", "CompanyName", "ContactPerson", "CreateBy", "CreateDate", "Email", "ModifiedBy", "ModifiedDate", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 4, "789 Đường DEF, TP.HCM", "Công ty DEF", "Lê Văn C", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "def@company.com", null, null, "password4", "0987654312" },
                    { 5, "321 Đường GHI, TP.HCM", "Công ty GHI", "Phạm Thị D", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ghi@company.com", null, null, "password5", "0123456790" },
                    { 6, "654 Đường JKL, TP.HCM", "Công ty JKL", "Nguyễn Văn E", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkl@company.com", null, null, "password6", "0987654301" },
                    { 7, "987 Đường MNO, TP.HCM", "Công ty MNO", "Trần Thị F", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mno@company.com", null, null, "password7", "0123456700" },
                    { 8, "159 Đường PQR, TP.HCM", "Công ty PQR", "Lê Văn G", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pqr@company.com", null, null, "password8", "0987654320" },
                    { 9, "753 Đường STU, TP.HCM", "Công ty STU", "Phạm Thị H", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "stu@company.com", null, null, "password9", "0123456781" },
                    { 10, "951 Đường VWX, TP.HCM", "Công ty VWX", "Nguyễn Văn I", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vwx@company.com", null, null, "password10", "0987654322" }
                });

            migrationBuilder.UpdateData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "CodeEmployee", "DateOfBirth", "Email", "EmployeeName", "JoinDate", "Password", "PhoneNumber", "Position" },
                values: new object[] { "admin_avatar.png", "AD001", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@lena.com", "Admin", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin123", "0901234567", "Admin" });

            migrationBuilder.UpdateData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Avatar", "CodeEmployee", "DateOfBirth", "Email", "EmployeeName", "JoinDate", "Password", "PhoneNumber", "Position", "Status" },
                values: new object[] { "456 Đường XYZ, TP.HCM", "a_avatar.png", "QL001", new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "a@lena.com", "Nguyễn Văn A", new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", "0907654321", "Quản lý", true });

            migrationBuilder.InsertData(
                table: "tb_Employee",
                columns: new[] { "Id", "Address", "Avatar", "CodeEmployee", "CreateBy", "CreateDate", "DateOfBirth", "Email", "EmployeeName", "JoinDate", "ModifiedBy", "ModifiedDate", "Password", "PhoneNumber", "Position", "RoleID", "Status" },
                values: new object[,]
                {
                    { 3, "789 Đường DEF, TP.HCM", "b_avatar.png", "NV001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b@lena.com", "Trần Thị B", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0912345678", "Nhân viên", 3, true },
                    { 4, "321 Đường GHI, TP.HCM", "c_avatar.png", "NV002", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "c@lena.com", "Lê Văn C", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0923456789", "Nhân viên", 3, true },
                    { 5, "654 Đường JKL, TP.HCM", "d_avatar.png", "NV003", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "d@lena.com", "Phạm Thị D", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0934567890", "Nhân viên", 3, true },
                    { 6, "987 Đường MNO, TP.HCM", "e_avatar.png", "NV004", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "e@lena.com", "Nguyễn Văn E", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0945678901", "Nhân viên", 3, true },
                    { 7, "159 Đường PQR, TP.HCM", "f_avatar.png", "NV005", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "f@lena.com", "Trần Thị F", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0956789012", "Nhân viên", 3, true },
                    { 8, "753 Đường STU, TP.HCM", "g_avatar.png", "NV006", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "g@lena.com", "Lê Văn G", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0967890123", "Nhân viên", 3, true },
                    { 9, "369 Đường VWX, TP.HCM", "h_avatar.png", "NV007", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "h@lena.com", "Phạm Thị H", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0978901234", "Nhân viên", 3, true },
                    { 10, "852 Đường YZA, TP.HCM", "i_avatar.png", "NV008", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "i@lena.com", "Nguyễn Văn I", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "password", "0989012345", "Nhân viên", 3, true }
                });

            migrationBuilder.UpdateData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Detail", "Image", "Title" },
                values: new object[] { new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6690), "Áo thun trắng cotton thoải mái", "Áo thun trắng, chất liệu cotton 100%, dễ dàng kết hợp với nhiều trang phục.", "images/products/ao_thun_trang.jpg", "Áo thun trắng" });

            migrationBuilder.UpdateData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Detail", "Image", "PriceSale", "Title" },
                values: new object[] { new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6696), "Quần jeans xanh, thời trang và bền bỉ", "Quần jeans màu xanh, chất liệu dày dặn, phong cách trẻ trung.", "images/products/quan_jeans_xanh.jpg", 200000m, "Quần jeans xanh" });

            migrationBuilder.UpdateData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Icon", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6477), "Các loại áo thời trang", null, null, null, null, "Áo" });

            migrationBuilder.UpdateData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Icon", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6490), "Các loại quần thời trang", null, null, null, null, "Quần" });

            migrationBuilder.InsertData(
                table: "tb_ProductCategory",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Description", "Icon", "ModifiedBy", "ModifiedDate", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[,]
                {
                    { 3, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6492), "Giày dép thời trang", null, null, null, null, null, null, "Giày" },
                    { 4, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6493), "Phụ kiện thời trang", null, null, null, null, null, null, "Phụ kiện" },
                    { 5, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6495), "Đồ lót thời trang", null, null, null, null, null, null, "Đồ lót" },
                    { 6, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6498), "Đầm thời trang", null, null, null, null, null, null, "Đầm" },
                    { 7, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6499), "Áo khoác thời trang", null, null, null, null, null, null, "Áo khoác" },
                    { 8, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6501), "Thời trang nam", null, null, null, null, null, null, "Thời trang nam" },
                    { 9, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6503), "Thời trang nữ", null, null, null, null, null, null, "Thời trang nữ" },
                    { 10, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6505), "Thời trang trẻ em", null, null, null, null, null, null, "Thời trang trẻ em" }
                });

            migrationBuilder.InsertData(
                table: "tb_Product",
                columns: new[] { "Id", "CreateBy", "CreateDate", "Description", "Detail", "Image", "ModifiedBy", "ModifiedDate", "Price", "PriceSale", "ProductCategoryId", "ProductCode", "Quantity", "Title" },
                values: new object[,]
                {
                    { 3, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6698), "Giày thể thao, phù hợp cho mọi hoạt động", "Giày thể thao với thiết kế năng động, thoáng khí.", "images/products/giai_the_thao.jpg", null, null, 350000m, 300000m, 3, "GT01", 75, "Giày thể thao" },
                    { 4, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6701), "Mũ lưỡi trai thời trang", "Mũ lưỡi trai phong cách, có thể điều chỉnh kích cỡ.", "images/products/mu_luoi_trai.jpg", null, null, 80000m, null, 4, "MLT01", 200, "Mũ lưỡi trai" },
                    { 5, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6703), "Đồ lót nữ mềm mại và thoải mái", "Đồ lót nữ, chất liệu cotton, tạo cảm giác dễ chịu.", "images/products/do_lot_nu.jpg", null, null, 120000m, null, 5, "DLN01", 150, "Đồ lót nữ" },
                    { 6, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6707), "Đầm dạ hội sang trọng", "Đầm dạ hội, thiết kế đẹp mắt, phù hợp cho các sự kiện.", "images/products/dam_da_hội.jpg", null, null, 600000m, 500000m, 6, "DH01", 30, "Đầm dạ hội" },
                    { 7, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6748), "Áo khoác nữ thời trang", "Áo khoác nữ ấm áp, thiết kế thời trang.", "images/products/ao_khoac_nu.jpg", null, null, 400000m, null, 7, "AKN01", 50, "Áo khoác nữ" },
                    { 8, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6751), "Thời trang nam đa dạng", "Bộ sưu tập thời trang nam phong cách.", "images/products/thoi_trang_nam.jpg", null, null, 500000m, null, 8, "TN01", 60, "Thời trang nam" },
                    { 9, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6754), "Thời trang nữ đẹp mắt", "Bộ sưu tập thời trang nữ mới nhất.", "images/products/thoi_trang_nu.jpg", null, null, 450000m, 400000m, 9, "TN02", 70, "Thời trang nữ" },
                    { 10, null, new DateTime(2024, 9, 28, 1, 53, 50, 254, DateTimeKind.Local).AddTicks(6757), "Thời trang trẻ em đáng yêu", "Bộ sưu tập thời trang trẻ em phong cách.", "images/products/thoi_trang_tre_em.jpg", null, null, 200000m, null, 10, "TT01", 80, "Thời trang trẻ em" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QRCodeRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QRCodeRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "ContactPerson", "Email", "Password", "PhoneNumber" },
                values: new object[] { "Không có địa chỉ", "Khách lẻ", "khach.le@example.com", "hashed_password_3", "0000000000" });

            migrationBuilder.UpdateData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CompanyName", "ContactPerson", "Email", "Password" },
                values: new object[] { "456 Đường DEF, Hà Nội", "Công ty CP XYZ", "Trần Thị B", "b.tran@xyz.com", "hashed_password_2" });

            migrationBuilder.UpdateData(
                table: "tb_Customer",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CompanyName", "ContactPerson", "Email", "Password", "PhoneNumber" },
                values: new object[] { "123 Đường ABC, TP.HCM", "Công ty TNHH ABC", "Nguyễn Văn A", "a.nguyen@abc.com", "hashed_password_1", "0912345678" });

            migrationBuilder.UpdateData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "CodeEmployee", "DateOfBirth", "Email", "EmployeeName", "JoinDate", "Password", "PhoneNumber", "Position" },
                values: new object[] { "avatar1.png", "EMP001", new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "a.nguyen@example.com", "Nguyễn Văn A", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "hashed_password_1", "0912345678", "Senior Developer" });

            migrationBuilder.UpdateData(
                table: "tb_Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Avatar", "CodeEmployee", "DateOfBirth", "Email", "EmployeeName", "JoinDate", "Password", "PhoneNumber", "Position", "Status" },
                values: new object[] { "456 Đường DEF, Hà Nội", "avatar2.png", "EMP002", new DateTime(1985, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "b.tran@example.com", "Trần Thị B", new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "hashed_password_2", "0987654321", "Junior Developer", false });

            migrationBuilder.InsertData(
                table: "tb_News",
                columns: new[] { "Id", "CategoryId", "CreateBy", "CreateDate", "Description", "Detail", "Image", "ModifiedBy", "ModifiedDate", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Update on the latest technology trends.", null, "tech-news.jpg", null, null, "Latest updates on technology.", "technology, news", "Tech News", "Latest Tech News" });

            migrationBuilder.InsertData(
                table: "tb_Posts",
                columns: new[] { "Id", "CategoryId", "CreateBy", "CreateDate", "Description", "Detail", "Image", "ModifiedBy", "ModifiedDate", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introducing our new product.", null, "product-launch.jpg", null, null, "New product launch details.", "product, launch", "Product Launch", "New Product Launch" });

            migrationBuilder.UpdateData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Detail", "Image", "Title" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áo thun trắng đơn giản, thoải mái.", null, null, "Áo Thun Trắng" });

            migrationBuilder.UpdateData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Detail", "Image", "PriceSale", "Title" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quần jeans xanh, kiểu dáng trẻ trung.", null, null, null, "Quần Jeans Xanh" });

            migrationBuilder.UpdateData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Icon", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áo thun các loại.", "icon-t-shirt", "Áo thun đa dạng mẫu mã và màu sắc.", "ao thun, ao phông", "Áo Thun", "Áo Thun" });

            migrationBuilder.UpdateData(
                table: "tb_ProductCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Icon", "SeoDescription", "SeoKeyword", "SeoTitle", "Title" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quần jeans thời trang.", "icon-jeans", "Quần jeans phù hợp với nhiều phong cách.", "quan jeans, jeans", "Quần Jeans", "Quần Jeans" });

            migrationBuilder.InsertData(
                table: "tb_Subscribe",
                columns: new[] { "Id", "CreateDate", "Email" },
                values: new object[] { 1, new DateTime(2024, 9, 10, 16, 11, 13, 160, DateTimeKind.Local).AddTicks(3010), "subscriber@example.com" });

            migrationBuilder.InsertData(
                table: "tb_SystemSetting",
                columns: new[] { "SettingKey", "SettingDescription", "SettingValue" },
                values: new object[,]
                {
                    { "SiteName", "The name of the website", "My Shop" },
                    { "SiteUrl", "The URL of the website", "https://www.myshop.com" }
                });
        }
    }
}
