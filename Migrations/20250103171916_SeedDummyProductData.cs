using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartifyWebsite.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Keywords_EN",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Keywords_ES",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Keywords_TR",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductPhotoPath1",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "CategoryName_EN", "CategoryName_ES", "CategoryName_TR" },
                values: new object[,]
                {
                    { 1, "Web Applications", "Aplicaciones Web", "Web Uygulamaları" },
                    { 2, "Desktop Applications", "Aplicaciones de Escritorio", "Masaüstü Uygulamaları" },
                    { 3, "Mobile Applications", "Aplicaciones de Móviles", "Mobil Uygulamalar" },
                    { 4, "Web Design", "Diseño Web", "Web Tasarım" },
                    { 5, "E Commerce", "Comercio Electrónico", "E Ticaret" },
                    { 6, "BI and Reporting", "BI y Reportes", "İş Zekası ve Raporlama" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreatedDate", "Description_EN", "Description_ES", "Description_TR", "IsActive", "Keywords_EN", "Keywords_ES", "Keywords_TR", "Name_EN", "Name_ES", "Name_TR", "Price", "ProductCode", "ProductPhotoPath1" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2671), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "WebApp Pro", "WebApp Pro", "WebApp Pro", 199.99m, "WA-001", "~/images/products/defaultProductImage.jpeg" },
                    { 2, 1, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2679), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "WebApp Basic", "WebApp Basic", "WebApp Basic", 99.99m, "WA-002", "~/images/products/defaultProductImage.jpeg" },
                    { 3, 1, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2682), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "WebApp Advanced", "WebApp Advanced", "WebApp Advanced", 299.99m, "WA-003", "~/images/products/defaultProductImage.jpeg" },
                    { 4, 1, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2685), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "WebApp Pro Plus", "WebApp Pro Plus", "WebApp Pro Plus", 249.99m, "WA-004", "~/images/products/defaultProductImage.jpeg" },
                    { 5, 1, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2687), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "WebApp Starter", "WebApp Starter", "WebApp Starter", 49.99m, "WA-005", "~/images/products/defaultProductImage.jpeg" },
                    { 6, 2, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2689), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "DeskApp Pro", "DeskApp Pro", "DeskApp Pro", 159.99m, "DA-001", "~/images/products/defaultProductImage.jpeg" },
                    { 7, 2, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2691), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "DeskApp Basic", "DeskApp Basic", "DeskApp Basic", 79.99m, "DA-002", "~/images/products/defaultProductImage.jpeg" },
                    { 8, 2, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2693), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "DeskApp Advanced", "DeskApp Advanced", "DeskApp Advanced", 259.99m, "DA-003", "~/images/products/defaultProductImage.jpeg" },
                    { 9, 2, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2694), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "DeskApp Pro Plus", "DeskApp Pro Plus", "DeskApp Pro Plus", 209.99m, "DA-004", "~/images/products/defaultProductImage.jpeg" },
                    { 10, 2, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2696), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "DeskApp Starter", "DeskApp Starter", "DeskApp Starter", 59.99m, "DA-005", "~/images/products/defaultProductImage.jpeg" },
                    { 11, 3, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2699), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "MobileApp Basic", "Aplicación Móvil Básica", "Mobil Uygulama Başlangıç", 59.99m, "MA-001", "~/images/products/defaultProductImage.jpeg" },
                    { 12, 3, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2701), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "MobileApp Pro", "Aplicación Móvil Pro", "Mobil Uygulama Pro", 159.99m, "MA-002", "~/images/products/defaultProductImage.jpeg" },
                    { 13, 4, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2703), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "Website for Advocates", "Website for Advocates", "Avukatlar İçin Websitesi", 59.99m, "WD-001", "~/images/products/defaultProductImage.jpeg" },
                    { 14, 4, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2705), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "Website for Doctors", "Website for Doctors", "Doktorlar İçin Websitesi", 159.99m, "WD-002", "~/images/products/defaultProductImage.jpeg" },
                    { 15, 5, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2707), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "Website for Natural Product Shop", "Website for Natural Product Sellers", "Doğal Ürün Satıcıları İçin Websitesi", 59.99m, "EC-001", "~/images/products/defaultProductImage.jpeg" },
                    { 16, 5, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2709), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "Website for Beauty Shop", "Website for Beauty Shop", "Güzellik Ürünleri İçin Websitesi", 159.99m, "EC-002", "~/images/products/defaultProductImage.jpeg" },
                    { 17, 6, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2712), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "Kanban Card Excel Template", "Kanban Card Excel Template", "Kanban Kart Excel Şablonu", 19.99m, "BI-001", "~/images/products/defaultProductImage.jpeg" },
                    { 18, 6, new DateTime(2025, 1, 3, 17, 19, 15, 132, DateTimeKind.Utc).AddTicks(2717), "some desc here", "some desc here", "some desc here", true, "some keywords here", "some keywords here", "some keywords here", "Monthly Budget Excel Template", "Monthly Budget Excel Template", "Aylık Bütçe Excel Şablonu", 19.99m, "BI-002", "~/images/products/defaultProductImage.jpeg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategory_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategory_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Keywords_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Keywords_ES",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Keywords_TR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPhotoPath1",
                table: "Products");
        }
    }
}
