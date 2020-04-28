using Microsoft.EntityFrameworkCore.Migrations;

namespace Webteam2.Migrations
{
    public partial class addOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PictureURL = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d63bcfa2-2648-4b9a-9445-0f480c05474d", "dd17d0ce-df07-4d59-92a8-6f6e682442f8", "Visitor", "VISITOR" },
                    { "8dec8425-5fee-4704-af33-37ef478c4041", "81a2ae1f-b051-40ef-b55d-d82bf44a2765", "Customer", "CUSTOMER" },
                    { "c4405be8-a30d-4819-ae40-c71e81ec102c", "f87b7cef-6f3e-44d6-bc98-2b8405c28158", "Contractor", "CONTRACTOR" },
                    { "5a828f75-c1d1-4705-bfdc-5d7fd5a9fc46", "c0453bfb-0597-40bc-9c1a-6ec5d1da53b9", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a828f75-c1d1-4705-bfdc-5d7fd5a9fc46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dec8425-5fee-4704-af33-37ef478c4041");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4405be8-a30d-4819-ae40-c71e81ec102c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d63bcfa2-2648-4b9a-9445-0f480c05474d");

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
    }
}
