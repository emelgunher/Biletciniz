using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz.Pages.Admin.Mekan
{
    public class DetailsModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public DetailsModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Biletciniz.Models.Mekan Mekan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mekan = await _context.Mekan
                .Include(m => m.Ilce)
                .Include(m => m.Sehir).FirstOrDefaultAsync(m => m.ID == id);

            if (Mekan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
