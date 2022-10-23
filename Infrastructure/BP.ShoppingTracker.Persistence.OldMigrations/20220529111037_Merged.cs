using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.I30.Persistence.Migrations
{
    public partial class Merged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Format_Format",
                table: "Format_Format");

            migrationBuilder.RenameTable(
                name: "Format_Format",
                newName: "CombinedFormat");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "CombinedFormat",
                type: "bit",
                nullable: false,
                defaultValueSql: "(CONVERT([bit],(1)))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombinedFormat",
                table: "CombinedFormat",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CombinedFormat",
                table: "CombinedFormat");

            migrationBuilder.RenameTable(
                name: "CombinedFormat",
                newName: "Format_Format");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Format_Format",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "(CONVERT([bit],(1)))");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Format_Format",
                table: "Format_Format",
                column: "ID");
        }
    }
}
