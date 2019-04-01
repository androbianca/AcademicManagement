using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class OptionalTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OptionalId",
                table: "CourseProfessor",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Optionals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Year = table.Column<int>(maxLength: 1, nullable: false),
                    Semester = table.Column<int>(maxLength: 1, nullable: false),
                    Package = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Optionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionalPotentialUsers",
                columns: table => new
                {
                    OptionalId = table.Column<Guid>(nullable: false),
                    PotentialUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalPotentialUsers", x => new { x.OptionalId, x.PotentialUserId });
                    table.ForeignKey(
                        name: "FK_OptionalPotentialUsers_PotentialUsers_OptionalId",
                        column: x => x.OptionalId,
                        principalTable: "PotentialUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionalPotentialUsers_Optionals_PotentialUserId",
                        column: x => x.PotentialUserId,
                        principalTable: "Optionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfessor_OptionalId",
                table: "CourseProfessor",
                column: "OptionalId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionalPotentialUsers_PotentialUserId",
                table: "OptionalPotentialUsers",
                column: "PotentialUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProfessor_Optionals_OptionalId",
                table: "CourseProfessor",
                column: "OptionalId",
                principalTable: "Optionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseProfessor_Optionals_OptionalId",
                table: "CourseProfessor");

            migrationBuilder.DropTable(
                name: "OptionalPotentialUsers");

            migrationBuilder.DropTable(
                name: "Optionals");

            migrationBuilder.DropIndex(
                name: "IX_CourseProfessor_OptionalId",
                table: "CourseProfessor");

            migrationBuilder.DropColumn(
                name: "OptionalId",
                table: "CourseProfessor");
        }
    }
}
