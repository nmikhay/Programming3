using BookShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookShop.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountViewModel AccountViewModel { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = accountViewModel.Username };
                var result = await _userManager.CreateAsync(user, accountViewModel.Password);

                if (result.Succeeded)
                {
                    // Assign the user to the specified role
                    await _userManager.AddToRoleAsync(user, accountViewModel.Role);

                    // Automatically sign in the user
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var returnUrl = accountViewModel.Role == "Admin" ? "/AdminPage" : "/PurchasePage";

                    return LocalRedirect(returnUrl);
                }
            }

            return Page();
        }
    }
}


