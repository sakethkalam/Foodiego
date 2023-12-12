using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodiego.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodiego.Data.Migrations
{
    public class FoodiegoDbContext:DbContext
    {
        public FoodiegoDbContext(DbContextOptions<FoodiegoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Menu> Menus {get; set;}
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Restaurents> Restaurents { get; set; }
        public DbSet<Reviews> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships between entities
        // ...

        // Configure data annotations for validation
        // ...
    }
    }
}