#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WerdulUI.Data;
using WerdulUI.Models;

namespace WerdulUI.Pages.GameUI
{
    public class DetailsModel : PageModel
    {
        private readonly WerdulUI.Data.WerdulUIContext _context;

        public DetailsModel(WerdulUI.Data.WerdulUIContext context)
        {
            _context = context;
        }

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
    }
}
