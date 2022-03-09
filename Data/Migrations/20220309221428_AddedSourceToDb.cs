using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddedSourceToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Tutorials");

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Tutorials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_SourceId",
                table: "Tutorials",
                column: "SourceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutorials_Sources_SourceId",
                table: "Tutorials",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutorials_Sources_SourceId",
                table: "Tutorials");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropIndex(
                name: "IX_Tutorials_SourceId",
                table: "Tutorials");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Tutorials");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Tutorials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
