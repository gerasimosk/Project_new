using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Innitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTitle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Surname = table.Column<string>(maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: false),
                    UserTitleId = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserTitle_UserTitleId",
                        column: x => x.UserTitleId,
                        principalTable: "UserTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserTitle",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "userTitle 1" },
                    { 2, "userTitle 2" },
                    { 3, "userTitle 3" },
                    { 4, "userTitle 4" },
                    { 5, "userTitle 5" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "a", "userType 1" },
                    { 2, "b", "userType 2" },
                    { 3, "c", "userType 3" },
                    { 4, "d", "userType 4" },
                    { 5, "e", "userType 5" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "EmailAddress", "IsActive", "Name", "Surname", "UserTitleId", "UserTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian@example.com", true, "Brian", "Glover", 1, 1 },
                    { 11, new DateTime(2019, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julia@example.com", true, "Julia", "Blair", 2, 1 },
                    { 14, new DateTime(1018, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pearl@example.com", true, "Pearl", "Salazar", 4, 1 },
                    { 2, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samantha@example.com", true, "Samantha", "Russell", 2, 2 },
                    { 8, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edric@example.com", true, "Edric", "Burrows", 4, 2 },
                    { 15, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zelene@example.com", true, "Zelene", "Row", 2, 2 },
                    { 3, new DateTime(2018, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adele@example.com", true, "Adele", "Stephens", 4, 3 },
                    { 9, null, "Fletcher@example.com", true, "Fletcher", "Abbott", 1, 3 },
                    { 10, null, "Marc@example.com", true, "Marc", "Atkinson", 2, 3 },
                    { 13, null, "Rita@example.com", true, "Rita", "Wheatly", 3, 3 },
                    { 4, new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bert@example.com", true, "Bert", "Ruell", 4, 4 },
                    { 7, new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willa@example.com", true, "Willa", "Walsh", 3, 4 },
                    { 5, new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyrone@example.com", true, "Tyrone", "Stanley", 5, 5 },
                    { 6, null, "Windsor@example.com", true, "Windsor", "Ryan", 2, 5 },
                    { 12, new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maxwell@example.com", true, "Maxwell", "Jackson", 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTitleId",
                table: "User",
                column: "UserTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserTitle");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
