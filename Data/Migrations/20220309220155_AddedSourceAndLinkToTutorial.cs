using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddedSourceAndLinkToTutorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScore_Tutorials_TutorialId",
                table: "UserScore");

            migrationBuilder.AlterColumn<int>(
                name: "TutorialId",
                table: "UserScore",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Tutorials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Tutorials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserScore_Tutorials_TutorialId",
                table: "UserScore",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScore_Tutorials_TutorialId",
                table: "UserScore");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Tutorials");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Tutorials");

            migrationBuilder.AlterColumn<int>(
                name: "TutorialId",
                table: "UserScore",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserScore_Tutorials_TutorialId",
                table: "UserScore",
                column: "TutorialId",
                principalTable: "Tutorials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
