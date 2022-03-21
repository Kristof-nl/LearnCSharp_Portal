using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UserScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScore_Tutorials_TutorialId",
                table: "UserScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserScore",
                table: "UserScore");

            migrationBuilder.RenameTable(
                name: "UserScore",
                newName: "UserScores");

            migrationBuilder.RenameIndex(
                name: "IX_UserScore_TutorialId",
                table: "UserScores",
                newName: "IX_UserScores_TutorialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserScores",
                table: "UserScores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserScores_Tutorials_TutorialId",
                table: "UserScores",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScores_Tutorials_TutorialId",
                table: "UserScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserScores",
                table: "UserScores");

            migrationBuilder.RenameTable(
                name: "UserScores",
                newName: "UserScore");

            migrationBuilder.RenameIndex(
                name: "IX_UserScores_TutorialId",
                table: "UserScore",
                newName: "IX_UserScore_TutorialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserScore",
                table: "UserScore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserScore_Tutorials_TutorialId",
                table: "UserScore",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id");
        }
    }
}
