using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz.Pages.Admin.Mekan
{
    public class IndexModel : PageModel
    {
        private readonly Biletciniz.Data.ApplicationDbContext _context;

        public IndexModel(Biletciniz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Biletciniz.Models.Mekan> Mekan { get;set; }

        public async Task OnGetAsync()
        {
            Mekan = await _context.Mekan
                .Include(m => m.Ilce)
                .Include(m => m.Sehir).ToListAsync();
        }
    }
}
