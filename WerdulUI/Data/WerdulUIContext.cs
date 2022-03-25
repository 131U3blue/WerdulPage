#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WerdulUI.Models;

namespace WerdulUI.Data
{
    public class WerdulUIContext : DbContext
    {
        public WerdulUIContext (DbContextOptions<WerdulUIContext> options)
            : base(options)
        {
        }

        public DbSet<WerdulUI.Models.DictionaryEntry> DictionaryEntry { get; set; }
    }
}
