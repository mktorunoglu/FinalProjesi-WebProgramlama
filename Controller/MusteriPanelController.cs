using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLabProjeOdevi.Controllers
{
    public class MusteriPanelController : Controller
    {

        WebProjeEntities db = new WebProjeEntities(); //Veritabanı bağlantısı sağlayan connection.

        public ActionResult Index()
        {

            return View();
        }
        //Model-View-Controller yapısı kullanılmıştır.
        //Id si 1 olan müşteri veritabanından çekilerek View e gönderilir.Profil bilgilerinin görüntüleneceği sayfayı açar.
        [HttpGet] 
        public ActionResult MusteriProfil()
        {
            //var musteri = db.TBL_MUSTERI.Where(m => m.KULLANICI_ADI == Session["KullanıcıAdı"].ToString()).FirstOrDefault();
            var musteri = db.TBL_MUSTERI.Where(m => m.MUSTERI_ID == 1).FirstOrDefault();

            return View(musteri);
        }

        //Formdan gelen veriyle müşteri bilgileri güncellenir.Geriye tekrar müşteri classı dönülür.
        [HttpPost]
        public ActionResult MusteriProfil(TBL_MUSTERI istek)
        {

            var musteri = db.TBL_MUSTERI.Where(m => m.MUSTERI_ID == istek.MUSTERI_ID).FirstOrDefault();
            musteri.AD = istek.AD;
            musteri.ADRES = istek.ADRES;
            musteri.BAYI_ID = istek.BAYI_ID;
            musteri.DOGUM_TARIHI = istek.DOGUM_TARIHI;
            musteri.KULLANICI_ADI = istek.KULLANICI_ADI;
            musteri.MAIL = istek.MAIL;
            musteri.MUSTERI_ID = istek.MUSTERI_ID;
            musteri.SIFRE = istek.SIFRE;
            musteri.SOYAD = istek.SOYAD;
            musteri.TELEFON = istek.TELEFON;
            db.SaveChanges();

            return View(musteri);
        }


        //Müşteri ID si 1 olan satışlar veri tabanından çekilir ve elde edilen liste View e gönderilir.
        [HttpGet]
        public ActionResult Urunlerim()
        {
            //var musteri = db.TBL_MUSTERI.Where(m => m.KULLANICI_ADI == Session["KullanıcıAdı"].ToString()).FirstOrDefault();
            //var urunlerim = db.TBL_SATIS.Where(m => m.MUSTERI_ID == musteri.MUSTERI_ID).ToList();

            var urunlerim = db.TBL_SATIS.Where(m => m.MUSTERI_ID == 1).ToList();

            return View(urunlerim);
        }
        
    }
}
