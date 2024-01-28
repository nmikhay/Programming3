using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Data
{
    public class BookShopContext : IdentityDbContext<IdentityUser>
    {
        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}



