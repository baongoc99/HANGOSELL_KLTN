using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HANGOSELL_KLTN.Migrations
{
    /// <inheritdoc />
    public partial class updatedb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QRCodeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcqId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCodeRequests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "tb_Subscribe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 26, 19, 50, 58, 581, DateTimeKind.Local).AddTicks(259));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QRCodeRequests");

            migrationBuilder.UpdateData(
                table: "tb_Subscribe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 8, 26, 19, 4, 47, 573, DateTimeKind.Local).AddTicks(2861));
        }
    }
}
