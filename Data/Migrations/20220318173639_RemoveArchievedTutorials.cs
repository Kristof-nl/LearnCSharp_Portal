using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RemoveArchievedTutorials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningLists_ArchivedTutorials_ArchivedTutorialsId",
                table: "LearningLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutorials_ArchivedTutorials_ArchivedTutorialsId",
                table: "Tutorials");

            migrationBuilder.DropTable(
                name: "ArchivedTutorials");

            migrationBuilder.DropIndex(
                name: "IX_LearningLists_ArchivedTutorialsId",
                table: "LearningLists");

            migrationBuilder.DropColumn(
                name: "ArchivedTutorialsId",
                table: "LearningLists");

            migrationBuilder.RenameColumn(
                name: "ArchivedTutorialsId",
                table: "Tutorials",
                newName: "LearningListId1");

            migrationBuilder.RenameIndex(
                name: "IX_Tutorials_ArchivedTutorialsId",
                table: "Tutorials",
                newName: "IX_Tutorials_LearningListId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutorials_LearningLists_LearningListId1",
                table: "Tutorials",
                column: "LearningListId1",
                principalTable: "LearningLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutorials_LearningLists_LearningListId1",
                table: "Tutorials");

            migrationBuilder.RenameColumn(
                name: "LearningListId1",
                table: "Tutorials",
                newName: "ArchivedTutorialsId");

            migrationBuilder.RenameIndex(
                name: "IX_Tutorials_LearningListId1",
                table: "Tutorials",
                newName: "IX_Tutorials_ArchivedTutorialsId");

            migrationBuilder.AddColumn<int>(
                name: "ArchivedTutorialsId",
                table: "LearningLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArchivedTutorials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedTutorials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningLists_ArchivedTutorialsId",
                table: "LearningLists",
                column: "ArchivedTutorialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningLists_ArchivedTutorials_ArchivedTutorialsId",
                table: "LearningLists",
                column: "ArchivedTutorialsId",
                principalTable: "ArchivedTutorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutorials_ArchivedTutorials_ArchivedTutorialsId",
                table: "Tutorials",
                column: "ArchivedTutorialsId",
                principalTable: "ArchivedTutorials",
                principalColumn: "Id");
        }
    }
}
