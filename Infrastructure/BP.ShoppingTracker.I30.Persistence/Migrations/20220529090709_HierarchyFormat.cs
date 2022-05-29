using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.I30.Persistence.Migrations
{
    public partial class HierarchyFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentFK",
                table: "Format",
                type: "uniqueidentifier",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Format_Format",
                table: "Format");

            migrationBuilder.DropIndex(
                name: "IX_Format_ParentFK",
                table: "Format");

            migrationBuilder.DropColumn(
                name: "ParentFK",
                table: "Format");
        }
    }
}
