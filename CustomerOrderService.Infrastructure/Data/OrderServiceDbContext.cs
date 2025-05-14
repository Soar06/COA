using CustomerOrderService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderService.Infrastructure.Data
{
    public class OrderServiceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }

        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasIndex(e => e.Email)
                      .IsUnique()
                      .HasDatabaseName("IX_User_Email");
            });

         
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.Price).HasPrecision(10, 2);
                entity.HasIndex(e => e.Name).HasDatabaseName("IX_Product_Name");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.CartId);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Quantity).IsRequired();
                entity.HasIndex(e => new { e.UserId, e.ProductId })
                      .IsUnique()
                      .HasDatabaseName("IX_Cart_UserId_ProductId");
                entity.HasCheckConstraint("CK_Cart_Quantity", "Quantity > 0");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId);
                entity.HasIndex(e => e.AddressLine)
                      .HasDatabaseName("IX_Address_AddressLine");
            });

           
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.TotalAmount).HasPrecision(10, 2);
                entity.Property(e => e.Status).HasDefaultValue("Pending");
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ShippingAddress)
                      .WithMany()
                      .HasForeignKey(e => e.ShippingAddressId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => e.UserId).HasDatabaseName("IX_Order_UserId");
                entity.HasIndex(e => e.CustomerEmail).HasDatabaseName("IX_Order_CustomerEmail");
            });

           
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);
                entity.HasOne(e => e.Order)
                      .WithMany(e => e.OrderItems)
                      .HasForeignKey(e => e.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.UnitPrice).HasPrecision(10, 2);
                entity.Property(e => e.Quantity).IsRequired();
                entity.HasCheckConstraint("CK_OrderItem_Quantity", "Quantity > 0");
            });
        }
    }
}