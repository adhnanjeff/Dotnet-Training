using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Ecommerce.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
                
                // Unique constraints
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Stock).IsRequired();
                entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
                
                // Foreign key relationship
                entity.HasOne(e => e.Seller)
                    .WithMany(e => e.SoldProducts)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Order configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderDate).IsRequired();
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                
                // Foreign key relationship
                entity.HasOne(e => e.Customer)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // OrderItem configuration
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                
                // Foreign key relationships
                entity.HasOne(e => e.Order)
                    .WithMany(e => e.Items)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(e => e.Customer)
                    .WithMany(e => e.CartItems)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(e => e.Product)
                    .WithMany(e => e.OrderItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Fix: Add using Microsoft.Extensions.Configuration;
            .AddJsonFile(
                Path.Combine("..", "Ecommerce.API", "appsettings.json"),
                optional: false,
                reloadOnChange: true
            )
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = configuration.GetConnectionString("EcommerceDB");
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
