using Microsoft.EntityFrameworkCore.Migrations;

namespace Saitynas.Migrations
{
    public partial class AddOtherKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RatingOwnerID",
                table: "tblRating");

            migrationBuilder.AddColumn<int>(
                name: "TblCreator",
                table: "tblRating",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblRating_TblCreator",
                table: "tblRating",
                column: "TblCreator");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRating_tblCreator_TblCreator",
                table: "tblRating",
                column: "TblCreator",
                principalTable: "tblCreator",
                principalColumn: "CreatorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRating_tblCreator_TblCreator",
                table: "tblRating");

            migrationBuilder.DropIndex(
                name: "IX_tblRating_TblCreator",
                table: "tblRating");

            migrationBuilder.DropColumn(
                name: "TblCreator",
                table: "tblRating");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "tblRating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingOwnerID",
                table: "tblRating",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
