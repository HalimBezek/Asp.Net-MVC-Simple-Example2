using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Controllers
{
    public class IletisimController : BaseController
    {
        public ActionResult Index(int id)
        {

            ViewBag.sabit_icerik = data.ICERIKs.First(f => f.SAYFA_NO == id);

            var iletisim_bilgileri = data.ILETISIM_BILGILERIs.First();

            ViewBag.Adres = iletisim_bilgileri.ADRES + " " + iletisim_bilgileri.ILCE + "/" + iletisim_bilgileri.IL;
            ViewBag.Tel = iletisim_bilgileri.TEL1;
            ViewBag.Fax = iletisim_bilgileri.FAX;
            ViewBag.Mail = iletisim_bilgileri.MAIL1;
            ViewBag.Enlem = iletisim_bilgileri.ENLEM;
            ViewBag.Boylam = iletisim_bilgileri.BOYLAM;

            return View();
        }


        [HttpPost]
        public string Index(string ad_soyad, string email, string konu, string mesaj)
        {
            ILETISIM_FORMLARI yeni = new ILETISIM_FORMLARI();

            yeni.AD_SOYAD = ad_soyad;
            yeni.KONU = konu;
            yeni.GSM = "";
            yeni.MAIL = email;
            yeni.MESAJ = mesaj;
            yeni.TARIH = DateTime.Now;

            data.ILETISIM_FORMLARIs.InsertOnSubmit(yeni);

            data.SubmitChanges();

            return "OK";
          
        }

    }
}
