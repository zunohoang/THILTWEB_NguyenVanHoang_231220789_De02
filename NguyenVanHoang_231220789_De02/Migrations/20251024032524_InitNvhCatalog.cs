using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenVanHoang_231220789_De02.Migrations
{
    /// <inheritdoc />
    public partial class InitNvhCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NvhCatalog",
                columns: table => new
                {
                    nvhId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvhCateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nvhCatePrice = table.Column<int>(type: "int", nullable: false),
                    nvhCateQty = table.Column<int>(type: "int", nullable: false),
                    nvhPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nvhCateActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NvhCatalog", x => x.nvhId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NvhCatalog");
        }
    }
}
