using Microsoft.EntityFrameworkCore.Migrations;

namespace Saitynas.Migrations
{
    public partial class AddKeyToCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "tblRating",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblRating_CreatorId",
                table: "tblRating",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRating_tblCreator_CreatorId",
                table: "tblRating",
                column: "CreatorId",
                principalTable: "tblCreator",
                principalColumn: "CreatorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRating_tblCreator_CreatorId",
                table: "tblRating");

            migrationBuilder.DropIndex(
                name: "IX_tblRating_CreatorId",
                table: "tblRating");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "tblRating");
        }
    }
}
