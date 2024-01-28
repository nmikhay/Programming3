using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BookShop.Data;

namespace BookShop.Pages
{
    [Authorize(Roles = "Customer")]
    public class PurchaseModel : PageModel
    {
        private readonly BookShopContext _context;

        public PurchaseModel(BookShopContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await _context.Books.FindAsync(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var purchase = new Purchase
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                BookId = book.Id
            };

            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}




