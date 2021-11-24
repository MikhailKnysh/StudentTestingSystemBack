using Microsoft.EntityFrameworkCore.Migrations;
using STS.DAL.EntityContext.Extensions;

namespace STS.DAL.Migrations
{
    public partial class SetDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RunSqlScript("20211124211603_SetDefaultUserScript");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
