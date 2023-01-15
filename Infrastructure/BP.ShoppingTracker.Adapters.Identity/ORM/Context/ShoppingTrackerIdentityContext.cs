using System;
using System.Collections.Generic;
using BP.ShoppingTracker.Adapters.Identity.ORM.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Identity.ORM.Context;

public partial class ShoppingTrackerIdentityContext : IdentityDbContext
{
    public ShoppingTrackerIdentityContext(DbContextOptions<ShoppingTrackerIdentityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<UserPersonalDatum> UserPersonalData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("Address_pkey");

            entity.Property(e => e.AddressId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasMany(d => d.AddressFks).WithMany(p => p.UserFks)
                .UsingEntity<Dictionary<string, object>>(
                    "UserAddress",
                    r => r.HasOne<Address>().WithMany()
                        .HasForeignKey("AddressFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserAddress_Address"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserAddress_AspNetUsers"),
                    j =>
                    {
                        j.HasKey("UserFk", "AddressFk").HasName("UserAddress_pkey");
                        j.ToTable("UserAddress", "identity");
                    });

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles", "identity");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<UserPersonalDatum>(entity =>
        {
            entity.HasKey(e => e.UserFk).HasName("UserPersonalData_pkey");

            entity.HasOne(d => d.UserFkNavigation).WithOne(p => p.UserPersonalDatum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPersonalData");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
