using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatBlogSitesi.Models.Siniflar;

namespace SeyahatBlogSitesi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
      readonly Context c = new Context();
      readonly Class1 cs = new Class1();
        public ActionResult Index()
        {
            cs.Blog = c.Blogs.Where(x => x.BegeniDurum==true).ToList();
            cs.Rehber = c.SeyahatRehberis.ToList();
            cs.Yorum = c.Yorumlars.ToList();
            cs.Hakkımızda = c.Hakkımızdas.ToList();
            return View(cs);
        }

        public PartialViewResult SonGönderiler()
        {
            var y = c.Blogs.OrderByDescending(x => x.ID).Take(4).ToList();
            return PartialView(y);
        }

    }
}