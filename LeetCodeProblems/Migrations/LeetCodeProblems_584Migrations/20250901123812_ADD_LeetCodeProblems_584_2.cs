using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCodeProblems.Migrations.LeetCodeProblems_584Migrations
{
    /// <inheritdoc />
    public partial class ADD_LeetCodeProblems_584_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__customer",
                table: "_customer");

            migrationBuilder.RenameTable(
                name: "_customer",
                newName: "customer");

            migrationBuilder.AlterColumn<int>(
                name: "Referee_id",
                table: "customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "_customer");

            migrationBuilder.AlterColumn<int>(
                name: "Referee_id",
                table: "_customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__customer",
                table: "_customer",
                column: "Id");
        }
    }
}
