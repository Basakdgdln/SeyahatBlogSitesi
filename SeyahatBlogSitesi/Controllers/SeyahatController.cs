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
    public class SeyahatController : Controller
    {
        // GET: Seyahat
        Context c = new Context();
        Class3 cs = new Class3();

        public ActionResult Index(int id)
        {
            cs.Detay = (from x in c.BlogDetays
                        join y in c.SeyahatRehberis on
                        x.RehberID equals y.RehberID
                        where x.UlkeID == id & x.RehberID == 1
                        select x).ToList();
            ViewBag.d1 = id;
            cs.Rehber = c.SeyahatRehberis.ToList();
            cs.Yorumlar = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            return View(cs);

        }

        public ActionResult Index2(int id, int idd)
        {
            cs.Detay = c.BlogDetays.Where(x => x.UlkeID == id & x.RehberID == idd).ToList();
            cs.Rehber = c.SeyahatRehberis.ToList();
            cs.Yorumlar = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            ViewBag.d1 = id;
            return View(cs);
        }

        public ActionResult SeyahatRehberi(int id, int sayfa=1)
        {
            cs.Detay = c.BlogDetays.Where(x => x.RehberID == id).OrderBy(x => x.UlkeID).ToList().ToPagedList(sayfa,12);
            cs.Rehber = c.SeyahatRehberis.Where(x => x.RehberID == id).ToList();
            return View(cs);
        }
        public ActionResult SeyahatDetay(int id, int idd)
        {
            cs.Detay = c.BlogDetays.Where(x => x.UlkeID == id & x.RehberID == idd).ToList();
            cs.Rehber = c.SeyahatRehberis.ToList();
            cs.Yorumlar = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            ViewBag.d1 = id;
            return View(cs);
        }

        public PartialViewResult SonrakiBlog(int id, int idd)
        {
            var s = c.BlogDetays.Where(x => x.RehberID == id & x.BlogID > idd).OrderBy(x => x.BlogID).Take(2).ToList();
            return PartialView(s);
        }
        public PartialViewResult SonrakiBlog2(int id, int idd)
        {
            var s = c.BlogDetays.Where(x => x.UlkeID > id & x.RehberID == idd).OrderBy(x => x.UlkeID).Take(2).ToList();
            return PartialView(s);
        }

    }
}
