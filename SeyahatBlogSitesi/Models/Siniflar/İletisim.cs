using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class İletisim
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string AdSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Mail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Konu { get; set; }
        public string Mesaj { get; set; }
    }
}