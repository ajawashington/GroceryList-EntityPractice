using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class Title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TodoItem",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e045bfac-26a8-44e9-b004-24e8cc16895a", "AQAAAAEAACcQAAAAEMEaZ8dbdNzp6dtPeBkNsBmQ+dj3FVUiMytSwFqwo+kZIoyqgDcz3qxyjf4Hagqsqg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TodoItem");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd5928bb-22c6-451f-b7dc-caa8c305a0ed", "AQAAAAEAACcQAAAAEB/AybpCC+I2LEzl3ggQDJbv91GChidf2uq5wz5S7jtDSNUFggIU6hIH03UiSMMZxQ==" });
        }
    }
}
