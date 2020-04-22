using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bcaedd7-6173-4650-ae50-2e362b772762", "AQAAAAEAACcQAAAAEJ5CLwwsSNT0tTFZqfaHA4gqyCvAlO6RF76xONcq7hLQtmi/1J1SY4HRZ86rJ2+YEA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a431db7-3f75-4076-8472-a61c6012ace2", "AQAAAAEAACcQAAAAEIhKOMYUZUEMBwuBBsFaHzm9svv86KShWvLFsmZrTKiB9oMt3m9Onky1ROEp2ek2og==" });
        }
    }
}
