using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NotificationTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Accounts_AccountId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AccountId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Notifications",
                newName: "SenderId");

            migrationBuilder.AddColumn<Guid>(
                name: "ReciverId",
                table: "Notifications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReciverId",
                table: "Notifications",
                column: "ReciverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Accounts_ReciverId",
                table: "Notifications",
                column: "ReciverId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Accounts_ReciverId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReciverId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReciverId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Notifications",
                newName: "AccountId");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
