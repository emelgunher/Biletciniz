﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Biletciniz.Models;

namespace Biletciniz.Pages.Kullanıcı.Muzik
{
    public class PopModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _db;
        public PopModel(Biletciniz.Data.ApplicationDbContext db)
        {
            _db = db;
        }


        public List<Etkinlik> BiletAl { get; set; }

        public void OnGet()
        {


            BiletAl = _db.Etkinlik.Where(x => x.KategoriID == 1).ToList();
        }
    }
}