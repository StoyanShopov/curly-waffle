namespace SBC.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddFeedbackCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LeftFeedback",
                table: "UserCoachSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftFeedback",
                table: "UserCoachSessions");
        }
    }
}
