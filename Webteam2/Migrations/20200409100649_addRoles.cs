using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class addRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b589c613-41f6-4aa7-aa86-4e834e53d028", "9568393f-b970-4874-b8f7-9657569edf0e", "Visitor", "VISITOR" },
                    { "65f7545a-6947-48f8-812e-df08be8bc9e7", "91818e41-6c82-411c-a452-c106c80efc7c", "Customer", "CUSTOMER" },
                    { "c62d96bc-761c-4a72-95a7-50542a999e3b", "38dea008-51c5-4000-9d14-fedcd10a3bcf", "Contractor", "CONTRACTOR" },
                    { "3377a643-9f9f-422f-8f37-b3d411cace13", "5373f460-2af6-4fbb-ab5a-6320420da945", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3377a643-9f9f-422f-8f37-b3d411cace13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65f7545a-6947-48f8-812e-df08be8bc9e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b589c613-41f6-4aa7-aa86-4e834e53d028");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c62d96bc-761c-4a72-95a7-50542a999e3b");
        }
    }
}
