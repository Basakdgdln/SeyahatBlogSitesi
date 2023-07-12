using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatBlogSitesi.Models.Siniflar;

namespace SeyahatBlogSitesi.Controllers
{
    public class HakkımızdaController : Controller
    {
        // GET: Hakkımızda
        readonly Context c = new Context();
      readonly Class2 cs = new Class2();
        public ActionResult Index()
        {
            cs.Hakkımızda = c.Hakkımızdas.ToList();
            cs.Ekip = c.Ekips.ToList();
            cs.İletisim = c.İletisims.ToList();
            return View(cs);
        }
    }
}