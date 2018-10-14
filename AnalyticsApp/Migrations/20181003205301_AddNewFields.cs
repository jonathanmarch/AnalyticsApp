using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AnalyticsApp.Migrations
{
    public partial class AddNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "IPAddressBytes",
                table: "Events",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 16);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Events");

            migrationBuilder.AlterColumn<byte[]>(
                name: "IPAddressBytes",
                table: "Events",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
