﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ChangedApplicationUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningLists_AspNetUsers_ApplicationUserId1",
                table: "LearningLists");

            migrationBuilder.DropIndex(
                name: "IX_LearningLists_ApplicationUserId1",
                table: "LearningLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "LearningLists");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "LearningLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_LearningLists_ApplicationUserId",
                table: "LearningLists",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningLists_AspNetUsers_ApplicationUserId",
                table: "LearningLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningLists_AspNetUsers_ApplicationUserId",
                table: "LearningLists");

            migrationBuilder.DropIndex(
                name: "IX_LearningLists_ApplicationUserId",
                table: "LearningLists");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "LearningLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "LearningLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningLists_ApplicationUserId1",
                table: "LearningLists",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningLists_AspNetUsers_ApplicationUserId1",
                table: "LearningLists",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
