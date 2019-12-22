using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
     public class Bilet
    {
        public int ID { get; set; }

        public int EtkinlikID { get; set; }
        [ForeignKey("EtkinlikID")]
        public virtual Etkinlik Etkinlik { get; set; }

        [Display(Name = "Koltuk No")]
        public int KoltukNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SatisTarihi { get; set; }
        public double Fiyat { get; set; }



    }
}
