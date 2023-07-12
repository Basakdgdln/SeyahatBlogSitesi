using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public string Giris { get; set; }
        public string Gelisme { get; set; }
        public string Sonuc { get; set; }
        public string BlogImage { get; set; }

        [Required(ErrorMessage ="Blog Türünü seçiniz...")]
        public string BlogTür { get; set; }
        public bool BegeniDurum { get; set; }

        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}