using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.Persistence.Migrations
{
    public partial class CompositeKeyFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Format",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_FormatFK",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CombinedFormat",
                table: "CombinedFormat");

            migrationBuilder.DropIndex(
                name: "IX_Format_Format_MainFormatFK",
                table: "CombinedFormat");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "CombinedFormat");

            migrationBuilder.RenameColumn(
                name: "FormatFK",
                table: "Product",
                newName: "FormatFK2");

            migrationBuilder.RenameIndex(
                name: "IX_Format_Format_DerivedFormatFK",
                table: "CombinedFormat",
                newName: "IX_CombinedFormat_DerivedFormatFK");

            migrationBuilder.AddColumn<Guid>(
                name: "FormatFK1",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombinedFormat",
                table: "CombinedFormat",
                columns: new[] { "MainFormatFK", "DerivedFormatFK" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FormatFK1_FormatFK2",
                table: "Product",
                columns: new[] { "FormatFK1", "FormatFK2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Format",
                table: "Product",
                columns: new[] { "FormatFK1", "FormatFK2" },
                principalTable: "CombinedFormat",
                principalColumns: new[] { "MainFormatFK", "DerivedFormatFK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Format",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_FormatFK1_FormatFK2",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CombinedFormat",
                table: "CombinedFormat");

            migrationBuilder.DropColumn(
                name: "FormatFK1",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "FormatFK2",
                table: "Product",
                newName: "FormatFK");

            migrationBuilder.RenameIndex(
                name: "IX_CombinedFormat_DerivedFormatFK",
                table: "CombinedFormat",
                newName: "IX_Format_Format_DerivedFormatFK");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "CombinedFormat",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombinedFormat",
                table: "CombinedFormat",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FormatFK",
                table: "Product",
                column: "FormatFK");

            migrationBuilder.CreateIndex(
                name: "IX_Format_Format_MainFormatFK",
                table: "CombinedFormat",
                column: "MainFormatFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Format",
                table: "Product",
                column: "FormatFK",
                principalTable: "CombinedFormat",
                principalColumn: "ID");
        }
    }
}
