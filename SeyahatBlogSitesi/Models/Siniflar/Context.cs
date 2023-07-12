using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeyahatBlogSitesi.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetay> BlogDetays { get; set; }
        public DbSet<Ekip> Ekips { get; set; }
        public DbSet<Hakkımızda> Hakkımızdas { get; set; }
        public DbSet<İletisim> İletisims { get; set; }
        public DbSet<Seyahatler> Seyahatlers { get; set; }
        public DbSet<SeyahatRehberi> SeyahatRehberis { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }


    }
}