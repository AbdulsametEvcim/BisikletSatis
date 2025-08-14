using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserGuidEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Kullanicilar",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeTarihi", "UserGuid" },
                values: new object[] { new DateTime(2025, 8, 14, 11, 44, 57, 825, DateTimeKind.Local).AddTicks(9395), new Guid("dc6cdca2-3ac6-4654-98d1-37a20c19b580") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Kullanicilar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklemeTarihi",
                value: new DateTime(2025, 8, 12, 16, 42, 17, 169, DateTimeKind.Local).AddTicks(8069));
        }
    }
}
