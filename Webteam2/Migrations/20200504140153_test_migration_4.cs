using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class test_migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ae280c-42d3-4c57-ae53-d3ca5ce61829");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46873748-5478-49aa-8c95-e1629df31fa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8864c84d-fb5a-4a57-87df-a5b7308f6447");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b817fa99-b343-4df1-b85b-6858dd59e879");

            migrationBuilder.AddColumn<int>(
                name: "Reputation",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8864c84d-fb5a-4a57-87df-a5b7308f6447", "0c73a610-8fe0-4b09-b8d6-3b78c87bc448", "Visitor", "VISITOR" },
                    { "46873748-5478-49aa-8c95-e1629df31fa3", "bca3abdc-06d8-47fa-b222-31d3c840c4d2", "Customer", "CUSTOMER" },
                    { "b817fa99-b343-4df1-b85b-6858dd59e879", "7745a345-f421-431d-b1ed-6efd343c1555", "Contractor", "CONTRACTOR" },
                    { "17ae280c-42d3-4c57-ae53-d3ca5ce61829", "61d1b0c4-667b-414c-ad39-408aa30825f3", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
