using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Gsis.Models;
using System.Xml;


namespace Gsis.Areas.Admin.Controllers
{
    public class AyarlarController : BaseController
    {
     
      

        public ActionResult Index()
        {


            ViewBag.mesaj = TempData["mesaj"];





            ViewBag.TemaName = data.TEMALARs.First().TEMA_ADI;
           // ViewBag.TemaName = System.Web.Configuration.WebConfigurationManager.AppSettings["ThemeName"].ToString();

            ViewBag.site_bilgileri = data.SITE_BILGILERIs.First();
            ViewBag.sosyal_medya = data.SOSYAL_MEDYAs.First();
            ViewBag.iletisim_bilgileri = data.ILETISIM_BILGILERIs.First();


            return View();
        }




         


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult logo(HttpPostedFileBase logo)
        {

            try
            {

                string uzanti = System.IO.Path.GetExtension(logo.FileName);

                if (logo != null && logo.ContentLength > 0 || uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".PNG" || uzanti == ".JPG" || uzanti == ".JPEG")
                {
                    Random r = new Random();
                    var resim_ayar = data.RESIM_AYARs.First();

                    string resim_adi = r.NextDouble().ToString() + r.NextDouble().ToString() + uzanti;
                    string dizin = Server.MapPath("~") + "Content\\img\\";


                    Resim image = new Resim();
                     
                   
                    image.ResimYukle(logo, dizin+ resim_adi);


                    //VARI TABANINA ISLE
                    var site_bilgileri = data.SITE_BILGILERIs.First();
                    site_bilgileri.LOGO = resim_adi;

                    data.SubmitChanges();


                    mesaj[0] = "alert-info"; mesaj[1] = "Logo Güncellendi..";
                    ViewBag.mesaj = mesaj;
                }
                else
                {
                    mesaj[0] = "alert-info"; mesaj[1] = "Lütfen Logo Seçiniz..";
                    ViewBag.mesaj = mesaj;
                }


            }
            catch
            {
                mesaj[0] = "alert-error"; mesaj[1] = "Logo Eklenirken hata oluştu !";
                TempData["mesaj"] = mesaj;
            }



            ViewBag.TemaName = data.TEMALARs.First().TEMA_ADI; // System.Web.Configuration.WebConfigurationManager.AppSettings["ThemeName"].ToString();

            ViewBag.site_bilgileri = data.SITE_BILGILERIs.First();
            ViewBag.sosyal_medya = data.SOSYAL_MEDYAs.First();
            ViewBag.iletisim_bilgileri = data.ILETISIM_BILGILERIs.First();







            mesaj[0] = "alert-info"; mesaj[1] = "Logo Güncellendi" ;
            TempData["mesaj"] = mesaj;

             
            return Redirect("/Admin/ayarlar");
        }



        [HttpPost]
        public ActionResult site_bilgileri(string domain,  string slogan)
        {
            try
            {
               SITE_BILGILERI bilgi = data.SITE_BILGILERIs.First();
                
                bilgi.DOMAIN = domain; 
                bilgi.SLOGAN = slogan;
                  

                data.SubmitChanges();
            }
            catch { }

            ViewBag.TemaName = data.TEMALARs.First().TEMA_ADI; // System.Web.Configuration.WebConfigurationManager.AppSettings["ThemeName"].ToString();

            ViewBag.site_bilgileri = data.SITE_BILGILERIs.First();
            ViewBag.sosyal_medya = data.SOSYAL_MEDYAs.First();
            ViewBag.iletisim_bilgileri = data.ILETISIM_BILGILERIs.First();




            mesaj[0] = "alert-info"; mesaj[1] = "Bilgiler Güncellendi..";
            TempData["mesaj"] = mesaj;



            return Redirect("/Admin/ayarlar");
        }


         



        [HttpPost]
        public ActionResult tema(string tema)
        {


            //System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");

            //config.AppSettings.Settings["ThemeName"].Value = tema;

            //config.Save();


            var temaa = data.TEMALARs.First();
            temaa.TEMA_ADI = tema;

            data.SubmitChanges();



            ViewBag.TemaName = data.TEMALARs.First().TEMA_ADI; // System.Web.Configuration.WebConfigurationManager.AppSettings["ThemeName"].ToString();

            ViewBag.site_bilgileri = data.SITE_BILGILERIs.First();
            ViewBag.sosyal_medya = data.SOSYAL_MEDYAs.First();
            ViewBag.iletisim_bilgileri = data.ILETISIM_BILGILERIs.First();




            mesaj[0] = "alert-info"; mesaj[1] = "Bilgiler Güncellendi..";
            TempData["mesaj"] = mesaj;




            return Redirect("/Admin/ayarlar");
        }



        [HttpPost]
        public ActionResult sosyal_medya(string facebook, string twitter, string google, string youtube, string behance, string instagram)
        {
            try
            {
              
                SOSYAL_MEDYA guncelle = data.SOSYAL_MEDYAs.First();
                guncelle.FACEBOOK = facebook;
                guncelle.TWITTER = twitter;
                guncelle.YOUTUBE = youtube;
                guncelle.GOOGLE = google;
                guncelle.INSTAGRAM = instagram;
                guncelle.BEHANCE = behance;

                data.SubmitChanges();
            }
            catch { }

            ViewBag.TemaName = data.TEMALARs.First().TEMA_ADI; // System.Web.Configuration.WebConfigurationManager.AppSettings["ThemeName"].ToString();

            ViewBag.site_bilgileri = data.SITE_BILGILERIs.First();
            ViewBag.sosyal_medya = data.SOSYAL_MEDYAs.First();
            ViewBag.iletisim_bilgileri = data.ILETISIM_BILGILERIs.First();




            mesaj[0] = "alert-info"; mesaj[1] = "Bilgiler Güncellendi..";
            TempData["mesaj"] = mesaj;




            return Redirect("/Admin/ayarlar");
        }



        [HttpPost]
        public ActionResult iletisim(string enlem, string boylam, string adres, string tel1, string tel2, string gsm, string fax, string mail1, string mail2, string il, string ilce, string yer)
        {
            try
            {
                ILETISIM_BILGILERI guncelle = data.ILETISIM_BILGILERIs.First();
                guncelle.ADRES = adres;
                guncelle.FAX = fax;
                guncelle.GSM = gsm;
                guncelle.IL = il;
                guncelle.ILCE = ilce;
                guncelle.MAIL1 = mail1;
                guncelle.MAIL2 = mail2;
                guncelle.TEL1 = tel1;
                guncelle.TEL2 = tel2;
                guncelle.YER = yer;
                guncelle.ENLEM = enlem;
                guncelle.BOYLAM = boylam;

                data.SubmitChanges();
            }
            catch { }
            ViewBag.TemaName = data.TEMALARs.First().TEMA_ADI; // System.Web.Configuration.WebConfigurationManager.AppSettings["ThemeName"].ToString();

            ViewBag.site_bilgileri = data.SITE_BILGILERIs.First();
            ViewBag.sosyal_medya = data.SOSYAL_MEDYAs.First();
            ViewBag.iletisim_bilgileri = data.ILETISIM_BILGILERIs.First();



            mesaj[0] = "alert-info"; mesaj[1] = "Bilgiler Güncellendi..";
            TempData["mesaj"] = mesaj;




            return Redirect("/Admin/ayarlar");
        }

	}
}