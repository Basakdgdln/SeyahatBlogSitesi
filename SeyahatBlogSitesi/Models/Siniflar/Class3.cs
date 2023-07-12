using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Class3
    {
        public IEnumerable<BlogDetay> Detay { get; set; }
        public IEnumerable<Seyahatler> Seyehat { get; set; }
        public IEnumerable<SeyahatRehberi> Rehber { get; set; }
        public IEnumerable<Yorumlar> Yorumlar { get; set; }
    }
}