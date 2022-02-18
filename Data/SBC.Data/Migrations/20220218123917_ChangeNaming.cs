namespace SBC.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesCourses_Companies_CompanyId",
                table: "CompaniesCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesCourses_Courses_CourseId",
                table: "CompaniesCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompaniesCourses",
                table: "CompaniesCourses");

            migrationBuilder.RenameTable(
                name: "CompaniesCourses",
                newName: "CompanyCourses");

            migrationBuilder.RenameIndex(
                name: "IX_CompaniesCourses_IsDeleted",
                table: "CompanyCourses",
                newName: "IX_CompanyCourses_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CompaniesCourses_CourseId",
                table: "CompanyCourses",
                newName: "IX_CompanyCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCourses",
                table: "CompanyCourses",
                columns: new[] { "CompanyId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCourses_Companies_CompanyId",
                table: "CompanyCourses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCourses_Courses_CourseId",
                table: "CompanyCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCourses_Companies_CompanyId",
                table: "CompanyCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCourses_Courses_CourseId",
                table: "CompanyCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCourses",
                table: "CompanyCourses");

            migrationBuilder.RenameTable(
                name: "CompanyCourses",
                newName: "CompaniesCourses");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCourses_IsDeleted",
                table: "CompaniesCourses",
                newName: "IX_CompaniesCourses_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCourses_CourseId",
                table: "CompaniesCourses",
                newName: "IX_CompaniesCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompaniesCourses",
                table: "CompaniesCourses",
                columns: new[] { "CompanyId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesCourses_Companies_CompanyId",
                table: "CompaniesCourses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesCourses_Courses_CourseId",
                table: "CompaniesCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
