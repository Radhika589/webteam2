using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class test_migration_2 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "Bid",
                table: "Issues",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Bid",
                table: "Issues");

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
