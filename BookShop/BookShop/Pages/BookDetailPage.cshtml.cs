using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookShop.Data;

namespace BookShop.Pages
{
    public class BookDetailPageModel : PageModel
    {
        private readonly BookShopContext _context;

        public BookDetailPageModel(BookShopContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Book = await _context.Books.FindAsync(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

