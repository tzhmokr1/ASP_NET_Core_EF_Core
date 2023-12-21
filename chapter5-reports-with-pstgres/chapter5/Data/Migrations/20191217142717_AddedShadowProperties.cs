using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace chapter5.Data.Migrations
{
    public partial class AddedShadowProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StationsAssemblyStepss",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "LatestUser",
                table: "StationsAssemblyStepss",
                nullable: true,
                defaultValue: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StationsAssemblyStepss",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Stations",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "LatestUser",
                table: "Stations",
                nullable: true,
                defaultValue: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Stations",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Rounds",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "LatestUser",
                table: "Rounds",
                nullable: true,
                defaultValue: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Rounds",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "LatestUser",
                table: "Products",
                nullable: true,
                defaultValue: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Parts",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "LatestUser",
                table: "Parts",
                nullable: true,
                defaultValue: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Parts",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PartDefinitions",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "LatestUser",
                table: "PartDefinitions",
                nullable: true,
                defaultValue: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PartDefinitions",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AssemblySteps",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "LatestUser",
                table: "AssemblySteps",
                nullable: true,
                defaultValue: "Admin");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AssemblySteps",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StationsAssemblyStepss");

            migrationBuilder.DropColumn(
                name: "LatestUser",
                table: "StationsAssemblyStepss");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StationsAssemblyStepss");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "LatestUser",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "LatestUser",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LatestUser",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "LatestUser",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PartDefinitions");

            migrationBuilder.DropColumn(
                name: "LatestUser",
                table: "PartDefinitions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PartDefinitions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AssemblySteps");

            migrationBuilder.DropColumn(
                name: "LatestUser",
                table: "AssemblySteps");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AssemblySteps");
        }
    }
}
