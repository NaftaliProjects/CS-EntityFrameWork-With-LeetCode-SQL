using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCodeProblems.Migrations.LeetCodeProblems_1148Migrations
{
    /// <inheritdoc />
    public partial class LeetCodeProblems_1148_added_HasNoKey_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "World");

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Article_id = table.Column<int>(type: "int", nullable: false),
                    Author_id = table.Column<int>(type: "int", nullable: false),
                    Viewer_id = table.Column<int>(type: "int", nullable: false),
                    View_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.CreateTable(
                name: "World",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gdp = table.Column<double>(type: "float", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_World", x => x.Name);
                });
        }
    }
}
