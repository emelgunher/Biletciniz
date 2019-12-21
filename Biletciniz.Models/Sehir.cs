using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biletciniz.Models
{
    public class Sehir
    {
        public int ID { get; set; }

        [Display(Name = "Şehir Adı")]
        public string SehirAdi { get; set; }
        public virtual ICollection<Ilce> Ilce { get; set; }

      
    }
}
