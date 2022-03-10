using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ChangeInSourceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tutorials_SourceId",
                table: "Tutorials");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_SourceId",
                table: "Tutorials",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tutorials_SourceId",
                table: "Tutorials");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_SourceId",
                table: "Tutorials",
                column: "SourceId",
                unique: true);
        }
    }
}
