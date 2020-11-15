using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyWebAPI.Migrations
{
    public partial class RemovedIdFromFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Families");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Families",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
