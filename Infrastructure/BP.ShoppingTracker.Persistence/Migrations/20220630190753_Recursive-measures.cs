using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.Persistence.Migrations
{
    public partial class Recursivemeasures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUnitBase",
                table: "MeasureType",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UnitBaseFK",
                table: "MeasureType",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasureType_UnitBaseFK",
                table: "MeasureType",
                column: "UnitBaseFK");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasureType_MeasureType",
                table: "MeasureType",
                column: "UnitBaseFK",
                principalTable: "MeasureType",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasureType_MeasureType",
                table: "MeasureType");

            migrationBuilder.DropIndex(
                name: "IX_MeasureType_UnitBaseFK",
                table: "MeasureType");

            migrationBuilder.DropColumn(
                name: "IsUnitBase",
                table: "MeasureType");

            migrationBuilder.DropColumn(
                name: "UnitBaseFK",
                table: "MeasureType");
        }
    }
}
