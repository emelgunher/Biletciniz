using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biletciniz.Models
{
    public class EtkinlikSanatci
    {
        public int ID { get; set; }

        public int SanatciID { get; set; }
        [ForeignKey("SanatciID")]
        public virtual Sanatci Sanatci { get; set; }

        public int EtkinlikID { get; set; }
        [ForeignKey("EtkinlikID")]
        public virtual Etkinlik Etkinlik { get; set; }
    }
}
