using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz.Pages.Admin.Etkinlik
{
    public class DetailsModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public DetailsModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Biletciniz.Models.Etkinlik Etkinlik { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etkinlik = await _context.Etkinlik
                .Include(e => e.Kategori)
                .Include(e => e.Mekan)
                .Include(e => e.Tur).FirstOrDefaultAsync(m => m.ID == id);

            if (Etkinlik == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
