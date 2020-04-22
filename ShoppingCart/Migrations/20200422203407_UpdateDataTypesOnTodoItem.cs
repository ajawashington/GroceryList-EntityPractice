using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class UpdateDataTypesOnTodoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoStatus_TodoStatusId1",
                table: "TodoItem");

            migrationBuilder.DropIndex(
                name: "IX_TodoItem_TodoStatusId1",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "TodoStatusId1",
                table: "TodoItem");

            migrationBuilder.AlterColumn<int>(
                name: "TodoStatusId",
                table: "TodoItem",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29dd7061-33d5-493a-9ec8-b96208511d3d", "AQAAAAEAACcQAAAAELoY6+5Npn21VO/jvDoyPB4KwqwKyP7grf+lWVbn2OlbYQtERL7mE8qxY0dJvMbstA==" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_TodoStatusId",
                table: "TodoItem",
                column: "TodoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoStatus_TodoStatusId",
                table: "TodoItem",
                column: "TodoStatusId",
                principalTable: "TodoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoStatus_TodoStatusId",
                table: "TodoItem");

            migrationBuilder.DropIndex(
                name: "IX_TodoItem_TodoStatusId",
                table: "TodoItem");

            migrationBuilder.AlterColumn<string>(
                name: "TodoStatusId",
                table: "TodoItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TodoStatusId1",
                table: "TodoItem",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e045bfac-26a8-44e9-b004-24e8cc16895a", "AQAAAAEAACcQAAAAEMEaZ8dbdNzp6dtPeBkNsBmQ+dj3FVUiMytSwFqwo+kZIoyqgDcz3qxyjf4Hagqsqg==" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_TodoStatusId1",
                table: "TodoItem",
                column: "TodoStatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoStatus_TodoStatusId1",
                table: "TodoItem",
                column: "TodoStatusId1",
                principalTable: "TodoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
