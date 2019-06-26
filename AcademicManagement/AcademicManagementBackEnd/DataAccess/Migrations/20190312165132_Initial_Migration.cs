using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PotentialUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserCode = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    Year = table.Column<string>(maxLength: 3, nullable: false),
                    Group = table.Column<string>(maxLength: 3, nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserCode = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PotentialUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_User_PotentialUser",
                        column: x => x.PotentialUserId,
                        principalTable: "PotentialUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PotentialUserId",
                table: "Users",
                column: "PotentialUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PotentialUsers");
        }
    }
}
