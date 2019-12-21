using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
     public class ApplicationUser : IdentityUser
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }

        public DateTime DogumTarihi { get; set; }

        [NotMapped]

        public string AdSoyad { get { return Ad + " " + Soyad; } }
    }
}
