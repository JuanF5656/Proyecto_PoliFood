using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polifood.Migrations
{
    /// <inheritdoc />
    public partial class migracionesFinales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Product_productId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_productId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Store");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Product",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CartId",
                table: "Product",
                newName: "IX_Product_productId");

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "OrderItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentConfirmedAt",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "is_active",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000011"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000012"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000013"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000014"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000015"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000016"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000017"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000018"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000019"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000020"),
                columns: new[] { "CartId", "IsPaid", "PaymentConfirmedAt", "Total", "is_active" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), false, null, 0m, 0 });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000006"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000007"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000008"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000009"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000010"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000011"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000012"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000013"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000014"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000016"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000017"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000018"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000019"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000020"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000021"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000022"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000023"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000024"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000025"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000026"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000027"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000028"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000029"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000030"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000031"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000032"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000033"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000034"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000035"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000036"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000037"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000038"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000039"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000040"),
                columns: new[] { "CartId", "Quantity", "Subtotal", "UnitPrice" },
                values: new object[] { null, 0, 0m, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CartId",
                table: "OrderItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_CartId",
                table: "OrderItem",
                column: "CartId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Store_productId",
                table: "Product",
                column: "productId",
                principalTable: "Store",
                principalColumn: "store_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_CartId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Store_productId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_CartId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentConfirmedAt",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Product",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_productId",
                table: "Product",
                newName: "IX_Product_CartId");

            migrationBuilder.AddColumn<Guid>(
                name: "productId",
                table: "Store",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "store_id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "productId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "store_id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"),
                column: "productId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Store_productId",
                table: "Store",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Product_productId",
                table: "Store",
                column: "productId",
                principalTable: "Product",
                principalColumn: "product_id");
        }
    }
}
