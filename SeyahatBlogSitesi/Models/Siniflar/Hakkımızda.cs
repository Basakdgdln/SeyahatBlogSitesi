using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Hakkımızda
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FotoUrl { get; set; }
        public string Hakkimizda { get; set; }
        public string Facebook { get; set; }
        public string İnstagram { get; set; }
        public string Twitter { get; set; }
        public string Mail { get; set; }

    }
}