using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PotentialUserRequiredColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "PotentialUsers",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Semester",
                table: "PotentialUsers",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "IsStudent",
                table: "PotentialUsers",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "IsMainProfessor",
                table: "PotentialUsers",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "PotentialUsers",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Semester",
                table: "PotentialUsers",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsStudent",
                table: "PotentialUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMainProfessor",
                table: "PotentialUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
