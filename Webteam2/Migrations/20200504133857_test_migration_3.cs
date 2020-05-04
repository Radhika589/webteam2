using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class test_migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a840f66-31ad-493d-a033-51f38713e464");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c74fed01-1830-4296-aff2-6362c89eeb56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef0cf648-5224-43f2-9fd6-b6922ba9c2df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff043115-6788-4676-9aa5-bf89deea27b3");

            migrationBuilder.AlterColumn<int>(
                name: "Bid",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Bid",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a840f66-31ad-493d-a033-51f38713e464", "8444b822-43c8-4e8b-af43-2697cc93d372", "Visitor", "VISITOR" },
                    { "c74fed01-1830-4296-aff2-6362c89eeb56", "4c1edc9f-9b13-41f6-9174-4f2af4833e39", "Customer", "CUSTOMER" },
                    { "ff043115-6788-4676-9aa5-bf89deea27b3", "852da996-9e17-427a-8bd9-9c334cc91144", "Contractor", "CONTRACTOR" },
                    { "ef0cf648-5224-43f2-9fd6-b6922ba9c2df", "98a4dadb-3482-460c-b86f-987986f9a87e", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
