using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddedListTutorialsToLearningList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
