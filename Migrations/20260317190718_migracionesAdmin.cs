using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Polifood.Migrations
{
    /// <inheritdoc />
    public partial class migracionesAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11111111-1111-1111-1111-111111111111", "99999999-9999-9999-9999-999999999991" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "22222222-2222-2222-2222-222222222222", "99999999-9999-9999-9999-999999999992" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "33333333-3333-3333-3333-333333333333", "99999999-9999-9999-9999-999999999993" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99999999-9999-9999-9999-999999999991");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99999999-9999-9999-9999-999999999992");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99999999-9999-9999-9999-999999999993");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "99999999-9999-9999-9999-999999999991", 0, "c1c1c1c1-1111-1111-1111-111111111111", "admin@polifood.com", true, false, null, "ADMIN@POLIFOOD.COM", "ADMIN@POLIFOOD.COM", "AQAAAAEAACcQAAAAEPvFakeHashAdmin123!", null, false, "s1s1s1s1-1111-1111-1111-111111111111", false, "admin@polifood.com" },
                    { "99999999-9999-9999-9999-999999999992", 0, "c2c2c2c2-2222-2222-2222-222222222222", "student@polifood.com", true, false, null, "STUDENT@POLIFOOD.COM", "STUDENT@POLIFOOD.COM", "AQAAAAEAACcQAAAAEPvFakeHashStudent123!", null, false, "s2s2s2s2-2222-2222-2222-222222222222", false, "student@polifood.com" },
                    { "99999999-9999-9999-9999-999999999993", 0, "c3c3c3c3-3333-3333-3333-333333333333", "vendor@polifood.com", true, false, null, "VENDOR@POLIFOOD.COM", "VENDOR@POLIFOOD.COM", "AQAAAAEAACcQAAAAEPvFakeHashVendor123!", null, false, "s3s3s3s3-3333-3333-3333-333333333333", false, "vendor@polifood.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", "99999999-9999-9999-9999-999999999991" },
                    { "22222222-2222-2222-2222-222222222222", "99999999-9999-9999-9999-999999999992" },
                    { "33333333-3333-3333-3333-333333333333", "99999999-9999-9999-9999-999999999993" }
                });
        }
    }
}
