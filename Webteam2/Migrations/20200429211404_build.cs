using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class build : Migration
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
                    { "c8dd2339-02eb-4d73-9b40-76da01370967", "dd7ff4e3-b6e3-429f-9790-35d6cc03e0e6", "Visitor", "VISITOR" },
                    { "fe2f7adb-f8d5-4d36-9b32-a1b1927e56f6", "6162e969-7e38-412b-927c-1bcea07ef211", "Customer", "CUSTOMER" },
                    { "db56f4fd-059f-4a84-b625-55e339313ee0", "c3c2db4b-b110-4098-abd2-fa8a1ba78b52", "NotValidatedContractor", "NOTVALIDATEDCONTRACTOR" },
                    { "10f20bd2-4c4d-423e-898f-f9f140bd0f68", "06486446-c250-494d-a0e8-ca42f7a04253", "ValidatedContractor", "VALIDATEDCONTRACTOR" },
                    { "1478d49a-165b-48b9-bbe3-278781f717ca", "e1258c68-c2e7-4e3c-83a0-5b29f781cc0f", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10f20bd2-4c4d-423e-898f-f9f140bd0f68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1478d49a-165b-48b9-bbe3-278781f717ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8dd2339-02eb-4d73-9b40-76da01370967");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db56f4fd-059f-4a84-b625-55e339313ee0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe2f7adb-f8d5-4d36-9b32-a1b1927e56f6");

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
