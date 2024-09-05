using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HANGOSELL_KLTN.Migrations
{
    /// <inheritdoc />
    public partial class updateproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeature",
                table: "tb_Product");

            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "tb_Product");

            migrationBuilder.DropColumn(
                name: "IsHot",
                table: "tb_Product");

            migrationBuilder.DropColumn(
                name: "IsSale",
                table: "tb_Product");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "tb_Product");

            migrationBuilder.DropColumn(
                name: "SeoKeyword",
                table: "tb_Product");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "tb_Product");

            migrationBuilder.UpdateData(
                table: "tb_Subscribe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 9, 5, 10, 45, 0, 752, DateTimeKind.Local).AddTicks(8782));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeature",
                table: "tb_Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "tb_Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHot",
                table: "tb_Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSale",
                table: "tb_Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "tb_Product",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeyword",
                table: "tb_Product",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "tb_Product",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsFeature", "IsHome", "IsHot", "IsSale", "SeoDescription", "SeoKeyword", "SeoTitle" },
                values: new object[] { true, true, false, false, "Áo thun trắng với chất liệu vải cao cấp.", "ao thun trang, thun", "Áo Thun Trắng" });

            migrationBuilder.UpdateData(
                table: "tb_Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsFeature", "IsHome", "IsHot", "IsSale", "SeoDescription", "SeoKeyword", "SeoTitle" },
                values: new object[] { false, false, true, true, "Quần jeans xanh với thiết kế hiện đại.", "quan jeans xanh, jeans", "Quần Jeans Xanh" });

            migrationBuilder.UpdateData(
                table: "tb_Subscribe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 26, 19, 50, 58, 581, DateTimeKind.Local).AddTicks(259));
        }
    }
}
