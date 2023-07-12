using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    
    public class BlogDetay
    {
        [Key]
        public int BlogID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Boş geçilemez!..")]
        public string Baslik { get; set; }
       
        [Required(ErrorMessage = "Boş geçilemez!..")]
        public string Giris { get; set; }

        [Required(ErrorMessage = "Lütfen resim seçiniz...")]
        public string Resim1 { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!..")]
        public string Gelisme { get; set; }

        [Required(ErrorMessage = "Lütfen resim seçiniz...")]
        public string Resim2 { get; set; }

        [Required(ErrorMessage = "Boş geçilemez!..")]
        public string Sonuc { get; set; }

        [Required(ErrorMessage = "Lütfen resim seçiniz...")]
        public string Resim3 { get; set; }

        public string Detay { get; set; }
        public string Resim4 { get; set; }

        public string Detay1 { get; set; }

        public string Resim5 { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime Tarih { get; set; }

        [Required(ErrorMessage = "Lütfen resim seçiniz...")]
        public string UlkeResim { get; set; }

        public int RehberID { get; set; }
        public virtual SeyahatRehberi SeyahatRehberi { get; set; }

        public int UlkeID { get; set; }
        public virtual Seyahatler Seyahatler { get; set; }

       
    }
}