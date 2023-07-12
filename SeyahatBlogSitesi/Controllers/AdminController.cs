using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using SeyahatBlogSitesi.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace SeyahatBlogSitesi.Controllers
{
    public class AdminController : Controller
    {
        //GET: Admin
        readonly Context c = new Context();

        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Blogs.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/İmage/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                b.BlogImage = "~/İmage/" + dosyaadi + uzanti;
            }
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var d = c.Blogs.Find(id);
            c.Blogs.Remove(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var d = c.Blogs.Find(id);
            ViewBag.tarih = d.Tarih.ToShortDateString() + " " + d.Tarih.ToShortTimeString();
            return View("BlogGetir", d);
        }
        public ActionResult BlogGuncelle(Blog p)
        {
            if (!ModelState.IsValid)
            {
                return View("BlogGetir");
            }
            else
            {
                var d = c.Blogs.Find(p.ID);
                d.Baslik = p.Baslik;
                d.Tarih = p.Tarih;
                d.BlogImage = p.BlogImage;
                d.Giris = p.Giris;
                d.Gelisme = p.Gelisme;
                d.Sonuc = p.Sonuc;
                d.BlogTür = p.BlogTür;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult BlogEkle(int id)
        {
            List<SelectListItem> rehber = (from x in c.SeyahatRehberis.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Rehber,
                                               Value = x.RehberID.ToString()
                                           }).ToList();
            ViewBag.d1 = rehber;
            ViewBag.d2 = c.Seyahatlers.Where(x => x.UlkeID == id).Select(x => x.UlkeAD).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult BlogEkle(BlogDetay a)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "/İmage/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    a.UlkeResim = "/İmage/" + dosyaadi + uzanti;
                    a.Resim1 = "/İmage/" + dosyaadi + uzanti;
                    a.Resim2 = "/İmage/" + dosyaadi + uzanti;
                    a.Resim3 = "/İmage/" + dosyaadi + uzanti;
                    if (a.Resim4 != null)
                    {
                        a.Resim4 = "/İmage/" + dosyaadi + uzanti;
                    }
                    if (a.Resim5 != null)
                    {
                        a.Resim5 = "/İmage/" + dosyaadi + uzanti;
                    }
                }
                c.BlogDetays.Add(a);
                c.SaveChanges();
                return RedirectToAction("GeziMedya");
            }

            else
            {
                return View("BlogEkle");
            }
        }

        public ActionResult YorumSil(int id)
        {
            var d = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumGetir(int id)
        {
            var d = c.Yorumlars.Where(x => x.BlogID == id).ToList();
            var s = c.Yorumlars.Count(x => x.BlogID == id);
            ViewBag.d1 = s;
            return View(d);
        }
        public ActionResult SeyahatRehberi()
        {
            var s = c.SeyahatRehberis.ToList();
            return View(s);
        }

        [HttpGet]
        public ActionResult RehberEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RehberEkle(SeyahatRehberi s)
        {
            c.SeyahatRehberis.Add(s);
            c.SaveChanges();
            return RedirectToAction("SeyahatRehberi");
        }
        public ActionResult SeyahatGetir(int id)
        {
            var b = c.SeyahatRehberis.Find(id);
            return View("SeyahatGetir", b);
        }
        public ActionResult SeyahatBlogDetay(int id)
        {
            var a = c.BlogDetays.Where(x => x.UlkeID == id).ToList();
            return View(a);
        }

        public ActionResult RehberGuncelle(SeyahatRehberi s)
        {
            var f = c.SeyahatRehberis.Find(s.RehberID);
            f.Rehber = s.Rehber;
            f.Aciklama = s.Aciklama;
            c.SaveChanges();
            return RedirectToAction("SeyahatRehberi");
        }
        public ActionResult BlogDetay(int id)
        {
            var s = c.BlogDetays.Find(id);
            ViewBag.tarih = s.Tarih.ToShortDateString() + " " + s.Tarih.ToShortTimeString();
            return View("BlogDetay", s);
        }
        public ActionResult BlogDetayGuncelle(BlogDetay b)
        {
            if (!ModelState.IsValid)
            {
                return View("BlogDetay");
            }
            else
            {
                var s = c.BlogDetays.Find(b.BlogID);
                s.Baslik = b.Baslik;
                s.Detay = b.Detay;
                s.Detay1 = b.Detay1;
                s.Gelisme = b.Gelisme;
                s.Giris = b.Giris;
                s.Sonuc = b.Sonuc;
                s.UlkeResim = b.UlkeResim;
                s.Resim1 = b.Resim1;
                s.Resim2 = b.Resim2;
                s.Resim3 = b.Resim3;
                s.Resim4 = b.Resim4;
                s.Resim5 = b.Resim5;
                c.SaveChanges();
                return RedirectToAction(s.RehberID.ToString(), "Admin/SeyahatBlogDetay");
            }
        }

        public ActionResult Ekip()
        {
            Class2 cs = new Class2();
            cs.Ekip = c.Ekips.ToList();
            cs.İletisim = c.İletisims.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(System.Web.HttpPostedFileBase FotoUrl, Ekip e)
        {
            if (FotoUrl != null)
            {
                string dosya = Path.GetFileName(FotoUrl.FileName);
                var konum = Path.Combine(Server.MapPath("~/İmage"), dosya);
                FotoUrl.SaveAs(konum);
            }
            c.Ekips.Add(e);
            c.SaveChanges();
            return RedirectToAction("Ekip");
        }
        public ActionResult UyeGetir(int id)
        {
            var a = c.Ekips.Find(id);
            return View("UyeGetir", a);
        }
        public ActionResult UyeGuncelle(Ekip p, System.Web.HttpPostedFileBase FotoUrl)
        {
            if (FotoUrl != null)
            {
                string dosya = Path.GetFileName(FotoUrl.FileName);
                var konum = Path.Combine(Server.MapPath("~/İmage"), dosya);
                FotoUrl.SaveAs(konum);
            }
            var d = c.Ekips.Find(p.ID);
            d.AdSoyad = p.AdSoyad;
            d.Görev = p.Görev;
            d.Hakkında = p.Hakkında;
            d.FotoUrl = p.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("Ekip");
        }
        public ActionResult GeziMedya(int sayfa = 1)
        {
            var z = c.Seyahatlers.ToList().ToPagedList(sayfa, 10);
            return View(z);
        }

        public ActionResult BlogDetaySil(int id)
        {
            var f = c.BlogDetays.Find(id);
            c.BlogDetays.Remove(f);
            c.SaveChanges();
            return RedirectToAction(f.UlkeID.ToString(), "Admin/SeyahatBlogDetay");
        }

        [HttpPost]
        public ActionResult UlkeEkle(Seyahatler s)
        {
            c.Seyahatlers.Add(s);
            c.SaveChanges();
            return RedirectToAction("GeziMedya");
        }


        [HttpGet]
        public ActionResult HakkımızdaGet(int id = 1)
        {
            var s = c.Hakkımızdas.Find(id);
            ViewBag.d1 = s.FotoUrl;
            return View("HakkımızdaGet", s);
        }

        [HttpPost]
        public ActionResult HakkımızdaGuncelle(Hakkımızda p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/İmage/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.FotoUrl = "/İmage/" + dosyaadi + uzanti;
            }
            var d = c.Hakkımızdas.Find(p.ID = 1);
            d.Facebook = p.Facebook;
            d.İnstagram = p.İnstagram;
            d.Twitter = p.Twitter;
            d.Mail = p.Mail;
            d.Hakkimizda = p.Hakkimizda;
            d.FotoUrl = p.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("HakkımızdaGet");
        }

        public ActionResult GelenMesajlar()
        {
            return View(c.İletisims.ToList());
        }
    }
}

