using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class profileinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "786c11a8-bb85-49c3-8417-b76f582f8700");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a42214c1-8cd9-4688-8547-c5a076994931");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bea54d1f-56ff-4857-8aec-3abdeedb76b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f81a8517-0f7c-4cd3-a0d8-d19eed7c7347");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26b227a8-0684-4fda-89f8-1fde838daf82", "f40d9a0f-7f7d-41cb-a190-20651aaa5604", "Visitor", "VISITOR" },
                    { "58d89c0d-2009-4d7b-aa20-aab4eeed5fda", "f992492c-2aa2-4f3c-b03f-32048c59f051", "Customer", "CUSTOMER" },
                    { "da0d6fd0-217d-4535-aa85-03c25583d044", "d3fb87c7-f979-400f-af77-0f41283b73f8", "Contractor", "CONTRACTOR" },
                    { "a4a3d33a-8b8a-46cc-b9f1-fe50baae0e3e", "8140b867-5382-4d45-a07e-0ade6b323fbc", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26b227a8-0684-4fda-89f8-1fde838daf82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58d89c0d-2009-4d7b-aa20-aab4eeed5fda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4a3d33a-8b8a-46cc-b9f1-fe50baae0e3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da0d6fd0-217d-4535-aa85-03c25583d044");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "786c11a8-bb85-49c3-8417-b76f582f8700", "f99705d5-7f74-4ab1-b015-d0a746d26d01", "Visitor", "VISITOR" },
                    { "bea54d1f-56ff-4857-8aec-3abdeedb76b2", "e9a91439-c54b-465b-a7f8-d286c4ec73cd", "Customer", "CUSTOMER" },
                    { "f81a8517-0f7c-4cd3-a0d8-d19eed7c7347", "5d73abe9-e301-4a31-a5f6-d4eb1c29f8d5", "Contractor", "CONTRACTOR" },
                    { "a42214c1-8cd9-4688-8547-c5a076994931", "3f12e3dc-91f5-4977-9605-c9ec2eeae497", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
