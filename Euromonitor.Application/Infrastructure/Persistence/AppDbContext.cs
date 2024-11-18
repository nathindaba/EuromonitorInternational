namespace Euromonitor.Application.Infrastructure.Persistence;

using Euromonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure User Entity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.HasMany(u => u.Subscriptions)
                  .WithMany()
                  .UsingEntity<Dictionary<string, object>>(
                      "UserBooks",
                      j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                      j => j.HasOne<User>().WithMany().HasForeignKey("UserId"));
        });

        // Configure Book Entity
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Name).IsRequired().HasMaxLength(100);
            entity.Property(b => b.PurchasePrice).IsRequired();
        });
    }
}