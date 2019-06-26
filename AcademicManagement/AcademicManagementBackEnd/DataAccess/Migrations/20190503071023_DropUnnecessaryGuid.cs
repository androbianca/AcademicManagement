using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DropUnnecessaryGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ProfRole");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "PotentialUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "PotentialUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "PotentialUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "UserRoles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "ProfRole",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "PotentialUsers",
                nullable: false,
                defaultValue: "");
        }
    }
}
