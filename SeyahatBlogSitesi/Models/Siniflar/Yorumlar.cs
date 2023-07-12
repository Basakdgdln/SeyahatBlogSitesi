using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string KullaniciAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Mail { get; set; }

        [Column(TypeName = "Varchar")]
        public string Yorum { get; set; }
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }

    }
}