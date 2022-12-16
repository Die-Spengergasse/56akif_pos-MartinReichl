using Bogus;
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

        public void Seed()
        {
            Randomizer.Seed = new Random(144412);

            List<Customer> customers = new Faker<Customer>("de").CustomInstantiator(f => 
            new Customer(
                f.Random.Enum<Genders>(), 
                f.Random.Long(111111, 999999),
                f.Name.FirstName(Bogus.DataSets.Name.Gender.Female),
                f.Name.LastName(),
                f.Internet.Email(),
                f.Date.Between(DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-18)),
                f.Date.Between(DateTime.Now.AddYears(-10), DateTime.Now.AddDays(-2))
            ))
            .Rules((f, c) =>
            {
                if (c.Gender == Genders.Male)
                {
                    c.FirstName = f.Name.FirstName(Bogus.DataSets.Name.Gender.Male);
                }

                c.Address = new Address()
                {
                    Street = f.Address.StreetName(),
                    HouseNumber = f.Address.BuildingNumber(),
                    Zip = f.Address.ZipCode(),
                    City = f.Address.City()
                };

                c.TelephoneNumber = f.Phone.PhoneNumber();
            })
            .Generate(30)
            .ToList();

            Customers.AddRange(customers);
            SaveChanges();

            List<ShoppingCart> shoppingCarts = new Faker<ShoppingCart>().CustomInstantiator(f => 
                new ShoppingCart(
                    f.Commerce.ProductName(),
                    ShoppingCartStates.Sent,
                    f.Date.Between(DateTime.Now.AddYears(-10), DateTime.Now.AddYears(-10))
                )
            ).Rules((f, s) => 
            {
                s.CustomerNavigation = f.Random.ListItem(customers);
            })
            .Generate(200)
            .ToList();

            ShoppingCarts.AddRange(shoppingCarts);
            SaveChanges();
        }

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
