﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BP.ShoppingTracker.Adapters.Catalogue.ORM.Entities;

namespace BP.ShoppingTracker.Adapters.Catalogue.ORM.Context
{
    public partial class ShoppingTrackerContext : DbContext
    {
        public ShoppingTrackerContext()
        {
        }

        public ShoppingTrackerContext(DbContextOptions<ShoppingTrackerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<CombinedFormat> CombinedFormats { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CostEvolution> CostEvolutions { get; set; } = null!;
        public virtual DbSet<Format> Formats { get; set; } = null!;
        public virtual DbSet<FormatType> FormatTypes { get; set; } = null!;
        public virtual DbSet<MeasureType> MeasureTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=webserver-vbox;Username=postgres;Password=a123.456;Database=ShoppingTracker");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.CompanyFKNavigation)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.CompanyFK)
                    .HasConstraintName("FK_Brand_Company");
            });

            modelBuilder.Entity<CombinedFormat>(entity =>
            {

                entity.ToTable(t => t.HasComment("Permite la posibilidad de que un producto tenga formato derivado: (pack de 6 latas de 300g) => (pack de 6) -> (latas de 300g)"));

                entity.HasKey(e => new { e.MainFormatFK, e.DerivedFormatFK });

                entity.Property(e => e.MainFormatFK).ValueGeneratedNever();
                entity.Property(e => e.DerivedFormatFK).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValue(true);

                entity.HasOne(d => d.DerivedFormatFKNavigation)
                    .WithMany(p => p.CombinedFormatDerivedFormatFKNavigations)
                    .HasForeignKey(d => d.DerivedFormatFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CombinedFormat_Format_Derived");

                entity.HasOne(d => d.MainFormatFKNavigation)
                    .WithMany(p => p.CombinedFormatMainFormatFKNavigations)
                    .HasForeignKey(d => d.MainFormatFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CombinedFormat_Format_Main");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();
            });

            modelBuilder.Entity<CostEvolution>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.SalePrice).HasDefaultValue(false);

                entity.Property(e => e.RateSale).HasComment("En tanto por uno, porcentaje de descuento aplicado dando como resultado el valor de Value");

                entity.HasOne(d => d.ProductFKNavigation)
                    .WithMany(p => p.CostEvolutions)
                    .HasForeignKey(d => d.ProductFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostEvolution_Product");

            });

            modelBuilder.Entity<Format>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValue(true);

                entity.HasOne(d => d.FormatTypeFKNavigation)
                    .WithMany(p => p.Formats)
                    .HasForeignKey(d => d.FormatTypeFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Format_FormatType");

                entity.HasOne(d => d.MeasureTypeFKNavigation)
                    .WithMany(p => p.Formats)
                    .HasForeignKey(d => d.MeasureTypeFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Format_MeasureType");
            });

            modelBuilder.Entity<FormatType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValue(true);
            });

            modelBuilder.Entity<MeasureType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.IsUnitBase).HasDefaultValue(false);

                entity.HasOne(d => d.UnitBaseFKNavigation)
                    .WithMany(p => p.UnitsDerived)
                    .HasForeignKey(d => d.UnitBaseFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasureType_MeasureType");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValue(true);

                entity.HasOne(d => d.BrandFKNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.FormatFKNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => new { d.FormatFK1, d.FormatFK2 })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Format");

                entity.HasOne(d => d.ProductTypeFKNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable(t => t.HasComment("Categoría del tipo de producto: Alimentación, perfumería etc"));

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValue(true);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValue(true);

                entity.HasOne(d => d.ParentFKNavigation)
                    .WithMany(p => p.InverseParentFKNavigation)
                    .HasForeignKey(d => d.ParentFK)
                    .HasConstraintName("FK_ProductType_ProductType");

                entity.HasOne(d => d.ProductCategoryFKNavigation)
                    .WithMany(p => p.ProductTypes)
                    .HasForeignKey(d => d.ProductCategoryFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductType_ProductCategory");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
