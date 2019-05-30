using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdatedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Percentaje",
                table: "GradeCategories",
                newName: "Percentage");

            migrationBuilder.AddColumn<bool>(
                name: "isCourseCategory",
                table: "GradeCategories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCourseCategory",
                table: "GradeCategories");

            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "GradeCategories",
                newName: "Percentaje");
        }
    }
}
