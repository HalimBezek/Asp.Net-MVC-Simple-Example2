using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gsis.Controllers
{
    public class SiteHomeController : BaseController
    {
        public ActionResult Index(int id)
        {



            // sayfanın fullwdith ayarı için gönderiliyor
            ViewBag.anasayfa = "fullscreen";

             
            ViewBag.sabit_icerik = data.ICERIKs.First(f => f.SAYFA_NO == id);


            var mansetler = data.MANSETs.OrderByDescending(f=>f.ID);
            ViewBag.Manset = mansetler;
 

            var referans= data.REFERANSLARs.Take(8).OrderByDescending(f => f.ID);
            ViewBag.Referanslar = referans;

            return View();
        }
    }
}