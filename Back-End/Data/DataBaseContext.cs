using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Back_End.Models;

namespace Back_End.Data
{
  public class DataBaseContext : IdentityDbContext<User>
  {
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
    : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
        .Property(u => u.FirstName)
        .IsRequired()
        .HasMaxLength(30);

      modelBuilder.Entity<User>()
        .Property(u => u.LastName)
        .IsRequired()
        .HasMaxLength(35);

      modelBuilder.Entity<User>()
        .HasMany(u => u.Addresses)
        .WithOne(a => a.User)
        .HasForeignKey(a => a.UserId);

      modelBuilder.Entity<User>()
        .HasMany(u => u.Order)
        .WithOne(a => a.User)
        .HasForeignKey(a => a.UserId);

      modelBuilder.Entity<Address>()
        .Property(u => u.City )
        .IsRequired()
        .HasMaxLength(40);

      modelBuilder.Entity<Address>()
        .Property(u => u.State)
        .IsRequired()
        .HasMaxLength(40);

      modelBuilder.Entity<Address>()
        .Property(u => u.ZipCode)
        .IsRequired()
        .HasMaxLength(10);

      modelBuilder.Entity<Address>()
        .Property(u => u.Country)
        .IsRequired()
        .HasMaxLength(50);
    }
  }
}
