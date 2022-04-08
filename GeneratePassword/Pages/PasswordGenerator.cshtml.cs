using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneratePassword.Helpers;
using GeneratePassword.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeneratePassword.Pages
{
    public class PasswordGeneratorModel : PageModel
    {
       
        [BindProperty(SupportsGet = true)]
        public PasswordGenModel Generator { get; set; }
       
        public void OnGet()
        {
            Generator.MaxLength = 10;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {

                return Page();
            }

            Generator.GeneratedPassword = GeneratorHelper.GeneratePassword(Generator.MaxLength, Generator.UseCaps, Generator.UseSymb, Generator.UseNumbers);
            Generator.IsStrong = GeneratorHelper.StrengthOfPassword(Generator.GeneratedPassword);

            return Page();
        }
    }
}
