using Microsoft.EntityFrameworkCore.Migrations;

namespace chapter6.Data.Migrations
{
    public partial class FixedStationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mandatory",
                table: "Stations");

            migrationBuilder.AddColumn<bool>(
                name: "Mandatory",
                table: "AssemblySteps",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mandatory",
                table: "AssemblySteps");

            migrationBuilder.AddColumn<bool>(
                name: "Mandatory",
                table: "Stations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
