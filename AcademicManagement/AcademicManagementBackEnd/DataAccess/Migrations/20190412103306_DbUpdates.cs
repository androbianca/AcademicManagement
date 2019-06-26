using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DbUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PUserOptionalCourse");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "PotentialUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Professors",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Professors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Professors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Professors",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "PotentialUser",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.CreateTable(
                name: "PotentialUsersCourse",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    PotentialUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialUsersCourse", x => new { x.CourseId, x.PotentialUserId });
                    table.ForeignKey(
                        name: "FK_PotentialUsersCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotentialUsersCourse_PotentialUser_PotentialUserId",
                        column: x => x.PotentialUserId,
                        principalTable: "PotentialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PotentialUsersCourse_PotentialUserId",
                table: "PotentialUsersCourse",
                column: "PotentialUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotentialUsersCourse");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Professors");

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Professors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Professors",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Professors",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "PotentialUser",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "PotentialUser",
                nullable: true);

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
        }
    }
}
