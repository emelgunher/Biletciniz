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

namespace Biletciniz.Pages.Admin.Mekan
{
    public class EditModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public EditModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            ViewData["IlceID"] = new SelectList(_context.Ilce, "ID", "IlceAdi");
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

            _context.Attach(Mekan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MekanExists(Mekan.ID))
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

        private bool MekanExists(int id)
        {
            return _context.Mekan.Any(e => e.ID == id);
        }

        public JsonResult OnGetIlceler(int sehirID)
        {
            var id = sehirID;


            var İlcelerListe = _context.Ilce.Where(x => x.SehirID == id).ToList();


            List<SelectListItem> model = new List<SelectListItem>();
            foreach (var ilce in İlcelerListe)
            {
                model.Add(new SelectListItem()
                {
                    Value = ilce.ID.ToString(),
                    Text = ilce.IlceAdi

                });

            }


            return new JsonResult(model);
        }
    }
}
