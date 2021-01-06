using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LSYS.Models.Entity;
namespace LSYS.Controllers
{
    public class LoginController : Controller
    {
        //YÖNETİCİ LOGIN
        // GET: Login
        LSYSEntities db = new LSYSEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_YONETICI p, TBL_BAYI b, ADMIN a, TBL_MUSTERI m)
        {
            var bilgiler = db.TBL_YONETICI.FirstOrDefault(x => x.KULLANICI_ADI == p.KULLANICI_ADI
            && x.SIFRE == p.SIFRE);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI_ADI, false);
                Session["KullanıcıAdı"] = bilgiler.KULLANICI_ADI.ToString();
                TempData["ID"] = bilgiler.YONETICI_ID.ToString();
                TempData["Ad"] = bilgiler.YONETICI_AD.ToString();
                TempData["Soyad"] = bilgiler.YONETICI_SOYAD.ToString();
                TempData["Sifre"] = bilgiler.SIFRE.ToString();
                
                return RedirectToAction("Index", "YPanel");
            }


            var bilgiler2 = db.TBL_BAYI.FirstOrDefault(x => x.KULLANICI_ADI == b.KULLANICI_ADI && x.SIFRE == b.SIFRE);
            if (bilgiler2 != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler2.KULLANICI_ADI, false);
                //Session["KullanıcıAdı"] = bilgiler2.KULLANICI_ADI.ToString();
                //TempData["ID"] = bilgiler2.YONETICI_ID.ToString();

                return RedirectToAction("Index", "BPanel");
            }



            var bilgiler3 = db.ADMIN.FirstOrDefault(x => x.KULLANICI_ADI == a.KULLANICI_ADI && x.SIFRE == a.SIFRE);
            if (bilgiler3 != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler3.KULLANICI_ADI, false);

                return RedirectToAction("Index", "Admin");
            }


            
            var bilgiler4 = db.TBL_MUSTERI.FirstOrDefault(x => x.KULLANICI_ADI == m.KULLANICI_ADI && x.SIFRE == m.SIFRE);
            if (bilgiler4 != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler4.KULLANICI_ADI, false);
                Session["KullanıcıAdı"] = bilgiler4.KULLANICI_ADI.ToString();
                TempData["ID"] = bilgiler4.MUSTERI_ID.ToString();
                TempData["Ad"] = bilgiler4.AD.ToString();
                TempData["Soyad"] = bilgiler4.SOYAD.ToString();
                TempData["Sifre"] = bilgiler4.SIFRE.ToString();
                TempData["Telefon"] = bilgiler4.TELEFON.ToString();
                TempData["Adres"] = bilgiler4.ADRES.ToString();
                TempData["BayiAdi"] = bilgiler4.TBL_BAYI.BAYI_ADI.ToString();
                TempData["Mail"] = bilgiler4.MAIL.ToString();
                TempData["DogumTarihi"] = bilgiler4.DOGUM_TARIHI.ToString();
                
                return RedirectToAction("Index", "MPanel");
            }



            else
            {
                return View();
            }


           
        }
    }
}