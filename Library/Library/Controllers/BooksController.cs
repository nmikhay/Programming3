using Microsoft.EntityFrameworkCore;
using System.Linq;
using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Author)
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookDetailsViewModel
            {
                BookId = book.Id,
                BookTitle = book.Title,
                GenreName = book.Genre.Name,
                AuthorName = book.Author.Name
            };

            return View(viewModel);
        }
    }

}
