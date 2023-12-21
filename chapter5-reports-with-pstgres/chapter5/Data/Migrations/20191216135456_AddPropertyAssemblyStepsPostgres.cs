using Microsoft.EntityFrameworkCore.Migrations;

namespace chapter5.Data.Migrations
{
    public partial class AddPropertyAssemblyStepsPostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
