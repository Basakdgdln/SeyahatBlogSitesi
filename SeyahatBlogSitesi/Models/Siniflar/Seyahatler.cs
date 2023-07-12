using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Seyahatler
    {
        [Key]
        public int UlkeID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string UlkeAD { get; set; }    
        public ICollection<BlogDetay> BlogDetays { get; set; }

    }
}