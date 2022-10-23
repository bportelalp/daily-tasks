using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.Persistence.Migrations
{
    public partial class Cost2Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentFK",
                table: "Format");

            migrationBuilder.AlterColumn<bool>(
                name: "SalePrice",
                table: "CostEvolution",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredOn",
                table: "CostEvolution",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandFK",
                table: "CostEvolution",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CostEvolution_BrandFK",
                table: "CostEvolution",
                column: "BrandFK");

            migrationBuilder.AddForeignKey(
                name: "FK_CostEvolution_Brand",
                table: "CostEvolution",
                column: "BrandFK",
                principalTable: "Brand",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostEvolution_Brand",
                table: "CostEvolution");

            migrationBuilder.DropIndex(
                name: "IX_CostEvolution_BrandFK",
                table: "CostEvolution");

            migrationBuilder.DropColumn(
                name: "BrandFK",
                table: "CostEvolution");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentFK",
                table: "Format",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SalePrice",
                table: "CostEvolution",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredOn",
                table: "CostEvolution",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
