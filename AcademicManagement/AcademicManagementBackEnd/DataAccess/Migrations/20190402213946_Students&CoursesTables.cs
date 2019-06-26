using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class StudentsCoursesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_User_PotentialUser",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PotentialUsers",
                table: "PotentialUsers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "PotentialUsers",
                newName: "PotentialUser");

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
                table: "Students",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "PotentialUser",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "PotentialUser",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PotentialUser",
                table: "PotentialUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Year = table.Column<int>(maxLength: 1, nullable: false),
                    Semester = table.Column<int>(maxLength: 1, nullable: false),
                    Package = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PUserOptionalCourse",
                columns: table => new
                {
                    OptionalCourseId = table.Column<Guid>(nullable: false),
                    PotentialUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUserOptionalCourse", x => new { x.OptionalCourseId, x.PotentialUserId });
                    table.ForeignKey(
                        name: "FK_PUserOptionalCourse_Courses_OptionalCourseId",
                        column: x => x.OptionalCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PUserOptionalCourse_PotentialUser_PotentialUserId",
                        column: x => x.PotentialUserId,
                        principalTable: "PotentialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PUserOptionalCourse_PotentialUserId",
                table: "PUserOptionalCourse",
                column: "PotentialUserId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Student_PotentialUser",
                table: "Students",
                column: "PotentialUserId",
                principalTable: "PotentialUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Student_PotentialUser",
                table: "Students");

            migrationBuilder.DropTable(
                name: "PUserOptionalCourse");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PotentialUser",
                table: "PotentialUser");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "PotentialUser",
                newName: "PotentialUsers");

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
                table: "Users",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PotentialUsers",
                table: "PotentialUsers",
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
