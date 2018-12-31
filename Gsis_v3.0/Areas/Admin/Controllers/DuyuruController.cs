using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class DuyuruController : BaseController
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
        public ActionResult ekle(string baslik, string editor1)
        {

            try
            {

                    DUYURULAR yeni_duyuru = new DUYURULAR();
                    yeni_duyuru.BASLIK = baslik;
                    yeni_duyuru.DUYURU = editor1;
                    yeni_duyuru.TARIH = DateTime.Now;


                    data.DUYURULARs.InsertOnSubmit(yeni_duyuru);
                    data.SubmitChanges();


                    mesaj[0] = "alert-info"; mesaj[1] = "Duyuru başarıyla eklendi..";
                    ViewBag.mesaj = mesaj;
            


            }
            catch
            {
                mesaj[0] = "alert-error"; mesaj[1] = "Duyuru Eklenirken hata oluştu !";
                ViewBag.mesaj = mesaj;
            }

            return View();
        }


        public ActionResult listele()
        {


            if (Request.QueryString["sil"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["sil"]);

                try
                {
                    DUYURULAR hbr = data.DUYURULARs.First(f => f.ID == id);

                    data.DUYURULARs.DeleteOnSubmit(hbr);
                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Duyuru başarıyla silindi..";
                    ViewBag.mesaj = mesaj;

                }
                catch
                {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }







            ViewBag.Duyurular = data.DUYURULARs;
            return View();
        }













        public ActionResult detay(int id)
        {
            ViewBag.duyuru = data.DUYURULARs.First(f => f.ID == id);
            return View();
        }



        [ValidateInput(false)]
        [HttpPost]
        public ActionResult detay(int id, string icerik)
        {
            try
            {

               DUYURULAR duyuru = data.DUYURULARs.First(f => f.ID == id);

               duyuru.DUYURU = icerik;

                data.SubmitChanges();
            }
            catch { }



            ViewBag.duyuru = data.DUYURULARs.First(f => f.ID == id);
            return View();
        }
	}
}