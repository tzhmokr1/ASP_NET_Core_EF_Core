using Microsoft.EntityFrameworkCore.Migrations;

namespace chapter5.Data.Migrations
{
    public partial class AddedStationProductRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StationId",
                table: "Products",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stations_StationId",
                table: "Products",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stations_StationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "Products");
        }
    }
}
