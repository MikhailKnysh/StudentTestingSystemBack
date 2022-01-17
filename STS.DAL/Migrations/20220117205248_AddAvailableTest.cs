using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STS.DAL.Migrations
{
    public partial class AddAvailableTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThemeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTests_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AvailableTests_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTests_StudentId",
                table: "AvailableTests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTests_ThemeId",
                table: "AvailableTests",
                column: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableTests");
        }
    }
}
