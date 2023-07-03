using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MainContext : DbContext
    {
        public MainContext() : base()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("server=LAPTOP-OE4K3RIH;database=Website;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.SeedData();
            
            var options = new JsonSerializerOptions(JsonSerializerDefaults.General);
            builder.Entity<Product>().Property(v => v.Attributes).HasConversion(v => JsonSerializer.Serialize(v, options),
                                                                            s => JsonSerializer.Deserialize<Dictionary<string, string>>(s, options)!,
                                                                            ValueComparer.CreateDefault(typeof(Dictionary<string, string>), true));
            //Each user is able to write many comments
            builder.Entity<User>()
                    .HasMany(v => v.Comments)
                    .WithOne(b => b.User)
                    .HasForeignKey(z => z.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            //Administrators is authorized to add products
            builder.Entity<User>()
                    .HasMany(v => v.Products)
                    .WithOne(c => c.User)
                    .HasForeignKey(z => z.CreatorId)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            //Each role(like admin) has many Users
            builder.Entity<UserRole>()
                    .HasMany(v => v.Users)
                    .WithOne(b => b.UserRole)
                    .HasForeignKey(n => n.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            //Each user could have many orders
            builder.Entity<User>()
                    .HasMany(v => v.Orders)
                    .WithOne(b => b.User)
                    .HasForeignKey(z => z.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            //Each user could have many products in her/his shopping carts
            builder.Entity<User>()
                    .HasMany(v => v.ShoppingCarts)
                    .WithOne(b => b.User)
                    .HasForeignKey(z => z.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Product>()
                    .HasMany(v => v.OrderProducts)
                    .WithOne(b => b.Product)
                    .HasForeignKey(z => z.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Product>()
                    .HasMany(v => v.ShoppingCarts)
                    .WithOne(b => b.Product)
                    .HasForeignKey(z => z.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Product>()
                    .HasMany(v => v.Comments)
                    .WithOne(c => c.Product)
                    .HasForeignKey(b => b.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>()
                    .HasMany(v => v.Products)
                    .WithOne(c => c.Category)
                    .HasForeignKey(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<ShoppingCart>().HasKey(ck => new { ck.ProductId, ck.UserId });
            builder.Entity<Comment>().HasKey(ck => new { ck.ProductId, ck.UserId });
            builder.Entity<OrderProduct>().HasKey(ck => new { ck.OrderId, ck.ProductId });
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
