using Microsoft.EntityFrameworkCore.Migrations;

namespace ABSData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DimAge",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    ABSAgeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimAge", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DimRegion",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    ABSRegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimRegion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DimSex",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    ABSSexId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSex", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DimState",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    ABSStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimState", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FactPopulation",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sexid = table.Column<long>(nullable: true),
                    AgeCodeid = table.Column<long>(nullable: true),
                    Stateid = table.Column<long>(nullable: true),
                    RegionType = table.Column<string>(nullable: true),
                    GeographyLevel = table.Column<string>(nullable: true),
                    Regionid = table.Column<long>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    CensusYear = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactPopulation", x => x.id);
                    table.ForeignKey(
                        name: "FK_FactPopulation_DimAge_AgeCodeid",
                        column: x => x.AgeCodeid,
                        principalTable: "DimAge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactPopulation_DimRegion_Regionid",
                        column: x => x.Regionid,
                        principalTable: "DimRegion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactPopulation_DimSex_Sexid",
                        column: x => x.Sexid,
                        principalTable: "DimSex",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactPopulation_DimState_Stateid",
                        column: x => x.Stateid,
                        principalTable: "DimState",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactPopulation_AgeCodeid",
                table: "FactPopulation",
                column: "AgeCodeid");

            migrationBuilder.CreateIndex(
                name: "IX_FactPopulation_Regionid",
                table: "FactPopulation",
                column: "Regionid");

            migrationBuilder.CreateIndex(
                name: "IX_FactPopulation_Sexid",
                table: "FactPopulation",
                column: "Sexid");

            migrationBuilder.CreateIndex(
                name: "IX_FactPopulation_Stateid",
                table: "FactPopulation",
                column: "Stateid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactPopulation");

            migrationBuilder.DropTable(
                name: "DimAge");

            migrationBuilder.DropTable(
                name: "DimRegion");

            migrationBuilder.DropTable(
                name: "DimSex");

            migrationBuilder.DropTable(
                name: "DimState");
        }
    }
}
