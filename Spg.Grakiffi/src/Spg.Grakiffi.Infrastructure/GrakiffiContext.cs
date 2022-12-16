using Microsoft.EntityFrameworkCore;
using Spg.Grakiffi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Infrastructure
{
    public class GrakiffiContext : DbContext
    {
        // DB-Tabellen als Props
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<ShoppingCartItem> ShoppingCartItems => Set<ShoppingCartItem>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();

        public GrakiffiContext()
        { }
        
        public GrakiffiContext(DbContextOptions options) : base(options)
        { }

        // Konfiguration vor DB Erstellung
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlite("Data Source = Grakiffi.db");
            //}
        }

        // Optionen während DB Erstellung
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ändert Tabellenname in DB von Products (Prop Name) auf Produkte
            //modelBuilder.Entity<Product>().ToTable("Produkte");

            // Weil PK keine ID, sondern string Name
            modelBuilder.Entity<Product>().HasKey(p => p.Name);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Category>().HasKey(p => p.Name);
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<SubCategory>().HasKey(p => p.Name);
            modelBuilder.Entity<SubCategory>().Property(p => p.Name).IsRequired();

            // Nice, aber unnötig ("Convention over Configuration")
            //modelBuilder.Entity<Customer>().HasMany(p => p.ShoppingCarts);

            // Value Object
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
        }
    }
}
