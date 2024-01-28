using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookShop.Models;
using System.Threading.Tasks;
using BookShop.Data;

namespace BookShop.Pages.AddBook
{
    public class IndexModel : PageModel
    {
        private readonly BookShopContext _context;

        public IndexModel(BookShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

