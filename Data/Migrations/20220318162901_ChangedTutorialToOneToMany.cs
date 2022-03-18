using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ChangedTutorialToOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutorials_LearningLists_LearningListId",
                table: "Tutorials");

            migrationBuilder.DropIndex(
                name: "IX_Tutorials_LearningListId",
                table: "Tutorials");

            migrationBuilder.DropColumn(
                name: "LearningListId",
                table: "Tutorials");

            migrationBuilder.AddColumn<int>(
                name: "TutorialId",
                table: "LearningLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LearningLists_TutorialId",
                table: "LearningLists",
                column: "TutorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningLists_Tutorials_TutorialId",
                table: "LearningLists",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningLists_Tutorials_TutorialId",
                table: "LearningLists");

            migrationBuilder.DropIndex(
                name: "IX_LearningLists_TutorialId",
                table: "LearningLists");

            migrationBuilder.DropColumn(
                name: "TutorialId",
                table: "LearningLists");

            migrationBuilder.AddColumn<int>(
                name: "LearningListId",
                table: "Tutorials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_LearningListId",
                table: "Tutorials",
                column: "LearningListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutorials_LearningLists_LearningListId",
                table: "Tutorials",
                column: "LearningListId",
                principalTable: "LearningLists",
                principalColumn: "Id");
        }
    }
}
