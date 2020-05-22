using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class Theone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34f35e83-9d7d-4ec8-843e-a7af30d70d61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7971aa09-39f4-4e46-88df-93e7c490d400");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808bac87-1025-462b-b4bb-7b0fbdf88449");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccb06606-0c03-4022-93ec-c45527da2941");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa13b48f-982d-4893-8d09-265ac2adadf2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fb05ace7-d0d6-42f4-8f11-d4d569e65e11", "3cc3961e-685a-4f24-b452-97e4c991aa1b", "Visitor", "VISITOR" },
                    { "1538b144-0a59-41aa-ba72-868c48f389c7", "bd422f53-56b3-42fe-b316-a3f9aff1383f", "Customer", "CUSTOMER" },
                    { "5f4e9313-2cf1-48a6-a914-69f9b198f4d1", "52cd2182-0725-412d-855f-35db2680da13", "NotValidatedContractor", "NOTVALIDATEDCONTRACTOR" },
                    { "c18eae5d-8d3f-439b-a5e7-6f5238bb6a37", "c83aeaaa-2a90-497b-86e5-0780b8adf460", "ValidatedContractor", "VALIDATEDCONTRACTOR" },
                    { "8c020397-65e4-4908-a2d4-12b187f9c674", "1cbcdfba-ef1c-43c4-b343-f996e489a36c", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1538b144-0a59-41aa-ba72-868c48f389c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f4e9313-2cf1-48a6-a914-69f9b198f4d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c020397-65e4-4908-a2d4-12b187f9c674");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c18eae5d-8d3f-439b-a5e7-6f5238bb6a37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb05ace7-d0d6-42f4-8f11-d4d569e65e11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "808bac87-1025-462b-b4bb-7b0fbdf88449", "d585f758-2f71-4c4c-83c3-a7714960d99b", "Visitor", "VISITOR" },
                    { "7971aa09-39f4-4e46-88df-93e7c490d400", "819e9c42-0132-46fd-a883-2e7c00ba1f71", "Customer", "CUSTOMER" },
                    { "34f35e83-9d7d-4ec8-843e-a7af30d70d61", "4238a071-b315-4729-8f50-ee767e738f21", "NotValidatedContractor", "NOTVALIDATEDCONTRACTOR" },
                    { "ccb06606-0c03-4022-93ec-c45527da2941", "ff031629-c553-432e-b52b-4a78e82b791a", "ValidatedContractor", "VALIDATEDCONTRACTOR" },
                    { "fa13b48f-982d-4893-8d09-265ac2adadf2", "9c2b7393-c4c9-4fe9-9267-23a2a31fa451", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
