using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ShoppingItem> ShoppingItem { get; set; }

        public DbSet<TodoStatus> TodoStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Rose",
                LastName = "Wiz",
                UserName = "r@r.com",
                NormalizedUserName = "R@R.COM",
                Email = "r@r.com",
                NormalizedEmail = "R@R.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            //Create shopping items 
            ShoppingItem item = new ShoppingItem
            {
                Id = 1,
                ProductName = "Can of Spam",
                ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            modelBuilder.Entity<ShoppingItem>().HasData(item);

            modelBuilder.Entity<ShoppingItem>().HasData(
                new ShoppingItem()
                {
                    Id = 2,
                    ProductName = "Rice",
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                },
                new ShoppingItem()
                {
                    Id = 3,
                    ProductName = "Eggs",
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                },
                 new ShoppingItem()
                 {
                     Id = 4,
                     ProductName = "Mask",
                     ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                 });


                   //Create shopping items 
            TodoStatus status = new TodoStatus
            {
                Id = 1,
                Title = "Todo"
            };
            modelBuilder.Entity<TodoStatus>().HasData(status);

            modelBuilder.Entity<TodoStatus>().HasData(
                new TodoStatus()
                {
                    Id = 2,
                    Title = "In Progress"
  
                },
                new TodoStatus()
                {
                    Id = 3,
                    Title = "Done"

                }
                 );
        }
        public DbSet<ShoppingCart.Models.TodoItem> TodoItem { get; set; }
    }
}
