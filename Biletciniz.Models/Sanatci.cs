using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
    public class Sanatci
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DogumTarihi { get; set; }

        public int SehirID { get; set; }
        [ForeignKey("SehirID")]
        public virtual Sehir Sehir { get; set; }

        public string Cinsiyet { get; set; }
        public virtual ICollection<EtkinlikSanatci> EtkinlikSanatci { get; set; }

    }
 
}
