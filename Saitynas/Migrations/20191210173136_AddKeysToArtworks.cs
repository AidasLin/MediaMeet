using Microsoft.EntityFrameworkCore.Migrations;

namespace Saitynas.Migrations
{
    public partial class AddKeysToArtworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "tblArtwork",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tblArtwork",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblArtwork_CreatorId",
                table: "tblArtwork",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblArtwork_UserId",
                table: "tblArtwork",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblArtwork_tblCreator_CreatorId",
                table: "tblArtwork",
                column: "CreatorId",
                principalTable: "tblCreator",
                principalColumn: "CreatorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblArtwork_tblUser_UserId",
                table: "tblArtwork",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblArtwork_tblCreator_CreatorId",
                table: "tblArtwork");

            migrationBuilder.DropForeignKey(
                name: "FK_tblArtwork_tblUser_UserId",
                table: "tblArtwork");

            migrationBuilder.DropIndex(
                name: "IX_tblArtwork_CreatorId",
                table: "tblArtwork");

            migrationBuilder.DropIndex(
                name: "IX_tblArtwork_UserId",
                table: "tblArtwork");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "tblArtwork");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblArtwork");
        }
    }
}
