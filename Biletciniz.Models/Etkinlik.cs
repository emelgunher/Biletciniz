using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
    public class Etkinlik
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Etkinlik Adı")]
        public string EtkinlikAdi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tarih { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BaslangicTarihi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BitisTarihi { get; set; }
        public string Afis { get; set; }
        public int Süre { get; set; }

        public int KategoriID { get; set; }
        [ForeignKey("KategoriID")]
        public virtual Kategori Kategori { get; set; }

        public int TurID { get; set; }
        [ForeignKey("TurID")]
        public virtual Tur Tur { get; set; }

        public int MekanID { get; set; }
        [ForeignKey("MekanID")]
        public virtual Mekan Mekan { get; set; }

        public virtual ICollection<EtkinlikSanatci> EtkinlikSanatci { get; set; }

    }
}
