using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OllivandersShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Core = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Wood = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LengthInInches = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    TrueOwner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wands", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wands");
        }
    }
}
