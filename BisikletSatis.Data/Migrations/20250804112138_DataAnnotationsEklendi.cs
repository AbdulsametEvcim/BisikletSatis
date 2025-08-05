using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisikletSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotationsEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServisenCikisTarihi",
                table: "Tamirhaneler",
                newName: "ServistenCikisTarihi");

            migrationBuilder.RenameColumn(
                name: "GarantiKapsamindaMİ",
                table: "Tamirhaneler",
                newName: "GarantiKapsamindaMi");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklemeTarihi",
                value: new DateTime(2025, 8, 4, 14, 21, 37, 584, DateTimeKind.Local).AddTicks(9849));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServistenCikisTarihi",
                table: "Tamirhaneler",
                newName: "ServisenCikisTarihi");

            migrationBuilder.RenameColumn(
                name: "GarantiKapsamindaMi",
                table: "Tamirhaneler",
                newName: "GarantiKapsamindaMİ");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklemeTarihi",
                value: new DateTime(2025, 7, 31, 14, 58, 42, 218, DateTimeKind.Local).AddTicks(4679));
        }
    }
}
