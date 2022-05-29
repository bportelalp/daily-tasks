using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.I30.Persistence.Migrations
{
    public partial class backCost2Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostEvolution_Brand",
                table: "CostEvolution");

            migrationBuilder.DropIndex(
                name: "IX_CostEvolution_BrandFK",
                table: "CostEvolution");

            migrationBuilder.AlterColumn<double>(
                name: "RateSale",
                table: "CostEvolution",
                type: "float",
                nullable: true,
                comment: "En tanto por uno, porcentaje de descuento aplicado dando como resultado el valor de Value",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "RateSale",
                table: "CostEvolution",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "En tanto por uno, porcentaje de descuento aplicado dando como resultado el valor de Value");

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
    }
}
