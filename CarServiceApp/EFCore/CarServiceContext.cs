using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.EFCore
{
    internal class CarServiceContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Deal> Deals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VIsualStudio\repos\CarServiceApp\CarServiceApp\CarService.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Deal>().HasKey(e => new { e.CarId, e.ClientId });
            // modelBuilder.Entity<Client>().HasKey(e => new { e.AddressId});
        }
    }
}
