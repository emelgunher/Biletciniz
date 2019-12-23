using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Biletciniz.Models;

namespace Biletciniz.Pages.Kullanıcı.Aile
{
    public class IndexModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _db;
        public IndexModel(Biletciniz.Data.ApplicationDbContext db)
        {
            _db = db;
        }


        public List<Etkinlik> satista { get; set; }
        public List<Etkinlik> yakinda { get; set; }
        public List<Etkinlik> BiletAl { get; set; }

        public void OnGet()
        {
            satista = _db.Etkinlik.Where(x => (x.BaslangicTarihi <= DateTime.Now
            && x.BitisTarihi > DateTime.Now && x.Kategori.KategoriAdi=="Aile")).ToList();

            yakinda = _db.Etkinlik.Where(x => (x.BaslangicTarihi > DateTime.Now
                  && x.BitisTarihi > DateTime.Now && x.Kategori.KategoriAdi == "Aile")).ToList();

            BiletAl = _db.Etkinlik.Where(x => x.Kategori.KategoriAdi == "Aile").ToList();

        }
    }
}
