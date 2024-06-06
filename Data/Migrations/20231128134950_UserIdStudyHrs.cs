using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_POE_TimeMangement.Data.Migrations
{
    public partial class UserIdStudyHrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "StudyHour",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "StudyHour");
        }
    }
}
