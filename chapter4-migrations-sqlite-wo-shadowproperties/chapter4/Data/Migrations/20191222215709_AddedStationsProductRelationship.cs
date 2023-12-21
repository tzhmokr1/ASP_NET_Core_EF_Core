using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace chapter4.Data.Migrations
{
    public partial class AddedStationsProductRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateTable(
                name: "Temp_Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    End = table.Column<DateTime>(nullable: true),
                    RoundId = table.Column<int>(nullable: true),
                    StationId = table.Column<int>(nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });


            migrationBuilder.Sql("INSERT INTO Temp_Products SELECT Id, Start, End, RoundId, 1 FROM Products;", true);
            migrationBuilder.Sql("PRAGMA foreign_keys=\"0\"", true);
             migrationBuilder.Sql("DROP TABLE Products;", true);
            migrationBuilder.Sql("ALTER TABLE Temp_Products RENAME TO Products", true);
            migrationBuilder.Sql("PRAGMA foreign_keys=\"1\"", true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StationId",
                table: "Products",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RoundId",
                table: "Products",
                column: "RoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //! not safe to perform! --> also needs temp table etc.
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
