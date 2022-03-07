﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SBC.Data.Migrations
{
    public partial class addimageUrlcoach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Coaches");
        }
    }
}