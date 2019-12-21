using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz.Pages.Admin.Sanatci
{
    public class DetailsModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public DetailsModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Biletciniz.Models.Sanatci Sanatci { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sanatci = await _context.Sanatci
                .Include(s => s.Sehir).FirstOrDefaultAsync(m => m.ID == id);

            if (Sanatci == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
