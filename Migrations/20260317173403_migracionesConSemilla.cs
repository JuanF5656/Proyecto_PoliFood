using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Polifood.Migrations
{
    /// <inheritdoc />
    public partial class migracionesConSemilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Product_product_id",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_product_id",
                table: "Store");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "product_id",
                table: "Store",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "productId",
                table: "Store",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "status" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000002"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000003"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000004"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000005"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000006"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000007"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000008"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000009"), 1 },
                    { new Guid("30000000-0000-0000-0000-000000000010"), 1 },
                    { new Guid("30000000-0000-0000-0000-000000000011"), 1 },
                    { new Guid("30000000-0000-0000-0000-000000000012"), 1 },
                    { new Guid("30000000-0000-0000-0000-000000000013"), 2 },
                    { new Guid("30000000-0000-0000-0000-000000000014"), 2 },
                    { new Guid("30000000-0000-0000-0000-000000000015"), 2 },
                    { new Guid("30000000-0000-0000-0000-000000000016"), 3 },
                    { new Guid("30000000-0000-0000-0000-000000000017"), 3 },
                    { new Guid("30000000-0000-0000-0000-000000000018"), 3 },
                    { new Guid("30000000-0000-0000-0000-000000000019"), 3 },
                    { new Guid("30000000-0000-0000-0000-000000000020"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "product_id", "CartId", "is_active", "is_available", "prepTimeMinutes", "product_description", "product_image", "product_name", "product_price" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), null, 1, true, 15, "Hamburguesa con carne, queso y vegetales", "burger1.jpg", "Hamburguesa Clásica", 5000 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), null, 1, true, 20, "Pizza individual de queso y pepperoni", "pizza1.jpg", "Pizza Personal", 4000 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), null, 1, true, 10, "Pan con salchicha, papitas y salsas", "hotdog.jpg", "Perro Caliente", 3500 },
                    { new Guid("20000000-0000-0000-0000-000000000004"), null, 1, true, 12, "Tacos de carne con vegetales", "tacos.jpg", "Tacos", 4200 },
                    { new Guid("20000000-0000-0000-0000-000000000005"), null, 1, true, 14, "Burrito de pollo y arroz", "burrito.jpg", "Burrito", 4700 },
                    { new Guid("20000000-0000-0000-0000-000000000006"), null, 1, true, 8, "Nachos con queso y carne", "nachos.jpg", "Nachos", 3900 },
                    { new Guid("20000000-0000-0000-0000-000000000007"), null, 1, true, 9, "Ensalada fresca con pollo", "salad.jpg", "Ensalada César", 4500 },
                    { new Guid("20000000-0000-0000-0000-000000000008"), null, 1, true, 7, "Jamón, queso y vegetales", "sandwich.jpg", "Sándwich Mixto", 3200 },
                    { new Guid("20000000-0000-0000-0000-000000000009"), null, 1, true, 6, "Empanadas rellenas de carne", "empanadas.jpg", "Empanadas", 2500 },
                    { new Guid("20000000-0000-0000-0000-000000000010"), null, 1, true, 11, "Arepa con pollo y queso", "arepa.jpg", "Arepa Rellena", 3800 },
                    { new Guid("20000000-0000-0000-0000-000000000011"), null, 1, true, 18, "Lasaña personal de carne", "lasagna.jpg", "Lasaña", 5200 },
                    { new Guid("20000000-0000-0000-0000-000000000012"), null, 1, true, 5, "Postre de chocolate", "brownie.jpg", "Brownie", 2000 }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "store_id", "categories", "is_active", "productId", "product_id", "store_name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Fast Food", 1, null, new Guid("20000000-0000-0000-0000-000000000001"), "Polifood Central" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Snacks", 1, null, new Guid("20000000-0000-0000-0000-000000000007"), "Polifood Express" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "orderItem_id", "OrderId", "is_active", "product_id" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("30000000-0000-0000-0000-000000000001"), 1, new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("30000000-0000-0000-0000-000000000001"), 1, new Guid("20000000-0000-0000-0000-000000000002") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("30000000-0000-0000-0000-000000000002"), 1, new Guid("20000000-0000-0000-0000-000000000003") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("30000000-0000-0000-0000-000000000002"), 1, new Guid("20000000-0000-0000-0000-000000000004") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("30000000-0000-0000-0000-000000000003"), 1, new Guid("20000000-0000-0000-0000-000000000005") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("30000000-0000-0000-0000-000000000003"), 1, new Guid("20000000-0000-0000-0000-000000000006") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("30000000-0000-0000-0000-000000000004"), 1, new Guid("20000000-0000-0000-0000-000000000007") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("30000000-0000-0000-0000-000000000004"), 1, new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("40000000-0000-0000-0000-000000000009"), new Guid("30000000-0000-0000-0000-000000000005"), 1, new Guid("20000000-0000-0000-0000-000000000009") },
                    { new Guid("40000000-0000-0000-0000-000000000010"), new Guid("30000000-0000-0000-0000-000000000005"), 1, new Guid("20000000-0000-0000-0000-000000000010") },
                    { new Guid("40000000-0000-0000-0000-000000000011"), new Guid("30000000-0000-0000-0000-000000000006"), 1, new Guid("20000000-0000-0000-0000-000000000011") },
                    { new Guid("40000000-0000-0000-0000-000000000012"), new Guid("30000000-0000-0000-0000-000000000006"), 1, new Guid("20000000-0000-0000-0000-000000000012") },
                    { new Guid("40000000-0000-0000-0000-000000000013"), new Guid("30000000-0000-0000-0000-000000000007"), 1, new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("40000000-0000-0000-0000-000000000014"), new Guid("30000000-0000-0000-0000-000000000007"), 1, new Guid("20000000-0000-0000-0000-000000000003") },
                    { new Guid("40000000-0000-0000-0000-000000000015"), new Guid("30000000-0000-0000-0000-000000000008"), 1, new Guid("20000000-0000-0000-0000-000000000002") },
                    { new Guid("40000000-0000-0000-0000-000000000016"), new Guid("30000000-0000-0000-0000-000000000008"), 1, new Guid("20000000-0000-0000-0000-000000000004") },
                    { new Guid("40000000-0000-0000-0000-000000000017"), new Guid("30000000-0000-0000-0000-000000000009"), 1, new Guid("20000000-0000-0000-0000-000000000005") },
                    { new Guid("40000000-0000-0000-0000-000000000018"), new Guid("30000000-0000-0000-0000-000000000009"), 1, new Guid("20000000-0000-0000-0000-000000000007") },
                    { new Guid("40000000-0000-0000-0000-000000000019"), new Guid("30000000-0000-0000-0000-000000000010"), 1, new Guid("20000000-0000-0000-0000-000000000006") },
                    { new Guid("40000000-0000-0000-0000-000000000020"), new Guid("30000000-0000-0000-0000-000000000010"), 1, new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("40000000-0000-0000-0000-000000000021"), new Guid("30000000-0000-0000-0000-000000000011"), 1, new Guid("20000000-0000-0000-0000-000000000009") },
                    { new Guid("40000000-0000-0000-0000-000000000022"), new Guid("30000000-0000-0000-0000-000000000011"), 1, new Guid("20000000-0000-0000-0000-000000000011") },
                    { new Guid("40000000-0000-0000-0000-000000000023"), new Guid("30000000-0000-0000-0000-000000000012"), 1, new Guid("20000000-0000-0000-0000-000000000010") },
                    { new Guid("40000000-0000-0000-0000-000000000024"), new Guid("30000000-0000-0000-0000-000000000012"), 1, new Guid("20000000-0000-0000-0000-000000000012") },
                    { new Guid("40000000-0000-0000-0000-000000000025"), new Guid("30000000-0000-0000-0000-000000000013"), 1, new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("40000000-0000-0000-0000-000000000026"), new Guid("30000000-0000-0000-0000-000000000013"), 1, new Guid("20000000-0000-0000-0000-000000000006") },
                    { new Guid("40000000-0000-0000-0000-000000000027"), new Guid("30000000-0000-0000-0000-000000000014"), 1, new Guid("20000000-0000-0000-0000-000000000002") },
                    { new Guid("40000000-0000-0000-0000-000000000028"), new Guid("30000000-0000-0000-0000-000000000014"), 1, new Guid("20000000-0000-0000-0000-000000000007") },
                    { new Guid("40000000-0000-0000-0000-000000000029"), new Guid("30000000-0000-0000-0000-000000000015"), 1, new Guid("20000000-0000-0000-0000-000000000003") },
                    { new Guid("40000000-0000-0000-0000-000000000030"), new Guid("30000000-0000-0000-0000-000000000015"), 1, new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("40000000-0000-0000-0000-000000000031"), new Guid("30000000-0000-0000-0000-000000000016"), 1, new Guid("20000000-0000-0000-0000-000000000004") },
                    { new Guid("40000000-0000-0000-0000-000000000032"), new Guid("30000000-0000-0000-0000-000000000016"), 1, new Guid("20000000-0000-0000-0000-000000000009") },
                    { new Guid("40000000-0000-0000-0000-000000000033"), new Guid("30000000-0000-0000-0000-000000000017"), 1, new Guid("20000000-0000-0000-0000-000000000005") },
                    { new Guid("40000000-0000-0000-0000-000000000034"), new Guid("30000000-0000-0000-0000-000000000017"), 1, new Guid("20000000-0000-0000-0000-000000000010") },
                    { new Guid("40000000-0000-0000-0000-000000000035"), new Guid("30000000-0000-0000-0000-000000000018"), 1, new Guid("20000000-0000-0000-0000-000000000006") },
                    { new Guid("40000000-0000-0000-0000-000000000036"), new Guid("30000000-0000-0000-0000-000000000018"), 1, new Guid("20000000-0000-0000-0000-000000000011") },
                    { new Guid("40000000-0000-0000-0000-000000000037"), new Guid("30000000-0000-0000-0000-000000000019"), 1, new Guid("20000000-0000-0000-0000-000000000007") },
                    { new Guid("40000000-0000-0000-0000-000000000038"), new Guid("30000000-0000-0000-0000-000000000019"), 1, new Guid("20000000-0000-0000-0000-000000000012") },
                    { new Guid("40000000-0000-0000-0000-000000000039"), new Guid("30000000-0000-0000-0000-000000000020"), 1, new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("40000000-0000-0000-0000-000000000040"), new Guid("30000000-0000-0000-0000-000000000020"), 1, new Guid("20000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_productId",
                table: "Store",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Product_productId",
                table: "Store",
                column: "productId",
                principalTable: "Product",
                principalColumn: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Product_productId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_productId",
                table: "Store");

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "store_id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "store_id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "product_id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000012"));

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Store");

            migrationBuilder.AlterColumn<Guid>(
                name: "product_id",
                table: "Store",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "product_id", "CartId", "is_active", "is_available", "prepTimeMinutes", "product_description", "product_image", "product_name", "product_price" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), null, 1, true, 15, "Hamburguesa con carne, queso y vegetales", "jijijaja", "Hamburguesa Clásica", 5000 },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), null, 1, true, 20, "Pizza individual de queso y pepperoni", "jiji", "Pizza Personal", 4000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_product_id",
                table: "Store",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Product_product_id",
                table: "Store",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "product_id");
        }
    }
}
