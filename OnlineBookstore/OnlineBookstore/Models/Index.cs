using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstore.Data;

namespace OnlineBookstore.Models
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

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
    }
}


