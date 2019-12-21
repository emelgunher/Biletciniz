﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biletciniz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Biletciniz
{
    public class SatınAlModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public SatınAlModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                ViewData["EtkinlikID"] = new SelectList(_context.Etkinlik, "ID", "EtkinlikAdi");
                return Page();
              
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bilet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiletExists(Bilet.ID))
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

        private bool BiletExists(int id)
        {
            return _context.Bilet.Any(e => e.ID == id);
        }
    }
}