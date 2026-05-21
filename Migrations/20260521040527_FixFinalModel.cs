using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polifood.Migrations
{
    /// <inheritdoc />
    public partial class FixFinalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_CartId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_CartId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "OrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "OrderItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000006"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000007"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000008"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000009"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000010"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000011"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000012"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000013"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000014"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000016"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000017"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000018"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000019"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000020"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000021"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000022"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000023"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000024"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000025"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000026"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000027"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000028"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000029"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000030"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000031"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000032"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000033"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000034"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000035"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000036"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000037"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000038"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000039"),
                column: "CartId",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "orderItem_id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000040"),
                column: "CartId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CartId",
                table: "OrderItem",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_CartId",
                table: "OrderItem",
                column: "CartId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
