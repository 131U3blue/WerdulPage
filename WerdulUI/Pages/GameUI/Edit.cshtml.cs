#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WerdulUI.Data;
using WerdulUI.Models;

namespace WerdulUI.Pages.GameUI
{
    public class EditModel : PageModel
    {
        private readonly WerdulUI.Data.WerdulUIContext _context;

        public EditModel(WerdulUI.Data.WerdulUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DictionaryEntry DictionaryEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DictionaryEntry = await _context.DictionaryEntry.FirstOrDefaultAsync(m => m.Id == id);

            if (DictionaryEntry == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DictionaryEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictionaryEntryExists(DictionaryEntry.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DictionaryEntryExists(int id)
        {
            return _context.DictionaryEntry.Any(e => e.Id == id);
        }
    }
}
