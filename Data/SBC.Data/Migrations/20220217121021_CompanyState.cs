namespace SBC.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CompanyState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompaniesCourses",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesCourses", x => new { x.CompanyId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CompaniesCourses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCoaches",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCoaches", x => new { x.CompanyId, x.CoachId });
                    table.ForeignKey(
                        name: "FK_CompanyCoaches_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyCoaches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesCourses_CourseId",
                table: "CompaniesCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesCourses_IsDeleted",
                table: "CompaniesCourses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCoaches_CoachId",
                table: "CompanyCoaches",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCoaches_IsDeleted",
                table: "CompanyCoaches",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesCourses");

            migrationBuilder.DropTable(
                name: "CompanyCoaches");
        }
    }
}
