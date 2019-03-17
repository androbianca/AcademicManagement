using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CourseProfLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_User_PotentialUser",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Students");

            migrationBuilder.RenameColumn(
                name: "UserCode",
                table: "Students",
                newName: "StudentCode");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PotentialUserId",
                table: "Students",
                newName: "IX_Students_PotentialUserId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PotentialUsers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "PotentialUsers",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Year = table.Column<int>(maxLength: 1, nullable: false),
                    Semester = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProfessorCode = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    CourseName = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfessor",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfessor", x => new { x.CourseId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_CourseProfessor_Professors_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfessor_Courses_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfessor_ProfessorId",
                table: "CourseProfessor",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Student_PotentialUser",
                table: "Students",
                column: "PotentialUserId",
                principalTable: "PotentialUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Student_PotentialUser",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CourseProfessor");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "Users",
                newName: "UserCode");

            migrationBuilder.RenameIndex(
                name: "IX_Students_PotentialUserId",
                table: "Users",
                newName: "IX_Users_PotentialUserId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PotentialUsers",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "PotentialUsers",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_User_PotentialUser",
                table: "Users",
                column: "PotentialUserId",
                principalTable: "PotentialUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
