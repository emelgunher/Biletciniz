using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biletciniz.Data;
using Biletciniz.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Biletciniz.Pages.Admin.Etkinlik
{
    public class CreateModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CreateModel(Biletciniz.Data.ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
     

        
   

        public IActionResult OnGet()
        {


        ViewData["KategoriID"] = new SelectList(_context.Kategori, "ID", "KategoriAdi");
        ViewData["MekanID"] = new SelectList(_context.Mekan, "ID", "MekanAdi");
        ViewData["TurID"] = new SelectList(_context.Tur, "ID", "TurAdi");
            return Page();
        }

        [BindProperty]
        public Biletciniz.Models.Etkinlik Etkinlik { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images\Etkinlik");
            var extension = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }
           Etkinlik.Afis = @"\images\Etkinlik\" + fileName + extension;
            _context.Etkinlik.Add(Etkinlik);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public JsonResult OnGetTurler(int kkategoriID)
        {
            var id =kkategoriID;

           
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
