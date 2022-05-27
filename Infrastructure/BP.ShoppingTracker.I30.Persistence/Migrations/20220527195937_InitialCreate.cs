using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BP.ShoppingTracker.I30.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormatType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeasureType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ScaleFactorSI = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ID);
                },
                comment: "Categoría del tipo de producto: Alimentación, perfumería etc");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CompanyFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Brand_Company",
                        column: x => x.CompanyFK,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Format",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormatTypeFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeasureTypeFK = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Format", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Format_FormatType",
                        column: x => x.FormatTypeFK,
                        principalTable: "FormatType",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Format_MeasureType",
                        column: x => x.MeasureTypeFK,
                        principalTable: "MeasureType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductCategoryFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductType_ProductCategory",
                        column: x => x.ProductCategoryFK,
                        principalTable: "ProductCategory",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductType_ProductType",
                        column: x => x.ParentFK,
                        principalTable: "ProductType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductTypeFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormatFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BarCode = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Brand",
                        column: x => x.BrandFK,
                        principalTable: "Brand",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Product_Format",
                        column: x => x.ProductTypeFK,
                        principalTable: "Format",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Product_ProductType",
                        column: x => x.ProductTypeFK,
                        principalTable: "ProductType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CostEvolution",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisteredOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<bool>(type: "bit", nullable: false),
                    RateSale = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostEvolution", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CostEvolution_Product",
                        column: x => x.ProductFK,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_CompanyFK",
                table: "Brand",
                column: "CompanyFK");

            migrationBuilder.CreateIndex(
                name: "IX_CostEvolution_ProductFK",
                table: "CostEvolution",
                column: "ProductFK");

            migrationBuilder.CreateIndex(
                name: "IX_Format_FormatTypeFK",
                table: "Format",
                column: "FormatTypeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Format_MeasureTypeFK",
                table: "Format",
                column: "MeasureTypeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandFK",
                table: "Product",
                column: "BrandFK");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeFK",
                table: "Product",
                column: "ProductTypeFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ParentFK",
                table: "ProductType",
                column: "ParentFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductCategoryFK",
                table: "ProductType",
                column: "ProductCategoryFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostEvolution");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Format");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "FormatType");

            migrationBuilder.DropTable(
                name: "MeasureType");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
