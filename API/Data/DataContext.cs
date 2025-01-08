using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser>? Users {get; set;}

    public DbSet<Instruments>? Instruments {get; set;}
    public DbSet<Portfolio>? Portfolios { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    //     {
    //         base.OnModelCreating(modelBuilder);

    //         modelBuilder.Entity<Portfolio>()
    //             .HasOne(p => p.AppUser)
    //             .WithMany(u => u.Portfolios)
    //             .HasForeignKey(p => p.AppUserId);

    //         modelBuilder.Entity<Portfolio>()
    //             .HasMany(p => p.Instrument)
    //             .WithMany();
    //     }
}
