using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WerdulUI.Pages.GameUI
{
    public class GameUIModel : PageModel
    {
        public string GuessedWord { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }


            return RedirectToPage();
        }
    }
}
