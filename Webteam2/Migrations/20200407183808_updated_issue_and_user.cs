using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class updated_issue_and_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Issues",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Reputation",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuerId",
                table: "Issues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "Issues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Issues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssuerId",
                table: "Issues",
                column: "IssuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_IssuerId",
                table: "Issues",
                column: "IssuerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_IssuerId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssuerId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssuerId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Issues",
                newName: "id");
        }
    }
}
