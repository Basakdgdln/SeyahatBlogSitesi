using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Kullanici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Sifre { get; set; }
    }
}