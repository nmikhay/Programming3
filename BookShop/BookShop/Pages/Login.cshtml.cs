using BookShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountViewModel AccountViewModel { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(accountViewModel.Username, accountViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(accountViewModel.Username);
                    var roles = await _userManager.GetRolesAsync(user);
                    var returnUrl = roles.Contains("Admin") ? "/AdminPage" : "/PurchasePage";

                    return LocalRedirect(returnUrl);
                }
            }

            return Page();
        }
    }
}



