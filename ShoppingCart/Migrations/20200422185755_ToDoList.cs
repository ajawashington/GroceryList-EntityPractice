using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Migrations
{
    public partial class ToDoList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoStatusId = table.Column<string>(nullable: false),
                    TodoStatusId1 = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItem_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoItem_TodoStatus_TodoStatusId1",
                        column: x => x.TodoStatusId1,
                        principalTable: "TodoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4bfd2571-1961-404f-b767-af93b36860a2", "AQAAAAEAACcQAAAAENHKKReJ5V+yY3FsTCRwEQOA/poBxxRfDHEKHMLaDdLftB9hfMbHZ2VsvAyJEUVZCA==" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_ApplicationUserId",
                table: "TodoItem",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_TodoStatusId1",
                table: "TodoItem",
                column: "TodoStatusId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItem");

            migrationBuilder.DropTable(
                name: "TodoStatus");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bcaedd7-6173-4650-ae50-2e362b772762", "AQAAAAEAACcQAAAAEJ5CLwwsSNT0tTFZqfaHA4gqyCvAlO6RF76xONcq7hLQtmi/1J1SY4HRZ86rJ2+YEA==" });
        }
    }
}
