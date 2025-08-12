using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnaSayfaEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnaSayfa",
                table: "Bisikletler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklemeTarihi",
                value: new DateTime(2025, 8, 12, 16, 42, 17, 169, DateTimeKind.Local).AddTicks(8069));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnaSayfa",
                table: "Bisikletler");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklemeTarihi",
                value: new DateTime(2025, 8, 8, 14, 30, 44, 343, DateTimeKind.Local).AddTicks(4239));
        }
    }
}
