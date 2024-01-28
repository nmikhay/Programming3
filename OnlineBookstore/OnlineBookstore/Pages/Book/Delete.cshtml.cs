using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstore.Data;
using OnlineBookstore.Models;

namespace OnlineBookstore.Pages.Book
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookPage Book { get; set; }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                NotFound();
                return;
            }

            Book = _context.Books.Find(id);

            if (Book == null)
            {
                NotFound();
                return;
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FindAsync(id);

            if (Book != null)
            {
                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}


