using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cloud_proj.ModelClass;
using Microsoft.AspNetCore.Identity;

namespace Cloud_proj.Pages
{
    public class loginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login logmodel { get; set; }

        public loginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
               var identityResult = await signInManager.PasswordSignInAsync(logmodel.userEmail, logmodel.userPassword, logmodel.rememberMe, false);

                if(identityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("MyPhotos");
                    }

                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }

                ModelState.AddModelError("", "Username or Password is incorrect");
            }
            return Page();
        }
        
    }
}
