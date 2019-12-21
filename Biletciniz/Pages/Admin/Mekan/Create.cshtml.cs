using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz.Pages.Admin.Mekan
{
    public class CreateModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public CreateModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IlceID"] = new SelectList(_context.Ilce, "ID", "IlceAdi");
        ViewData["SehirID"] = new SelectList(_context.Sehir, "ID", "SehirAdi");
            return Page();
        }

        [BindProperty]
        public Biletciniz.Models.Mekan Mekan { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mekan.Add(Mekan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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
