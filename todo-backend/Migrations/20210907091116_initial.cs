using Microsoft.EntityFrameworkCore.Migrations;

namespace todo_backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_TodoLists_TodoListID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TodoListID",
                table: "Items",
                newName: "TodoListId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_TodoListID",
                table: "Items",
                newName: "IX_Items_TodoListId");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_TodoLists_TodoListId",
                table: "Items",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_TodoLists_TodoListId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TodoListId",
                table: "Items",
                newName: "TodoListID");

            migrationBuilder.RenameIndex(
                name: "IX_Items_TodoListId",
                table: "Items",
                newName: "IX_Items_TodoListID");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListID",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_TodoLists_TodoListID",
                table: "Items",
                column: "TodoListID",
                principalTable: "TodoLists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
