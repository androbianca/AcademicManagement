using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DBRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotentialUserProfRole");

            migrationBuilder.DropTable(
                name: "PotentialUsersCourse");

            migrationBuilder.DropTable(
                name: "ProfRoles");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PotentialUsers");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "PotentialUsers");

            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "PotentialUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "PotentialUsers");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "PotentialUsers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "PotentialUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserCode = table.Column<string>(nullable: false),
                    isStudent = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PotentialUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Account_PotentialUser",
                        column: x => x.PotentialUserId,
                        principalTable: "PotentialUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfCourse",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    ProfId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfCourse", x => new { x.CourseId, x.ProfId });
                    table.ForeignKey(
                        name: "FK_ProfCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfCourse_Professors_ProfId",
                        column: x => x.ProfId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudCourse",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    StudId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudCourse", x => new { x.CourseId, x.StudId });
                    table.ForeignKey(
                        name: "FK_StudCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudCourse_Students_StudId",
                        column: x => x.StudId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PotentialUserId",
                table: "Accounts",
                column: "PotentialUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfCourse_ProfId",
                table: "ProfCourse",
                column: "ProfId");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourse_StudId",
                table: "StudCourse",
                column: "StudId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Student_Group",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Student_Group",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ProfCourse");

            migrationBuilder.DropTable(
                name: "StudCourse");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Professors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Professors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "Professors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PotentialUsers",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "PotentialUsers",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "PotentialUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "PotentialUsers",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "PotentialUsers",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "PotentialUsers",
                maxLength: 1,
                nullable: true);

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
                        name: "FK_PotentialUsersCourse_PotentialUsers_PotentialUserId",
                        column: x => x.PotentialUserId,
                        principalTable: "PotentialUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PotentialUsersCourse_PotentialUserId",
                table: "PotentialUsersCourse",
                column: "PotentialUserId");
        }
    }
}
