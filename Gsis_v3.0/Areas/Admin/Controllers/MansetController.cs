using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class MansetController : BaseController
    {
        //
        // GET: /Manset/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listele()
        {

            if(Request.QueryString["sil"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["sil"]);

                try
                {
                    MANSET manset = data.MANSETs.First(f => f.ID == id);
                    data.MANSETs.DeleteOnSubmit(manset);
                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Manşet başarıyla silindi..";
                    ViewBag.mesaj = mesaj;

                }  catch {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }
           
            /////////////////////////////////////////////////////////////
            
            ViewBag.Mansetler = data.MANSETs.OrderBy(f=>f.SIRA_NO);

            return View();
        }


        public ActionResult ekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ekle(string baslik, string aciklama, HttpPostedFileBase resim, string link, int sira_no)
        {

           
                try
                {
                    if (resim != null && resim.ContentLength > 0)
                    {
                        Random r = new Random();
                        var resim_ayar = data.RESIM_AYARs.First();
                        string resim_adi = r.NextDouble().ToString() + r.NextDouble().ToString() + ".jpg";
                        string dizin = Server.MapPath("~") + "Content\\img\\manset\\";


                        Resim image = new Resim();
                       
                        image.ResimYukle(resim, dizin+ resim_adi);


                        // VERI TABANINA ISLE
                        MANSET yeni_manset = new MANSET();
                        yeni_manset.BASLIK = baslik;
                        yeni_manset.ACIKLAMA = aciklama;
                        yeni_manset.RESIM = resim_adi;
                        yeni_manset.URL = link;
                        yeni_manset.SIRA_NO = sira_no;

                        data.MANSETs.InsertOnSubmit(yeni_manset);
                        data.SubmitChanges();


                        mesaj[0] = "alert-info"; mesaj[1] = "Manşet başarıyla eklendi..";
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
                    mesaj[0] = "alert-error"; mesaj[1] = "Manşet Eklenirken hata oluştu !";
                    ViewBag.mesaj = mesaj;
                }

            return View();
        }
       
	}
}