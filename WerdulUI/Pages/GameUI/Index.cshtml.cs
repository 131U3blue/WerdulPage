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
    public class IndexModel : PageModel
    {
        private readonly WerdulUI.Data.WerdulUIContext _context;

        public IndexModel(WerdulUI.Data.WerdulUIContext context)
        {
            _context = context;
        }

        public IList<DictionaryEntry> DictionaryEntry { get;set; }

        public async Task OnGetAsync()
        {
            DictionaryEntry = await _context.DictionaryEntry.ToListAsync();
        }
    }
}
