using Microsoft.EntityFrameworkCore.Migrations;

namespace ABSData.Migrations
{
    public partial class AddDataCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ABSSexId",
                table: "Sexes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABSSexId",
                table: "Sexes");
        }
    }
}
