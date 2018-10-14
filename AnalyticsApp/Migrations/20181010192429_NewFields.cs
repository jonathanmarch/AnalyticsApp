using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AnalyticsApp.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OS",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Events",
                newName: "URL");

            migrationBuilder.AddColumn<int>(
                name: "Browser",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Browser",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Events",
                newName: "Country");

            migrationBuilder.AddColumn<int>(
                name: "OS",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }
    }
}
