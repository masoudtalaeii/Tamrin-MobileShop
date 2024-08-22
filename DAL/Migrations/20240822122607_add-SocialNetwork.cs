using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addSocialNetwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "socialNetworks",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlTellgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlWhatsUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlInstagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlEita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlAparat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlYoutube = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialNetworks", x => x.SocialNetworkId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "socialNetworks");
        }
    }
}
