using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class testmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18584625-07b0-431c-b654-3f63b9f8a84f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b22be7b-95f6-4c54-9cfd-50724057505d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "919acd5a-44f1-42a7-8688-5fd517219f86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4790e28-920d-451f-a1a0-57dc0f0bb51b");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "236f8212-553e-48e8-8e63-6f7e0f8efdfb", "e2e45dd2-5d62-4c8b-bced-57f91e39b5e8", "Visitor", "VISITOR" },
                    { "f5415327-72b3-49e9-9cc5-3618e6aed192", "255105ba-fcae-4273-a358-d06de2a2d324", "Customer", "CUSTOMER" },
                    { "98acecf1-c838-4e65-a251-b446b7bd0053", "cb5345eb-a985-4c26-838e-6696de93e488", "Contractor", "CONTRACTOR" },
                    { "d60f4cb9-92ea-4ce5-b7aa-63ffc82e647e", "1dc09300-0da0-440b-9923-248be10cdaf5", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "236f8212-553e-48e8-8e63-6f7e0f8efdfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98acecf1-c838-4e65-a251-b446b7bd0053");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d60f4cb9-92ea-4ce5-b7aa-63ffc82e647e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5415327-72b3-49e9-9cc5-3618e6aed192");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b22be7b-95f6-4c54-9cfd-50724057505d", "7ecb6ac6-c05b-4f64-8623-5e7fba5d934f", "Visitor", "VISITOR" },
                    { "919acd5a-44f1-42a7-8688-5fd517219f86", "4763cfac-eb06-4ec4-bbbb-931ecccce40d", "Customer", "CUSTOMER" },
                    { "18584625-07b0-431c-b654-3f63b9f8a84f", "eeaad6f9-70b9-40b2-aa90-8c3e1a3314d6", "Contractor", "CONTRACTOR" },
                    { "c4790e28-920d-451f-a1a0-57dc0f0bb51b", "0f7310b8-f463-452e-89bf-62e677f22361", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
