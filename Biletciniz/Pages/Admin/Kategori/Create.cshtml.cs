﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biletciniz.Data;
using Biletciniz.Models;

namespace Biletciniz
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
            return Page();
        }

        [BindProperty]
        public Kategori Kategori { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kategori.Add(Kategori);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
