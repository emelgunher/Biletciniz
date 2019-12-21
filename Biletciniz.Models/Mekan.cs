using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
    public class Mekan
    {
        public int ID { get; set; }

        [Display(Name = "Mekan Adı")]
        public string MekanAdi { get; set; }
        public int Kapasite { get; set; }

        public int SehirID { get; set; }

       [ForeignKey("SehirID")]
        public virtual Sehir Sehir { get; set; }

        public int IlceID { get; set; }

        [ForeignKey("IlceID")]
        public virtual Ilce Ilce { get; set; }
    }
}
