using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AnalyticsApp.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Website",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WebsiteId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WebsiteId",
                table: "AspNetUsers",
                column: "WebsiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Website_WebsiteId",
                table: "AspNetUsers",
                column: "WebsiteId",
                principalTable: "Website",
                principalColumn: "WebsiteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Website_WebsiteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WebsiteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Website");

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "AspNetUsers");
        }
    }
}
