using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updatedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCourseCategory",
                table: "GradeCategories");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "GradeCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "FinalGrades",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCourseCategory",
                table: "GradeCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Percentage",
                table: "GradeCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "FinalGrades",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
