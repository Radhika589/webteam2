using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class dankMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "197dad57-ab1d-4f81-a895-26f2aa488d50", "9e5e128a-6f48-4bf9-a44b-5971a4e998a0", "Visitor", "VISITOR" },
                    { "bc4dad47-6741-4351-a985-5cdc32be780b", "6fff50a7-e091-4b04-aa43-8250956fc03b", "Customer", "CUSTOMER" },
                    { "4f929de5-f485-4f32-99c2-9c45df5fe547", "f03d234f-c9e6-4d3e-8e39-67ce242ace70", "NotValidatedContractor", "NOTVALIDATEDCONTRACTOR" },
                    { "57f57d29-7781-4393-ac3d-345a199e64e6", "f3050463-4e4b-48d4-a12d-d4422290a6a5", "ValidatedContractor", "VALIDATEDCONTRACTOR" },
                    { "185c4d2f-dc27-4d55-9306-c219f455533c", "b6df1627-e046-4079-ab1f-fd588810cd73", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "185c4d2f-dc27-4d55-9306-c219f455533c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "197dad57-ab1d-4f81-a895-26f2aa488d50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f929de5-f485-4f32-99c2-9c45df5fe547");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57f57d29-7781-4393-ac3d-345a199e64e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc4dad47-6741-4351-a985-5cdc32be780b");

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
    }
}
