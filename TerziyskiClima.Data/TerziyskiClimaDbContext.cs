using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TerziyskiClima.Data.Models;

namespace TerziyskiClima.Data
{
    public class TerziyskiClimaDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }

        public TerziyskiClimaDbContext()
        {

        }

        public TerziyskiClimaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M84NR9F;Database=TerziskyClima;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
