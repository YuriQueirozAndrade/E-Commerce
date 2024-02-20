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
        .HasMany(u => u.Orders)
        .WithOne(a => a.User)
        .HasForeignKey(a => a.UserId);


    modelBuilder.Entity<Address>()
        .HasKey(a => a.Id);

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


      modelBuilder.Entity<Order>()
        .HasKey(o => o.Id);

      modelBuilder.Entity<Order>()
        .Property(o => o.Status)
        .IsRequired();

      modelBuilder.Entity<Order>()
        .Property(o => o.TotalAmount)
        .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<Order>()
        .HasOne(o => o.User)
        .WithMany()
        .HasForeignKey(o => o.UserId)
        .IsRequired();

      modelBuilder.Entity<Order>()
        .HasOne(o => o.Payment)
        .WithOne()
        .HasForeignKey<Order>(o => o.IdPayment)
        .IsRequired();

      modelBuilder.Entity<Order>()
        .HasOne(o => o.Shipping)
        .WithOne()
        .HasForeignKey<Order>(o => o.IdShipping)
        .IsRequired();

      modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderItems)
        .WithOne(i => i.Order)
        .IsRequired();


    modelBuilder.Entity<OrderItem>()
        .HasKey(oi => oi.Id);

    modelBuilder.Entity<OrderItem>()
        .Property(oi => oi.Quantity)
        .IsRequired();

    modelBuilder.Entity<OrderItem>()
        .Property(oi => oi.Price)
        .HasColumnType("decimal(18,2)")
        .IsRequired();

    modelBuilder.Entity<OrderItem>()
        .HasOne(oi => oi.Order)
        .WithMany(o => o.OrderItems)
        .HasForeignKey(oi => oi.OrderId)
        .IsRequired();

    modelBuilder.Entity<OrderItem>()
        .HasOne(oi => oi.Product)
        .WithMany()
        .HasForeignKey(oi => oi.ProductId)
        .IsRequired();
    }
  }
}
