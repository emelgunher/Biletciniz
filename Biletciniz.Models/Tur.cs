using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
    public class Tur
    {
        public int ID { get; set; }

        [Display(Name = "Tür Adı")]
        public string TurAdi { get; set; }

        public int KategoriID { get; set; }
        [ForeignKey("KategoriID")]
        public virtual Kategori Kategori { get; set; }
    }
}
