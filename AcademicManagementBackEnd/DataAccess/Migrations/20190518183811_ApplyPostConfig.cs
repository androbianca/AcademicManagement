using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ApplyPostConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Accounts_AccountId1",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_AccountId1",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "posts");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "posts",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "posts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_AccountId",
                table: "posts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_Accounts_AccountId",
                table: "posts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_Accounts_AccountId",
                table: "posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_AccountId",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Post",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Post",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId1",
                table: "Post",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AccountId1",
                table: "Post",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Accounts_AccountId1",
                table: "Post",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
