using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "7a431db7-3f75-4076-8472-a61c6012ace2", "r@r.com", true, "Rose", "Wiz", false, null, "R@R.COM", "R@R.COM", "AQAAAAEAACcQAAAAEIhKOMYUZUEMBwuBBsFaHzm9svv86KShWvLFsmZrTKiB9oMt3m9Onky1ROEp2ek2og==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "r@r.com" });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "ApplicationUserId", "ProductName" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", "Can of Spam" },
                    { 2, "00000000-ffff-ffff-ffff-ffffffffffff", "Rice" },
                    { 3, "00000000-ffff-ffff-ffff-ffffffffffff", "Eggs" },
                    { 4, "00000000-ffff-ffff-ffff-ffffffffffff", "Mask" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoppingItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");
        }
    }
}
