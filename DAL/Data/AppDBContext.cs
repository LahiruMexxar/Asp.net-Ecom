using DAL.Models;
using DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderBrief>()
                .HasMany(e => e.OrderDetails)
                .WithOne(e => e.OrderBrief)
                .HasForeignKey(e => e.OrderBriefId);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.Product)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<ShoppingCart>()
                .HasMany(e => e.CartItems)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey(e => e.ShoppingCartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(e => e.Product)
                .WithMany(e => e.CartItems)
                .HasForeignKey(e => e.ProductId);
        }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderBrief> OrderBriefs { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    }
}
