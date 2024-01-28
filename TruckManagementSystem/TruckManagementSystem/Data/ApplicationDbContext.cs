using Microsoft.EntityFrameworkCore;
using TruckManagementSystem.Models;

namespace TruckManagementSystem.Data
{
  
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Driver> Drivers { get; set; }
            public DbSet<Dispatcher> Dispatchers { get; set; }
            public DbSet<Admin> Admins { get; set; }
            public DbSet<Load> Loads { get; set; }
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=truck_application;Trusted_Connection=True;");
            }
        }
    }

