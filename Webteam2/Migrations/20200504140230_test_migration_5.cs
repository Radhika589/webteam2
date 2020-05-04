using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class test_migration_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "051f43d0-e1eb-4b69-ad2a-bce7260be95d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24707bab-24bc-427e-a74d-dead393b9986");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91801022-0e96-485d-a497-3af785561c88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe1bfbfd-d834-4862-aa28-71648208e5f1");

            migrationBuilder.AlterColumn<int>(
                name: "Reputation",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35e4678e-f369-4b5b-ae7d-365cee34b1f2", "b93970ff-700f-4235-952e-5e6e60c61a6b", "Visitor", "VISITOR" },
                    { "0c399790-854b-4b03-bb41-4623cccb9c62", "a71d73c4-a511-442d-bb59-3c139890556c", "Customer", "CUSTOMER" },
                    { "ef75dc1a-f839-40c1-95bb-a674b331a5ae", "05262c6d-f0e4-407a-b7d4-7c8769b607cd", "Contractor", "CONTRACTOR" },
                    { "5b51e704-e1a2-4aaf-939c-2d7b7982795b", "3dcca506-fc94-4909-9565-efd4fccfa40e", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c399790-854b-4b03-bb41-4623cccb9c62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35e4678e-f369-4b5b-ae7d-365cee34b1f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b51e704-e1a2-4aaf-939c-2d7b7982795b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef75dc1a-f839-40c1-95bb-a674b331a5ae");

            migrationBuilder.AlterColumn<int>(
                name: "Reputation",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fe1bfbfd-d834-4862-aa28-71648208e5f1", "67e21441-734f-4d1c-88a8-102cdf0dc585", "Visitor", "VISITOR" },
                    { "91801022-0e96-485d-a497-3af785561c88", "e07d68a1-2ad3-40c7-bba6-6897931e5347", "Customer", "CUSTOMER" },
                    { "24707bab-24bc-427e-a74d-dead393b9986", "8b647885-5b22-4239-bea5-7d72775d5b5f", "Contractor", "CONTRACTOR" },
                    { "051f43d0-e1eb-4b69-ad2a-bce7260be95d", "017ce148-1672-417f-b0a2-081264b46e5d", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
