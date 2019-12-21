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
    public class DetailsModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public DetailsModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Kategori Kategori { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kategori = await _context.Kategori.FirstOrDefaultAsync(m => m.ID == id);

            if (Kategori == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
