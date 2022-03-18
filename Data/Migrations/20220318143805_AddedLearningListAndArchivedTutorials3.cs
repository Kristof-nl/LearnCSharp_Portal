using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddedLearningListAndArchivedTutorials3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArchivedTutorialsId",
                table: "Tutorials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearningListId",
                table: "Tutorials",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "LearningLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ArchivedTutorialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningLists_ArchivedTutorials_ArchivedTutorialsId",
                        column: x => x.ArchivedTutorialsId,
                        principalTable: "ArchivedTutorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningLists_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_ArchivedTutorialsId",
                table: "Tutorials",
                column: "ArchivedTutorialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_LearningListId",
                table: "Tutorials",
                column: "LearningListId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningLists_ApplicationUserId",
                table: "LearningLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningLists_ArchivedTutorialsId",
                table: "LearningLists",
                column: "ArchivedTutorialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutorials_ArchivedTutorials_ArchivedTutorialsId",
                table: "Tutorials",
                column: "ArchivedTutorialsId",
                principalTable: "ArchivedTutorials",
                principalColumn: "Id");

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
                name: "FK_Tutorials_ArchivedTutorials_ArchivedTutorialsId",
                table: "Tutorials");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutorials_LearningLists_LearningListId",
                table: "Tutorials");

            migrationBuilder.DropTable(
                name: "LearningLists");

            migrationBuilder.DropTable(
                name: "ArchivedTutorials");

            migrationBuilder.DropIndex(
                name: "IX_Tutorials_ArchivedTutorialsId",
                table: "Tutorials");

            migrationBuilder.DropIndex(
                name: "IX_Tutorials_LearningListId",
                table: "Tutorials");

            migrationBuilder.DropColumn(
                name: "ArchivedTutorialsId",
                table: "Tutorials");

            migrationBuilder.DropColumn(
                name: "LearningListId",
                table: "Tutorials");
        }
    }
}
