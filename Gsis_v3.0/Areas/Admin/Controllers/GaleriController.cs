using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;
 

namespace Gsis.Areas.Admin.Controllers
{
    public class GaleriController : BaseController
    {
        //
        // GET: /Galeri/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listele(int? galeri_id)
        {

            // query stringte  resim_sil varsa silme işlemini yap
            if(Request.QueryString["resim_sil"] != null)
            {
             int r_id = Convert.ToInt32(Request.QueryString["resim_sil"]);

               
                    GALERI_RESIMLERI galeri = data.GALERI_RESIMLERIs.First(f => f.ID == r_id);

                    try
                    {
                        System.IO.FileInfo res = new System.IO.FileInfo(Server.MapPath("~") + "Content\\img\\galeri\\" + galeri.RESIM);
                        res.Delete();

                        System.IO.FileInfo temp = new System.IO.FileInfo(Server.MapPath("~") + "Content\\img\\galeri\\t_" + galeri.RESIM);
                        temp.Delete();

                    }  catch{ }


                    try
                    {
                        data.GALERI_RESIMLERIs.DeleteOnSubmit(galeri);
                        data.SubmitChanges();

                        mesaj[0] = "alert-info"; mesaj[1] = "Galeri resmi başarıyla silindi..";
                        ViewBag.mesaj = mesaj;

                    }
                    catch
                    {
                        mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                        ViewBag.mesaj = mesaj;
                    }
            }
            ////////////////////////////////////////////////////////////////////////////////////////


            // query stringde galeri_sil varsa galeriyi sil
            if (Request.QueryString["galeri_sil"] != null)
            {
                int g_id = Convert.ToInt32(Request.QueryString["galeri_sil"]);

                try
                {
                    GALERILER galeri = data.GALERILERs.First(f => f.ID == g_id);
                    data.GALERILERs.DeleteOnSubmit(galeri);
                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Resim galerisi başarıyla silindi..";
                    ViewBag.mesaj = mesaj;

                }
                catch
                {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }
            /////////////////////////////////////////////////////////////







            // id yoksa tüm resimleri listele

            if (galeri_id == null)
            {
                ViewBag.Galeri_Resimleri = data.GALERI_RESIMLERIs.OrderBy(f=>f.SIRA_NO);
            }else
            {
                ViewBag.Galeri_Resimleri = data.GALERI_RESIMLERIs.Where(f => f.GALERI_ID == galeri_id).OrderBy(f => f.SIRA_NO);
            }
            
            return View();
        }


        public ActionResult ekle()
        {
            ViewBag.Galeriler = data.GALERILERs;

            return View();
        }

        [HttpPost]
        public ActionResult ekle(string aciklama, HttpPostedFileBase resim, int galeri_id, int sira_no)
        {


            //try
            //{
                if (resim != null && resim.ContentLength > 0)
                {
                    Random r = new Random();
                    var resim_ayar = data.RESIM_AYARs.First();
                    string resim_adi = r.NextDouble().ToString() + r.NextDouble().ToString() + ".jpg";
                    string dizin = Server.MapPath("~") + "Content\\img\\galeri\\";


                    Resim image = new Resim();
                    
                    image.Genislik = resim_ayar.GALERI_K_W.Value;
                    //image.ResimResize(resim, dizin + "t_" + resim_adi, data.SITE_BILGILERIs.First().WATERMARK);
                    // küçük yüklendi

                    image.Genislik = resim_ayar.GALERI_B_W.Value;
                    //image.ResimResize(resim, dizin + resim_adi, data.SITE_BILGILERIs.First().WATERMARK);
                    // büyük yüklendi



                    // VERI TABANINA EKLE
                    GALERI_RESIMLERI yeni_resim = new GALERI_RESIMLERI();
                    yeni_resim.GALERI_ID = galeri_id;
                    yeni_resim.ACIKLAMA = aciklama;
                    yeni_resim.RESIM = resim_adi;
                    yeni_resim.SIRA_NO = sira_no;
                   
                    data.GALERI_RESIMLERIs.InsertOnSubmit(yeni_resim);
                    data.SubmitChanges();


                     

                    // MESAJI SAYFAYA GONDER
                    mesaj[0] = "alert-info"; mesaj[1] = "Galeri resmi başarıyla eklendi..";
                    ViewBag.mesaj = mesaj;

                }
                else
                {

                    // MESAJI SAYFAYA GONDER
                    mesaj[0] = "alert-info"; mesaj[1] = "Lütfen Resim Seçiniz..";
                    ViewBag.mesaj = mesaj;
                }



            //}
            //catch
            //{
            //    // MESAJI SAYFAYA GONDER
            //    mesaj[0] = "alert-error"; mesaj[1] = "Galeri Resmi Eklenirken hata oluştu !";
            //    ViewBag.mesaj = mesaj;
            //}





            ViewBag.Galeriler = data.GALERILERs;
            ViewBag.Galeri_Resimleri = data.GALERI_RESIMLERIs.OrderBy(f=>f.SIRA_NO);

            return View("listele");
        }
       
	}
}