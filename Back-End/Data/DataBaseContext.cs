using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Back_End.Models;
using Back_End.Models.BaseModels;

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
      base.OnModelCreating(modelBuilder);

      const string decimalPrice = "decimal(18,2)";
      modelBuilder.Entity<Base>().UseTpcMappingStrategy();
      modelBuilder.Entity<Address>().ToTable("Addresses");
      modelBuilder.Entity<Order>().ToTable("Orders");
      modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
      modelBuilder.Entity<Shipping>().ToTable("Shippings");
      modelBuilder.Entity<Payment>().ToTable("Payments");
      modelBuilder.Entity<Product>().ToTable("Products");


      modelBuilder.Entity<Base>()
        .Property(e => e.Id)
        .ValueGeneratedOnAdd()
        .IsRequired();

      modelBuilder.Entity<Base>()
        .Property(e => e.Deleted)
        .HasDefaultValue(false)
        .IsRequired();

      modelBuilder.Entity<Base>()
        .Property(e => e.DeletedAt)
        .IsRequired(false);


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
        .Property(o => o.Status)
        .IsRequired();

      modelBuilder.Entity<Order>()
        .Property(o => o.TotalAmount)
        .HasColumnType(decimalPrice);


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
        .Property(oi => oi.Quantity)
        .IsRequired();

      modelBuilder.Entity<OrderItem>()
        .Property(oi => oi.Price)
        .HasColumnType(decimalPrice)
        .IsRequired();

      modelBuilder.Entity<OrderItem>()
        .HasOne(oi => oi.Order)
        .WithMany(o => o.OrderItems)
        .HasForeignKey(oi => oi.OrderId)
        .IsRequired();

      modelBuilder.Entity<OrderItem>()
        .HasOne(oi => oi.Product)
        .WithMany()
        .HasForeignKey(oi => oi.ProductId);


      modelBuilder.Entity<Shipping>()
        .Property(s => s.Service)
        .HasMaxLength(25);

      modelBuilder.Entity<Shipping>()
        .Property(s => s.Cost)
        .HasColumnType(decimalPrice)
        .IsRequired();

      modelBuilder.Entity<Shipping>()
        .Property(s => s.TrackingNumber)
        .HasMaxLength(50);

      modelBuilder.Entity<Shipping>()
        .Property(s => s.ShippedDate);

      modelBuilder.Entity<Shipping>()
        .HasOne(s => s.Order)
        .WithOne(o => o.Shipping)
        .HasForeignKey<Shipping>(s => s.OrderId)
        .IsRequired();
      

      modelBuilder.Entity<Payment>()
        .Property(p => p.PaymentMethod)
        .IsRequired()
        .HasMaxLength(50);

      modelBuilder.Entity<Payment>()
        .Property(p => p.TransactionId)
        .HasMaxLength(100);

      modelBuilder.Entity<Payment>()
        .Property(p => p.Amount)
        .HasColumnType(decimalPrice)
        .IsRequired();

      modelBuilder.Entity<Payment>()
        .Property(p => p.Status)
        .IsRequired()
        .HasMaxLength(50);

      modelBuilder.Entity<Payment>()
        .HasOne(p => p.Order)
        .WithOne(o => o.Payment)
        .HasForeignKey<Payment>(p => p.OrderId)
        .IsRequired();


      modelBuilder.Entity<Product>()
        .Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(100);

      modelBuilder.Entity<Product>()
        .Property(p => p.Description)
        .HasMaxLength(500);

      modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,2)")
        .IsRequired();

      modelBuilder.Entity<Product>()
        .HasMany(p => p.OrderItems)
        .WithOne(oi => oi.Product)
        .HasForeignKey(oi => oi.ProductId);
    }
  }
}
