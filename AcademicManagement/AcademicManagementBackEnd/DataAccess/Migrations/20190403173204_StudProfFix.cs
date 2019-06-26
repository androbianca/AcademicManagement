using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class StudProfFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "Students",
                newName: "UserCode");

            migrationBuilder.RenameColumn(
                name: "ProfessorCode",
                table: "Professors",
                newName: "UserCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCode",
                table: "Students",
                newName: "StudentCode");

            migrationBuilder.RenameColumn(
                name: "UserCode",
                table: "Professors",
                newName: "ProfessorCode");
        }
    }
}
