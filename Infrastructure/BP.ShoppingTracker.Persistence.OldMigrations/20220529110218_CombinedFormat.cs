using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.I30.Persistence.Migrations
{
    public partial class CombinedFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Format_Format",
                table: "Format");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Format",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Format_ParentFK",
                table: "Format");

            migrationBuilder.CreateTable(
                name: "Format_Format",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainFormatFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DerivedFormatFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Format_Format", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CombinedFormat_Format_Derived",
                        column: x => x.DerivedFormatFK,
                        principalTable: "Format",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CombinedFormat_Format_Main",
                        column: x => x.MainFormatFK,
                        principalTable: "Format",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FormatFK",
                table: "Product",
                column: "FormatFK");

            migrationBuilder.CreateIndex(
                name: "IX_Format_Format_DerivedFormatFK",
                table: "Format_Format",
                column: "DerivedFormatFK");

            migrationBuilder.CreateIndex(
                name: "IX_Format_Format_MainFormatFK",
                table: "Format_Format",
                column: "MainFormatFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Format",
                table: "Product",
                column: "FormatFK",
                principalTable: "Format_Format",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Format",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Format_Format");

            migrationBuilder.DropIndex(
                name: "IX_Product_FormatFK",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Format_ParentFK",
                table: "Format",
                column: "ParentFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Format_Format",
                table: "Format",
                column: "ParentFK",
                principalTable: "Format",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Format",
                table: "Product",
                column: "ProductTypeFK",
                principalTable: "Format",
                principalColumn: "ID");
        }
    }
}
