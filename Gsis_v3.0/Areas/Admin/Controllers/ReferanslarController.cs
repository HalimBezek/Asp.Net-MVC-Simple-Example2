using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class ReferanslarController : BaseController
    {
        //
        // GET: /Galeri/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listele()
        {

            // query stringte  resim_sil varsa silme işlemini yap
            if (Request.QueryString["sil"] != null)
            {
                int r_id = Convert.ToInt32(Request.QueryString["sil"]);

                try
                {
                    REFERANSLAR galeri = data.REFERANSLARs.First(f => f.ID == r_id);
                    data.REFERANSLARs.DeleteOnSubmit(galeri);
                    
                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Referans başarıyla silindi..";
                    ViewBag.mesaj = mesaj;

                }
                catch
                {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////


                ViewBag.referanslar = data.REFERANSLARs.OrderBy(f=>f.SIRA_NO);
          

            return View();
        }


        public ActionResult ekle()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult ekle(string aciklama, string baslik, HttpPostedFileBase resim, int sira_no)
        {


            try
            {
                if (resim != null && resim.ContentLength > 0)
                {
                    Random r = new Random();
                    var resim_ayar = data.RESIM_AYARs.First();

                    string resim_adi = r.NextDouble().ToString() + r.NextDouble().ToString() + ".jpg";
                    string dizin = Server.MapPath("~") + "Content\\img\\referanslar\\";


                    Resim image = new Resim();
                 
                    image.ResimYukle(resim, dizin+ resim_adi);
                    



                    // VERI TABANINA EKLE
                   REFERANSLAR yeni = new REFERANSLAR();
                    yeni.BASLIK= baslik;
                    yeni.ACIKLAMA = aciklama;
                    yeni.RESIM = resim_adi;
                    yeni.SIRA_NO = sira_no;

                    data.REFERANSLARs.InsertOnSubmit(yeni);
                    data.SubmitChanges();


                    mesaj[0] = "alert-info"; mesaj[1] = "Referans başarıyla eklendi..";
                    ViewBag.mesaj = mesaj;

                }
                else
                {
                    mesaj[0] = "alert-info"; mesaj[1] = "Lütfen Resim Seçiniz..";
                    ViewBag.mesaj = mesaj;
                }



            }
            catch
            {
                mesaj[0] = "alert-error"; mesaj[1] = "Referans Eklenirken hata oluştu !";
                ViewBag.mesaj = mesaj;
            }




            return View();
        }

    }
}