using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class HaberController : BaseController
    {
        //
        // GET: /Haber/
        public ActionResult Index()
        {
            return View();
        }







        public ActionResult ekle()
        {
            return View();
        }

         [ValidateInput(false)]
        [HttpPost]
        public ActionResult ekle(HttpPostedFileBase resim, string baslik, string icerik)
        {
            try
            {
                if (resim != null && resim.ContentLength > 0)
                {
                    Random r = new Random();
                    var resim_ayar = data.RESIM_AYARs.First();

                    string resim_adi = r.NextDouble().ToString() + r.NextDouble().ToString() + ".jpg";
                    string dizin = Server.MapPath("~") + "Content\\img\\haber\\";


                    Resim image = new Resim();

                    image.Genislik = resim_ayar.HABER_K_W.Value;
                    image.ResimResize(resim, dizin+ "t_" + resim_adi, "");

                    //image.Genislik = resim_ayar.HABER_K_W.Value ;
                    //image.ResimResize(resim, dizin+ "p_" + resim_adi, "");

                    image.Genislik = resim_ayar.HABER_B_W.Value;
                    //image.ResimResize(resim, dizin+ "b_" + resim_adi, data.SITE_BILGILERIs.First().WATERMARK);


                    // VERI TABANINA EKLE
                    HABERLER yeni_haber = new HABERLER();
                    yeni_haber.BASLIK = baslik;
                    yeni_haber.ICERIK = icerik;
                    yeni_haber.TARIH = DateTime.Now;
                    yeni_haber.RESIM = resim_adi;

                    data.HABERLERs.InsertOnSubmit(yeni_haber);
                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Haber başarıyla eklendi..";
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
                mesaj[0] = "alert-error"; mesaj[1] = "Haber Eklenirken hata oluştu !";
                ViewBag.mesaj = mesaj;
            }

            return View();
        }


        public ActionResult detay(int id)
        {

            ViewBag.haber = data.HABERLERs.First(f => f.ID == id);
            return View();
        }



         [ValidateInput(false)]
        [HttpPost]
        public ActionResult detay(int id, string icerik)
        {
            try
            {

                HABERLER haber = data.HABERLERs.First(f => f.ID == id);

                haber.ICERIK = icerik;

                data.SubmitChanges();
            }
            catch { }


     
            ViewBag.haber = data.HABERLERs.First(f => f.ID == id);
            return View();
        }


















        public ActionResult listele()
        {

            if (Request.QueryString["sil"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["sil"]);

                try
                {
                    HABERLER hbr = data.HABERLERs.First(f => f.ID == id);

                    data.HABERLERs.DeleteOnSubmit(hbr);
                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Haber başarıyla silindi..";
                    ViewBag.mesaj = mesaj;

                }
                catch
                {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }





            ViewBag.Haberler = data.HABERLERs;
            return View();
        }
	}
}