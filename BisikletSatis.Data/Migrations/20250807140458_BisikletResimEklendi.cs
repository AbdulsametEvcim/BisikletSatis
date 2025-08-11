using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class BisikletResimEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resim1",
                table: "Bisikletler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resim2",
                table: "Bisikletler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resim3",
                table: "Bisikletler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklemeTarihi",
                value: new DateTime(2025, 8, 7, 17, 4, 57, 586, DateTimeKind.Local).AddTicks(2520));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resim1",
                table: "Bisikletler");

            migrationBuilder.DropColumn(
                name: "Resim2",
                table: "Bisikletler");

            migrationBuilder.DropColumn(
                name: "Resim3",
                table: "Bisikletler");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklemeTarihi",
                value: new DateTime(2025, 8, 4, 14, 21, 37, 584, DateTimeKind.Local).AddTicks(9849));
        }
    }
}
