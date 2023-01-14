using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Identity.ORM.Context;

public partial class ShoppingTrackerIdentityContext : IdentityDbContext
{
    public ShoppingTrackerIdentityContext(DbContextOptions<ShoppingTrackerIdentityContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
