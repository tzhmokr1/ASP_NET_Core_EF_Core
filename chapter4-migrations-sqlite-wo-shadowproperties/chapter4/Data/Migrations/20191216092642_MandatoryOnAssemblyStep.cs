using Microsoft.EntityFrameworkCore.Migrations;

namespace chapter4.Data.Migrations
{
    public partial class MandatoryOnAssemblyStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Temp Tabelle
            migrationBuilder.CreateTable(
                name : "TempStations",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                         .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<string>(nullable: false),
                    RoundId = table.Column<int>(nullable: false)
                },
                constraints: table => 
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            // Kopieren der Stations
            migrationBuilder.Sql("INSERT INTO TempStations SELECT Id, Position, RoundId FROM Stations");
            migrationBuilder.Sql("PRAGMA foreign_keys=\"0\"", true);
            // Drop Stations
            migrationBuilder.Sql("DROP TABLE Stations;", true);
            // Rename Temp Tabelle
            migrationBuilder.Sql("ALTER TABLE TempStations RENAME TO Stations", true);
            migrationBuilder.Sql("PRAGMA foreign_keys=\"1\"", true);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RoundId",
                table: "Stations",
                column: "RoundId"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mandatory",
                table: "AssemblySteps");

            migrationBuilder.AddColumn<bool>(
                name: "Mandatory",
                table: "Stations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
            

        }
    }
}
