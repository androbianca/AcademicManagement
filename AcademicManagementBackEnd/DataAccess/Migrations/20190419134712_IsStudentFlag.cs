using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class IsStudentFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isStudent",
                table: "Accounts");

            migrationBuilder.AddColumn<bool>(
                name: "isStudent",
                table: "PotentialUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isStudent",
                table: "PotentialUsers");

            migrationBuilder.AddColumn<bool>(
                name: "isStudent",
                table: "Accounts",
                nullable: false,
                defaultValue: false);
        }
    }
}
