using Microsoft.EntityFrameworkCore;
using Spg.Grakiffi.Domain.Model;
using Spg.Grakiffi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Grakiffi.Domain.Test
{
    public class ProductTest
    {
        [Fact]
        public void Add_ProductEntity_SuccessTest()
        {
            // AAA
            // 1. Arrange
            GrakiffiContext db = GenerateDB();
            Product newProduct = new Product("Testprodukt", 12.50M, 20, "9826335364797");

            // 2. Act
            db.Products.Add(newProduct);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Products.Count());
        }

        private GrakiffiContext GenerateDB()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlite("Data Source=Grakiffi_Test.db");

            GrakiffiContext db = new GrakiffiContext(optionsBuilder.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }
    }
}
