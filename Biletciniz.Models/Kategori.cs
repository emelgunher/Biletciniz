using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biletciniz.Models
{
    public class Kategori
    {
        public int ID { get; set; }

        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; }
    }
}
