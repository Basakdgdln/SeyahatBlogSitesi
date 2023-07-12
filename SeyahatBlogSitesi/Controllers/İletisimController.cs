using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatBlogSitesi.Models.Siniflar;

namespace SeyahatBlogSitesi.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
       readonly Context c = new Context();
        public ActionResult Index()
        {
            var d = c.Hakkımızdas.ToList();
            return View(d);
        }

        public ActionResult İletisimEkle(İletisim p)
        {
            c.İletisims.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}