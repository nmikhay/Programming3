using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminPageModel : PageModel
    {
        private readonly BookShopContext _context;

        public AdminPageModel(BookShopContext context)
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





