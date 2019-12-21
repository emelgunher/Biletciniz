using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz
{
    public class IndexModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public IndexModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Kategori> Kategori { get;set; }

        public async Task OnGetAsync()
        {
            Kategori = await _context.Kategori.ToListAsync();
        }
    }
}
