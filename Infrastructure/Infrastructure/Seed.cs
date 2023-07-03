using Infrastructure.Encryption;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder builder)
        {
            HashingPassword hash = new HashingPassword();
            //Add roles for users
            builder.Entity<UserRole>().HasData(
                new UserRole { Name = "admin",UserroleId = 1},
                new UserRole { Name ="admin",UserroleId = 2},
                new UserRole { Name ="customer",UserroleId = 3}
                );
            //Add categories
            builder.Entity<Category>().HasData(
                new Category { Name = "Shoes", CategoryId = 1 },
                new Category { Name = "Pants", CategoryId = 2 },
                new Category { Name = "Hats", CategoryId = 3 });

            //Add Users
            builder.Entity<User>().HasData(
               new User
               {
                   Name = "HamedSh",
                   CreationTime = DateTime.Now
               ,
                   Address = "Tehran",
                   Email = "nt924@gmail.com"
               ,
                   Password = hash.HashPassword("13801380"),
                   SaltText = hash.Salt
               ,
                   phonenumber = "09104578701",
                   UserRoleId = 1
               ,
                   UserId = 1
               },
               new User
               {
                   Name = "Hanna",
                   CreationTime = DateTime.Now
                   ,
                   Address = "Tehran",
                   Email = "hannahGh@gmail.com"
                   ,
                   Password = hash.HashPassword("13811381"),
                   SaltText = hash.Salt
                   ,
                   phonenumber = "09341837814",
                   UserRoleId = 2
                   ,
                   UserId = 2
               },
               new User
               {
                   Name = "Ahmad",
                   CreationTime = DateTime.Now
                   ,
                   Address = "Tabriz",
                   Email = "ahmadbn@gmail.com"
                   ,
                   Password = hash.HashPassword("13781378"),
                   SaltText = hash.Salt
                   ,
                   phonenumber = "091876245612",
                   UserRoleId = 3
                   ,
                   UserId = 3
               });
            //Add Products
            builder.Entity<Product>().HasData(
                new Product
                {
                    Name = "Nike",
                    WarehouseCode = 1,
                    CategoryId = 1,
                    CreationTime = DateTime.Now,
                    Count = 2,
                    CreatorId = 1,
                    CommentEnabled = true,
                    Price = 232000,
                    ProductId = 1,
                    Attributes = new Dictionary<string, string>() { { "color", "red" }, { "size", "37" } }
                },
                new Product
                {
                    Name = "Fateh",
                    WarehouseCode = 2,
                    CategoryId = 2,
                    CreationTime = DateTime.Now,
                    Count = 3,
                    CreatorId = 2,
                    CommentEnabled = true,
                    Price = 456000,
                    ProductId = 2,
                    Attributes = new Dictionary<string, string>() { { "color", "blue" }, { "size", "33" } }
                });
        }
    }
}
