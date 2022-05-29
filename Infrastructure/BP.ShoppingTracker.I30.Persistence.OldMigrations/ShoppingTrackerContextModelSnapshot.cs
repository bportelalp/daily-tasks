﻿// <auto-generated />
using System;
using BP.ShoppingTracker.I30.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BP.ShoppingTracker.I30.Persistence.Migrations
{
    [DbContext(typeof(ShoppingTrackerContext))]
    partial class ShoppingTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Brand", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "CompanyFK" }, "IX_Brand_CompanyFK");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.CombinedFormat", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.Property<Guid>("DerivedFormatFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MainFormatFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "DerivedFormatFK" }, "IX_Format_Format_DerivedFormatFK");

                    b.HasIndex(new[] { "MainFormatFK" }, "IX_Format_Format_MainFormatFK");

                    b.ToTable("CombinedFormat");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Company", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.CostEvolution", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("RateSale")
                        .HasColumnType("float");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("SalePrice")
                        .HasColumnType("bit");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "ProductFK" }, "IX_CostEvolution_ProductFK");

                    b.ToTable("CostEvolution");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Format", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<Guid>("FormatTypeFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MeasureTypeFK")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "FormatTypeFK" }, "IX_Format_FormatTypeFK");

                    b.HasIndex(new[] { "MeasureTypeFK" }, "IX_Format_MeasureTypeFK");

                    b.ToTable("Format");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.FormatType", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.ToTable("FormatType");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.MeasureType", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ScaleFactorSI")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("MeasureType");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("BarCode")
                        .HasColumnType("int");

                    b.Property<Guid>("BrandFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("FormatFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("ProductTypeFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "BrandFK" }, "IX_Product_BrandFK");

                    b.HasIndex(new[] { "FormatFK" }, "IX_Product_FormatFK");

                    b.HasIndex(new[] { "ProductTypeFK" }, "IX_Product_ProductTypeFK");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.ToTable("ProductCategory");

                    b.HasComment("Categoría del tipo de producto: Alimentación, perfumería etc");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.ProductType", b =>
                {
                    b.Property<Guid>("ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid?>("ParentFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductCategoryFK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "ParentFK" }, "IX_ProductType_ParentFK");

                    b.HasIndex(new[] { "ProductCategoryFK" }, "IX_ProductType_ProductCategoryFK");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Brand", b =>
                {
                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.Company", "CompanyFKNavigation")
                        .WithMany("Brands")
                        .HasForeignKey("CompanyFK")
                        .HasConstraintName("FK_Brand_Company");

                    b.Navigation("CompanyFKNavigation");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.CombinedFormat", b =>
                {
                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.Format", "DerivedFormatFKNavigation")
                        .WithMany("CombinedFormatDerivedFormatFKNavigations")
                        .HasForeignKey("DerivedFormatFK")
                        .IsRequired()
                        .HasConstraintName("FK_CombinedFormat_Format_Derived");

                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.Format", "MainFormatFKNavigation")
                        .WithMany("CombinedFormatMainFormatFKNavigations")
                        .HasForeignKey("MainFormatFK")
                        .IsRequired()
                        .HasConstraintName("FK_CombinedFormat_Format_Main");

                    b.Navigation("DerivedFormatFKNavigation");

                    b.Navigation("MainFormatFKNavigation");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.CostEvolution", b =>
                {
                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.Product", "ProductFKNavigation")
                        .WithMany("CostEvolutions")
                        .HasForeignKey("ProductFK")
                        .IsRequired()
                        .HasConstraintName("FK_CostEvolution_Product");

                    b.Navigation("ProductFKNavigation");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Format", b =>
                {
                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.FormatType", "FormatTypeFKNavigation")
                        .WithMany("Formats")
                        .HasForeignKey("FormatTypeFK")
                        .IsRequired()
                        .HasConstraintName("FK_Format_FormatType");

                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.MeasureType", "MeasureTypeFKNavigation")
                        .WithMany("Formats")
                        .HasForeignKey("MeasureTypeFK")
                        .IsRequired()
                        .HasConstraintName("FK_Format_MeasureType");

                    b.Navigation("FormatTypeFKNavigation");

                    b.Navigation("MeasureTypeFKNavigation");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Product", b =>
                {
                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.Brand", "BrandFKNavigation")
                        .WithMany("Products")
                        .HasForeignKey("BrandFK")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Brand");

                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.CombinedFormat", "FormatFKNavigation")
                        .WithMany("Products")
                        .HasForeignKey("FormatFK")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Format");

                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.ProductType", "ProductTypeFKNavigation")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeFK")
                        .IsRequired()
                        .HasConstraintName("FK_Product_ProductType");

                    b.Navigation("BrandFKNavigation");

                    b.Navigation("FormatFKNavigation");

                    b.Navigation("ProductTypeFKNavigation");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.ProductType", b =>
                {
                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.ProductType", "ParentFKNavigation")
                        .WithMany("InverseParentFKNavigation")
                        .HasForeignKey("ParentFK")
                        .HasConstraintName("FK_ProductType_ProductType");

                    b.HasOne("BP.ShoppingTracker.I30.Persistence.Entities.ProductCategory", "ProductCategoryFKNavigation")
                        .WithMany("ProductTypes")
                        .HasForeignKey("ProductCategoryFK")
                        .IsRequired()
                        .HasConstraintName("FK_ProductType_ProductCategory");

                    b.Navigation("ParentFKNavigation");

                    b.Navigation("ProductCategoryFKNavigation");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.CombinedFormat", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Company", b =>
                {
                    b.Navigation("Brands");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Format", b =>
                {
                    b.Navigation("CombinedFormatDerivedFormatFKNavigations");

                    b.Navigation("CombinedFormatMainFormatFKNavigations");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.FormatType", b =>
                {
                    b.Navigation("Formats");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.MeasureType", b =>
                {
                    b.Navigation("Formats");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.Product", b =>
                {
                    b.Navigation("CostEvolutions");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.ProductCategory", b =>
                {
                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("BP.ShoppingTracker.I30.Persistence.Entities.ProductType", b =>
                {
                    b.Navigation("InverseParentFKNavigation");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
