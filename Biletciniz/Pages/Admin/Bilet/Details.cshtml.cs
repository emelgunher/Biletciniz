using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz.Pages.Admin.Bilet
{
    public class DetailsModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public DetailsModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Biletciniz.Models.Bilet Bilet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bilet = await _context.Bilet
                .Include(b => b.Etkinlik).FirstOrDefaultAsync(m => m.ID == id);

            if (Bilet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
