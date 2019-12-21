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

namespace Biletciniz.Pages.Admin.Etkinlik
{
    public class EditModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public EditModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["KategoriID"] = new SelectList(_context.Kategori, "ID", "KategoriAdi");
           ViewData["MekanID"] = new SelectList(_context.Mekan, "ID", "MekanAdi");
           ViewData["TurID"] = new SelectList(_context.Tur, "ID", "TurAdi");
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

            _context.Attach(Etkinlik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtkinlikExists(Etkinlik.ID))
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

        private bool EtkinlikExists(int id)
        {
            return _context.Etkinlik.Any(e => e.ID == id);
        }

        public JsonResult OnGetTurler(int kkategoriID)
        {
            var id = kkategoriID;


            var TurlerListe = _context.Tur.Where(x => x.KategoriID == id).ToList();


            List<Tur> model = new List<Tur>();
            foreach (var turler in TurlerListe)
            {
                model.Add(new Tur()
                {
                    ID = turler.ID,
                    TurAdi = turler.TurAdi,
                    KategoriID = turler.KategoriID
                });

            }


            return new JsonResult(model);
        }
    }
}
