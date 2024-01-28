using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace YourProjectName.Pages
{
    public class AddBookModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "The Author field is required.")]
        public string Author { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "The Publication Year field is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Please enter a valid year.")]
        public string PublicationYear { get; set; }

        [BindProperty]
        public string Summary { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["Message"] = "Book entry has been successfully added!";

            return RedirectToPage("Index");
        }
    }
}



