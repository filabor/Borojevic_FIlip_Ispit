using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.ToDo.Data.Migrations
{
    public partial class ExtendedTodolistsTableWithUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Todolists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Todolists_UserId",
                table: "Todolists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todolists_AspNetUsers_UserId",
                table: "Todolists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolists_AspNetUsers_UserId",
                table: "Todolists");

            migrationBuilder.DropIndex(
                name: "IX_Todolists_UserId",
                table: "Todolists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todolists");
        }
    }
}
