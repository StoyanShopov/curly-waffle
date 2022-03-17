namespace SBC.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class LanguageAndCoachNotDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LanguageCoaches_IsDeleted",
                table: "LanguageCoaches");

            migrationBuilder.DropIndex(
                name: "IX_CategoryCoaches_IsDeleted",
                table: "CategoryCoaches");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "LanguageCoaches");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LanguageCoaches");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CategoryCoaches");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CategoryCoaches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "LanguageCoaches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LanguageCoaches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CategoryCoaches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CategoryCoaches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageCoaches_IsDeleted",
                table: "LanguageCoaches",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCoaches_IsDeleted",
                table: "CategoryCoaches",
                column: "IsDeleted");
        }
    }
}
