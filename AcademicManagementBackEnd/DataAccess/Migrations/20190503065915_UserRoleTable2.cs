using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UserRoleTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfRole_Professors_ProfId",
                table: "ProfRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfRole_Roles_RoleId",
                table: "ProfRole");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfRole",
                table: "ProfRole");

            migrationBuilder.DropIndex(
                name: "IX_ProfRole_RoleId",
                table: "ProfRole");

            migrationBuilder.DropColumn(
                name: "ProfId",
                table: "ProfRole");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProfRole",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProfRole",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfRole",
                table: "ProfRole",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfRole",
                table: "ProfRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfRole");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProfRole");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfId",
                table: "ProfRole",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfRole",
                table: "ProfRole",
                columns: new[] { "ProfId", "RoleId" });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfRole_RoleId",
                table: "ProfRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfRole_Professors_ProfId",
                table: "ProfRole",
                column: "ProfId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfRole_Roles_RoleId",
                table: "ProfRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
