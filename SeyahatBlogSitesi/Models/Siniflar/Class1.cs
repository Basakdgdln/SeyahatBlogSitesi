using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Class1
    {
        public IEnumerable<Blog> Blog { get; set; }
        public IEnumerable<Yorumlar> Yorum { get; set; }
        public IEnumerable<SeyahatRehberi> Rehber { get; set; }
        public IEnumerable<Hakkımızda> Hakkımızda { get; set; }
      
    }
}