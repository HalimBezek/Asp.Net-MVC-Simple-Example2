using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Controllers
{
    public class BaseController : Controller
    {
        public DataClasses1DataContext data = new DataClasses1DataContext();
        public string[] mesaj = new string[2];

        public static string AnaDizin = "";
        public static string Domain = "";

        public BaseController()
        {

            

         
               ViewBag.kategoriler = data.KATEGORILERs.Where(f => f.DURUM == true && f.UST_MENU == true).OrderBy(f=>f.SIRA_NO);




            // ILETISIM BILGILERI
                var iletisim = data.ILETISIM_BILGILERIs.First();

                ViewBag.Mail = iletisim.MAIL1;
                ViewBag.Tel = iletisim.TEL1;
                ViewBag.Adres = iletisim.ADRES + " , " + iletisim.ILCE + " , " + iletisim.IL;
                ViewBag.Fax = iletisim.FAX;


            // ANA SAYFA HAKKIMIZDA  YAZISI 
               var hakkimizda = data.ICERIKs.First(f => f.SAYFA_NO == 2).ICERIK1;
               if (hakkimizda.Length > 500)
               {
                   ViewBag.hakkimizda = hakkimizda.Substring(0, 500);
               }
               else
               {
                   ViewBag.hakkimizda = hakkimizda;
               }

            // TEMA ADI



               //ViewBag.ThemeName = System.Configuration.ConfigurationManager.AppSettings["themename"];
           

            // SITE BILGILERI

               var site_bilgileri = data.SITE_BILGILERIs.First();
 
            // upload ashx için
               //AnaDizin = site_bilgileri.ANA_DIZIN;
               Domain = site_bilgileri.DOMAIN;

               //ViewBag.ThemeName = site_bilgileri.TEMA;
               ViewBag.Acilis_mesaji = site_bilgileri.ACILIS_MESAJI;
               ViewBag.mesaj_varmi = site_bilgileri.ACILIS_MESAJI_DURUM;

               ViewBag.Slogan = site_bilgileri.SLOGAN;
               ViewBag.Logo = site_bilgileri.LOGO;
               ViewBag.Domain = site_bilgileri.DOMAIN;
               ViewBag.Cop = site_bilgileri.COPH;
               

            // SOSYAL MEDYA GONDEr

               var sosyal_medya = data.SOSYAL_MEDYAs.First();

               ViewBag.Facebook = sosyal_medya.FACEBOOK;
               ViewBag.Twitter = sosyal_medya.TWITTER;

               ViewBag.Behance = sosyal_medya.BEHANCE;
               ViewBag.Instagram = sosyal_medya.INSTAGRAM;



            // HABER DUYURULAR GALERI


               ViewBag.Son_haberler = data.HABERLERs.Take(3).OrderByDescending(d => d.ID);
               //ViewBag.Son_resimler = data.GALERI_RESIMLERIs.Take(6).OrderByDescending(d => d.ID) ;
               ViewBag.Son_duyurular = data.DUYURULARs.Take(6).OrderByDescending(d => d.ID);
        }   
     
    }
}
