using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;
using BookShop.Data;

namespace BookShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookShopContext _context;

        public IndexModel(BookShopContext context)
        {
            _context = context;
        }

        public List<Book> Books { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Books = await _context.Books.ToListAsync();
            return Page();
        }
    }
}
