using Microsoft.EntityFrameworkCore.Migrations;

namespace Saitynas.Migrations
{
    public partial class AddDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblArtwork",
                columns: table => new
                {
                    ArtworkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtworkCreatorID = table.Column<int>(nullable: false),
                    ArtworkUrl = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ArtworkOwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblArtwo__D073AEBB085C0584", x => x.ArtworkID);
                });

            migrationBuilder.CreateTable(
                name: "tblCities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCitie__F2D21A966B9021CB", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "tblCreator",
                columns: table => new
                {
                    CreatorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Pseudonym = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Department = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCreat__6C7548116A821B5A", x => x.CreatorID);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    RatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingCreatorID = table.Column<int>(nullable: false),
                    RatingValue = table.Column<int>(nullable: false),
                    RatingOwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblRatin__FCCDF85CDB172B29", x => x.RatingID);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    UserRole = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblUser__1788CCACDC8E890D", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblArtwork");

            migrationBuilder.DropTable(
                name: "tblCities");

            migrationBuilder.DropTable(
                name: "tblCreator");

            migrationBuilder.DropTable(
                name: "tblRating");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
