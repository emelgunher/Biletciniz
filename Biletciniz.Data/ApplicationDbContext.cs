using System;
using System.Collections.Generic;
using System.Text;
using Biletciniz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biletciniz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bilet> Bilet { get; set; }
        public DbSet<Etkinlik> Etkinlik { get; set; }
        public DbSet<EtkinlikSanatci> EtkinlikSanatci { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Mekan> Mekan { get; set; }
        public DbSet<Sanatci> Sanatci { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }


    }
}
