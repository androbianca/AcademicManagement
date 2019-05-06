using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UserRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isStudent",
                table: "PotentialUsers");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "PotentialUsers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "PotentialUsers");

            migrationBuilder.AddColumn<bool>(
                name: "isStudent",
                table: "PotentialUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "Accounts",
                nullable: false,
                defaultValue: false);
        }
    }
}
