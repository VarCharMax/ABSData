using Microsoft.EntityFrameworkCore.Migrations;

namespace ABSData.Migrations
{
    public partial class RemoveDataAGCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ASGS_2016",
                table: "AbsData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ASGS_2016",
                table: "AbsData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
