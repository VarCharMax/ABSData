using Microsoft.EntityFrameworkCore.Migrations;

namespace ABSData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbsData",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sexid = table.Column<long>(nullable: true),
                    AgeCode = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Stateid = table.Column<long>(nullable: true),
                    RegionType = table.Column<string>(nullable: true),
                    GeographyLevel = table.Column<string>(nullable: true),
                    ASGS_2016 = table.Column<string>(nullable: true),
                    Regionid = table.Column<long>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    CensusYear = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsData", x => x.id);
                    table.ForeignKey(
                        name: "FK_AbsData_Regions_Regionid",
                        column: x => x.Regionid,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbsData_Sexes_Sexid",
                        column: x => x.Sexid,
                        principalTable: "Sexes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbsData_States_Stateid",
                        column: x => x.Stateid,
                        principalTable: "States",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbsData_Regionid",
                table: "AbsData",
                column: "Regionid");

            migrationBuilder.CreateIndex(
                name: "IX_AbsData_Sexid",
                table: "AbsData",
                column: "Sexid");

            migrationBuilder.CreateIndex(
                name: "IX_AbsData_Stateid",
                table: "AbsData",
                column: "Stateid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsData");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
