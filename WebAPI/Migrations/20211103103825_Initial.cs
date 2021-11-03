using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Initial : Migration
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
                    { 1, "description1" },
                    { 2, "description2" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "a", "description1" },
                    { 2, "b", "description2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "EmailAddress", "IsActive", "Name", "Surname", "UserTitleId", "UserTypeId" },
                values: new object[] { 1, new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "george@example.com", true, "George", "GeorgeSurname", 1, 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "EmailAddress", "IsActive", "Name", "Surname", "UserTitleId", "UserTypeId" },
                values: new object[] { 2, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikos@example.com", true, "Nikos", "NikosSurname", 2, 2 });

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
