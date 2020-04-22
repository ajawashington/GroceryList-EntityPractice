using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class TodoSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd5928bb-22c6-451f-b7dc-caa8c305a0ed", "AQAAAAEAACcQAAAAEB/AybpCC+I2LEzl3ggQDJbv91GChidf2uq5wz5S7jtDSNUFggIU6hIH03UiSMMZxQ==" });

            migrationBuilder.InsertData(
                table: "TodoStatus",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Todo" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4bfd2571-1961-404f-b767-af93b36860a2", "AQAAAAEAACcQAAAAENHKKReJ5V+yY3FsTCRwEQOA/poBxxRfDHEKHMLaDdLftB9hfMbHZ2VsvAyJEUVZCA==" });
        }
    }
}
