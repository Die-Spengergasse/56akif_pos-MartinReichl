using Microsoft.EntityFrameworkCore;
using Spg.Grakiffi.Domain.Model;
using Spg.Grakiffi.Infrastructure;

DbContextOptionsBuilder optionsBuilder= new DbContextOptionsBuilder();
optionsBuilder.UseSqlite("Data Source=Grakiffi_Test.db");

GrakiffiContext db = new GrakiffiContext(optionsBuilder.Options);

// Alle Customer, deren Vorname mit 'M' beginnt
List<Customer> result01 = db.Customers.Where(c => c.FirstName.StartsWith("M")).ToList();

// Customer mit ID 12
var result02 = db.Customers.SingleOrDefault(c => c.Id == 12);

// Anzahl an Customer, deren EMail nicht leer ist
var result03 = db.Customers.Count(c => c.EMail != string.Empty);

// Customer, dessen Vorname mit 'S' beginnt und der nach 01.01.2000 geboren wurde
var result04 = db.Customers.Where(c => c.FirstName.StartsWith("S") && c.BirthDate > new DateTime(2000, 01, 01));

// Gibt es weibliche Customer
var result05 = db.Customers.Any(c => c.Gender == Genders.Female);

// Liefere alle Customer, die ein ShoppingCart mit 10 Items haben (ItemsCount nicht befüllt)
var result06 = db.Customers.Any(c => c.ShoppingCarts.Any(s => s.ItemsCount == 10));

Console.ReadLine();