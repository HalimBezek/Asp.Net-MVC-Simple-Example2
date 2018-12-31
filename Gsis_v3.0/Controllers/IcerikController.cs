using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gsis.Controllers
{
    public class IcerikController : BaseController
    {
        public ActionResult Index(int? id)
        {
            var icerik = data.ICERIKs.First(f => f.MENU_ID == id);
            ViewBag.icerik = icerik.ICERIK1;


            // SOL MENU İÇİN GÖNDER
            var kategori = data.KATEGORILERs.Where(f => f.ID == icerik.MENU_ID);

            ViewBag.alt_kategoriler = data.KATEGORILERs.Where(f => f.UST_KATEGORI_ID == kategori.First().UST_KATEGORI_ID);
            //ViewBag.kategori = data.KATEGORILERs.First(f=>f.ID == kategori.First().UST_KATEGORI_ID).KATEGORI_ADI;


            //layouta gönderiliyor
            ViewBag.PageTitle = kategori.First().KATEGORI_ADI;


            ViewBag.Description = icerik.DESCRIPTION;
            ViewBag.Keywords = icerik.KEYWORDS;
            ViewBag.Title = icerik.TITLE;
             

            return View();
        }






        public ActionResult gorusler()
        {
            ViewBag.gorusler = data.KATILIMCI_GORUSLERIs.OrderByDescending(f => f.ID);

            return View();
        }
    }
}
