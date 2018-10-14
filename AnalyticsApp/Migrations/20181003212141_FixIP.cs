using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AnalyticsApp.Migrations
{
    public partial class FixIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddressBytes",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Events",
                maxLength: 16,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Events");

            migrationBuilder.AddColumn<byte[]>(
                name: "IPAddressBytes",
                table: "Events",
                maxLength: 16,
                nullable: true);
        }
    }
}
