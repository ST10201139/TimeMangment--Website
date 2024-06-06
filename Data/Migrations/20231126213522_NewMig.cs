using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_POE_TimeMangement.Data.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyHour_Module_StudyModuleModuleId",
                table: "StudyHour");

            migrationBuilder.DropIndex(
                name: "IX_StudyHour_StudyModuleModuleId",
                table: "StudyHour");

            migrationBuilder.DropColumn(
                name: "StudyModuleModuleId",
                table: "StudyHour");

            migrationBuilder.CreateIndex(
                name: "IX_StudyHour_ModuleId",
                table: "StudyHour",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyHour_Module_ModuleId",
                table: "StudyHour",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyHour_Module_ModuleId",
                table: "StudyHour");

            migrationBuilder.DropIndex(
                name: "IX_StudyHour_ModuleId",
                table: "StudyHour");

            migrationBuilder.AddColumn<int>(
                name: "StudyModuleModuleId",
                table: "StudyHour",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudyHour_StudyModuleModuleId",
                table: "StudyHour",
                column: "StudyModuleModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyHour_Module_StudyModuleModuleId",
                table: "StudyHour",
                column: "StudyModuleModuleId",
                principalTable: "Module",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
