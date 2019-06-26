using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ModifiedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "PotentialUsers",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "PotentialUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "PotentialUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "PotentialUsers",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 3);
        }
    }
}
