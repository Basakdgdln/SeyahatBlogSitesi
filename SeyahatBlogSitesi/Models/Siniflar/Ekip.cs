using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Ekip
    {

        [Key]
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string Görev { get; set; }
        public string FotoUrl { get; set; }
        public string Hakkında { get; set; }
    }
}