using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
    public class Ilce
    {
        public int ID { get; set; }

        [Display(Name = "İlçe Adı")]
        public string IlceAdi { get; set; }

        [Display(Name = "Şehir Adı")]
        public int SehirID { get; set; }
        [ForeignKey("SehirID")]
        public virtual Sehir Sehir { get; set; }

        public virtual ICollection<Mekan> Mekan { get; set; }
    }
}
