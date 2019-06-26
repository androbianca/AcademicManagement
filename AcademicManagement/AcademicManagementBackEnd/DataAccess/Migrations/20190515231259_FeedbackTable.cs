using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FeedbackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfCourse");

            migrationBuilder.DropTable(
                name: "ProfGroup");

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    ReciverId = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: true),
                    SenderId = table.Column<Guid>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CourseId",
                table: "Feedback",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ProfessorId",
                table: "Feedback",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_StudentId",
                table: "Feedback",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

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
                name: "ProfGroup",
                columns: table => new
                {
                    ProfId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfGroup", x => new { x.ProfId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_ProfGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfGroup_Professors_ProfId",
                        column: x => x.ProfId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfCourse_ProfId",
                table: "ProfCourse",
                column: "ProfId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfGroup_GroupId",
                table: "ProfGroup",
                column: "GroupId");
        }
    }
}
