using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class notificationAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Students_StudentId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationUser_Students_StudentId",
                table: "NotificationUser");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_StudentId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "NotificationUser",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationUser_StudentId",
                table: "NotificationUser",
                newName: "IX_NotificationUser_AccountId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AccountId",
                table: "Notifications",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Accounts_AccountId",
                table: "Notifications",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationUser_Accounts_AccountId",
                table: "NotificationUser",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Accounts_AccountId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationUser_Accounts_AccountId",
                table: "NotificationUser");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AccountId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "NotificationUser",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationUser_AccountId",
                table: "NotificationUser",
                newName: "IX_NotificationUser_StudentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_StudentId",
                table: "Notifications",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Students_StudentId",
                table: "Notifications",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationUser_Students_StudentId",
                table: "NotificationUser",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
