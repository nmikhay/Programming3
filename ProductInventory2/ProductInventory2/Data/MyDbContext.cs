using Microsoft.EntityFrameworkCore;
using ProductInventory2.Models;
using System.Collections.Generic;

namespace ProductInventory2.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
