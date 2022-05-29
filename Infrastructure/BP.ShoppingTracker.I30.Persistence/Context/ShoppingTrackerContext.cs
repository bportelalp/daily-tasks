using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BP.ShoppingTracker.I30.Persistence.Entities;

namespace BP.ShoppingTracker.I30.Persistence.Context
{
    public partial class ShoppingTrackerContext : DbContext
    {
        public ShoppingTrackerContext()
        {
        }

        public ShoppingTrackerContext(DbContextOptions<ShoppingTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
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
                optionsBuilder.UseSqlServer("Data Source=webserver-vbox;Initial Catalog=ShoppingTracker;Persist Security Info=True;User ID=sa;Password=a123.456");
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

            modelBuilder.Entity<CostEvolution>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.ProductFKNavigation)
                    .WithMany(p => p.CostEvolutions)
                    .HasForeignKey(d => d.ProductFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostEvolution_Product");
            });

            modelBuilder.Entity<Format>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

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

                entity.HasOne(d => d.ParentFKNavigation)
                    .WithMany(p => p.InverseParentFKNavigation)
                    .HasForeignKey(d => d.ParentFK)
                    .HasConstraintName("FK_Format_Format");
            });

            modelBuilder.Entity<FormatType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<MeasureType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();
                entity.Property(e => e.Unit);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.BrandFKNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.ProductTypeFKNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Format");

                entity.HasOne(d => d.ProductTypeFK1)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeFK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasComment("Categoría del tipo de producto: Alimentación, perfumería etc");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

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
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
