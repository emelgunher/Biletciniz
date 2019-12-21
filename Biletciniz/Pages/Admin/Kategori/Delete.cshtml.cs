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
    public class DeleteModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public DeleteModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kategori = await _context.Kategori.FindAsync(id);

            if (Kategori != null)
            {
                _context.Kategori.Remove(Kategori);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
