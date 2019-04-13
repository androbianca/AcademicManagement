using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class PotentialUsesProfRoleConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainProfessor",
                table: "PotentialUsers");

            migrationBuilder.CreateTable(
                name: "ProfRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PotentialUserProfRole",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    PotentialUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialUserProfRole", x => new { x.RoleId, x.PotentialUserId });
                    table.ForeignKey(
                        name: "FK_PotentialUserProfRole_PotentialUsers_PotentialUserId",
                        column: x => x.PotentialUserId,
                        principalTable: "PotentialUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotentialUserProfRole_ProfRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ProfRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PotentialUserProfRole_PotentialUserId",
                table: "PotentialUserProfRole",
                column: "PotentialUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotentialUserProfRole");

            migrationBuilder.DropTable(
                name: "ProfRoles");

            migrationBuilder.AddColumn<bool>(
                name: "IsMainProfessor",
                table: "PotentialUsers",
                nullable: true);
        }
    }
}
