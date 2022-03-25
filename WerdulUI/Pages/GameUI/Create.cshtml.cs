#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WerdulUI.Data;
using WerdulUI.Models;

namespace WerdulUI.Pages.GameUI
{
    public class CreateModel : PageModel
    {
        private readonly WerdulUI.Data.WerdulUIContext _context;

        public CreateModel(WerdulUI.Data.WerdulUIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DictionaryEntry DictionaryEntry { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DictionaryEntry.Add(DictionaryEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
