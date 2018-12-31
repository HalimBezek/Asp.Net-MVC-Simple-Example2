using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class GoruslerController : BaseController
    {
        //
        // GET: /KatilimciGorusleri/
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
        public ActionResult ekle(string ad_Soyad, string egitim, string gorus)
        {
            try
            {
                KATILIMCI_GORUSLERI yeni = new KATILIMCI_GORUSLERI();

                yeni.AD_SOYAD = ad_Soyad;
                yeni.EGITIM = egitim;
                yeni.GORUS = gorus;
                yeni.TARIH = DateTime.Now;

                data.KATILIMCI_GORUSLERIs.InsertOnSubmit(yeni);

                data.SubmitChanges();

                mesaj[0] = "alert-info"; mesaj[1] = "Görüş başarıyla eklendi..";
                ViewBag.mesaj = mesaj;
            }
            catch
            {
                mesaj[0] = "alert-error"; mesaj[1] = "Görüş Eklenirken hata oluştu !";
                ViewBag.mesaj = mesaj;
            }

            return View();
        }







        public ActionResult listele()
        {
          
            if (Request.QueryString["sil"] != null)
            {
                int r_id = Convert.ToInt32(Request.QueryString["sil"]);
                try
                {
                    KATILIMCI_GORUSLERI gorus = data.KATILIMCI_GORUSLERIs.First(f => f.ID == r_id);
                    data.KATILIMCI_GORUSLERIs .DeleteOnSubmit(gorus);

                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Görüş başarıyla silindi..";
                    ViewBag.mesaj = mesaj;
                }
                catch
                {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında hata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////

            ViewBag.gorusler = data.KATILIMCI_GORUSLERIs;

            return View();
        }



	}
}