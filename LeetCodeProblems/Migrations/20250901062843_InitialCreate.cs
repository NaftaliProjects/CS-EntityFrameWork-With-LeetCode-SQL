using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCodeProblems.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    low_fats = table.Column<string>(type: "char(1)", nullable: false),
                    recyclable = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.CheckConstraint("CK_low_fats_Y_N", "[low_fats] IN ('Y', 'N')");
                    table.CheckConstraint("CK_recyclable_Y_N", "[recyclable] IN ('Y', 'N')");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
