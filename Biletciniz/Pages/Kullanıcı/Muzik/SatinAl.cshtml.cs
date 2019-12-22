using System;
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

       
     public string isim { get; set; }
        public  int Etkinlikid { get; set; }
        public Biletciniz.Models.Etkinlik etkinlik { get; set; }

        public IActionResult OnGet(int? id)
        {
             // isim =_context.Etkinlik.Find(id).EtkinlikAdi;
             //Etkinlikid= _context.Etkinlik.Find(id).ID;
             etkinlik= _context.Etkinlik.Find(id);
            ViewData["EtkinlikID"] = new SelectList(_context.Etkinlik, "ID", "EtkinlikAdi");

            return Page();
              
        }

        [BindProperty]
        public Biletciniz.Models.Bilet Bilet { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            if (!ModelState.IsValid)
            {
                return Page();
            }
           
         
            _context.Bilet.Add(Bilet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

       


    }
}