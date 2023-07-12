using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using SeyahatBlogSitesi.Models.Siniflar;

namespace SeyahatBlogSitesi.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        readonly Context c = new Context();
        readonly Class3 cs = new Class3();
        Class1 cs1 = new Class1();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Blogs.Where(x => x.BlogTür == "Dünya").ToList().ToPagedList(sayfa, 8);
            return View(degerler);
        }
        public ActionResult Index2(int sayfa = 1)
        {
            var degerler = c.Blogs.Where(x => x.BlogTür == "Türkiye").ToList().ToPagedList(sayfa, 8);
            return View(degerler);
        }

        public PartialViewResult Partial1()
        {
            cs.Seyehat = c.Seyahatlers.ToList();
            cs.Rehber = c.SeyahatRehberis.ToList();
            return PartialView(cs);
        }
       
        public ActionResult BlogDetay(int id, string p)
        {
            var toplam = c.Yorumlars.Count(x => x.BlogID == id);
            if (toplam != 0)
            {
                ViewBag.d2 = toplam + " " + "Yorum";
            }
            else { }

          
            cs1.Blog = (from x in c.Blogs where x.ID == id select x).ToList();
            if(!string.IsNullOrEmpty(p))
            {
                cs1.Blog = cs1.Blog.Where(x => x.Giris.Contains(p) || x.Gelisme.Contains(p));
            }
            cs1.Rehber = c.SeyahatRehberis.ToList();
            return View(cs1);
        }

      
        public PartialViewResult YorumGetir(int id)
        {
            var d = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            ViewBag.d1 = id;
            return PartialView(d);
        }

        public PartialViewResult SonrakiBlog(int id)
        {
            var s = c.Blogs.Where(x => x.ID > id).OrderBy(x => x.ID).Take(2).ToList();
            return PartialView(s);
        }

        [HttpGet]
        public PartialViewResult YorumEkle(int id)
        {
            var d = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            ViewBag.d1 = id;
            return PartialView(d);
        }

        [HttpPost]
        public PartialViewResult YorumEkle(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }

    }
}