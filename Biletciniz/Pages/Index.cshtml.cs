using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biletciniz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Biletciniz.Pages
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

        public List<Etkinlik> Bugun { get; set; }

        public void OnGet()
        {
            satista = _db.Etkinlik.Where(x => (x.BaslangicTarihi <= DateTime.Now
                  && x.BitisTarihi >= DateTime.Now)).ToList();

            yakinda = _db.Etkinlik.Where(x => (x.BaslangicTarihi > DateTime.Now
                  && x.BitisTarihi > DateTime.Now)).ToList();
            Bugun = _db.Etkinlik.Where(x => x.BaslangicTarihi < DateTime.Now &&
           x.BitisTarihi >DateTime.Now).ToList();



        }


    }
}
