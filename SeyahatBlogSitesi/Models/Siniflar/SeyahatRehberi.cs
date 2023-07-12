using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class SeyahatRehberi
    {
        [Key]
        public int RehberID { get; set; }

        [Column(TypeName =("Varchar"))]
        [StringLength(30)]
        public string Rehber { get; set; }
        public string Aciklama { get; set; }

        public ICollection<BlogDetay> BlogDetays { get; set; }
    }
}