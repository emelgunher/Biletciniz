using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz.Pages.Admin.Sanatci
{
    public class EditModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public EditModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["SehirID"] = new SelectList(_context.Sehir, "ID", "SehirAdi");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sanatci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanatciExists(Sanatci.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SanatciExists(int id)
        {
            return _context.Sanatci.Any(e => e.ID == id);
        }
    }
}
