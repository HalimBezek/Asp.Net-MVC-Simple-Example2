using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gsis.Controllers
{
    public class GaleriController : BaseController
    {
        public ActionResult Index(int id)
        {
            ViewBag.sabit_icerik = data.ICERIKs.First(f => f.SAYFA_NO == id);


            var galeri = data.GALERI_RESIMLERIs.OrderByDescending(f=>f.ID);
            ViewBag.GaleriResimleri = galeri;


            return View();
        }        
    }
}
