using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HANGOSELL_KLTN.Migrations
{
    /// <inheritdoc />
    public partial class updateqr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_Subscribe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 26, 15, 27, 28, 233, DateTimeKind.Local).AddTicks(7911));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_Subscribe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 22, 9, 6, 23, 238, DateTimeKind.Local).AddTicks(3815));
        }
    }
}
