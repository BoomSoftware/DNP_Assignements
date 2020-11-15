using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace FamilyWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    StreetName = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => new { x.StreetName, x.HouseNumber });
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Adult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    HairColor = table.Column<string>(nullable: false),
                    EyeColor = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    FamilyHouseNumber = table.Column<int>(nullable: true),
                    FamilyStreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adult_Families_FamilyStreetName_FamilyHouseNumber",
                        columns: x => new { x.FamilyStreetName, x.FamilyHouseNumber },
                        principalTable: "Families",
                        principalColumns: new[] { "StreetName", "HouseNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    HairColor = table.Column<string>(nullable: false),
                    EyeColor = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    FamilyHouseNumber = table.Column<int>(nullable: true),
                    FamilyStreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Child_Families_FamilyStreetName_FamilyHouseNumber",
                        columns: x => new { x.FamilyStreetName, x.FamilyHouseNumber },
                        principalTable: "Families",
                        principalColumns: new[] { "StreetName", "HouseNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildInterest",
                columns: table => new
                {
                    ChildId = table.Column<int>(nullable: false),
                    InterestId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildInterest", x => new { x.ChildId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_ChildInterest_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildInterest_Interest_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interest",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Species = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: true),
                    FamilyHouseNumber = table.Column<int>(nullable: true),
                    FamilyStreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Child_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pet_Families_FamilyStreetName_FamilyHouseNumber",
                        columns: x => new { x.FamilyStreetName, x.FamilyHouseNumber },
                        principalTable: "Families",
                        principalColumns: new[] { "StreetName", "HouseNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adult_FamilyStreetName_FamilyHouseNumber",
                table: "Adult",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Child_FamilyStreetName_FamilyHouseNumber",
                table: "Child",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterest_InterestId",
                table: "ChildInterest",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ChildId",
                table: "Pet",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_FamilyStreetName_FamilyHouseNumber",
                table: "Pet",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adult");

            migrationBuilder.DropTable(
                name: "ChildInterest");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
