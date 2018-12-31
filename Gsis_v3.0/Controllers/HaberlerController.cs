using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gsis.Controllers
{
    public class HaberlerController : BaseController
    {
        public ActionResult Index(int id)
        {
            ViewBag.sabit_icerik = data.ICERIKs.First(f => f.SAYFA_NO == id);



            ViewBag.Haberler = data.HABERLERs.OrderBy(f=>f.ID);
          
            return View();
        }

        public ActionResult Detay(int id)
        {
            var haber = data.HABERLERs.First(f => f.ID == id);
            ViewBag.haber = haber;
      
            return View();
        }   
    }
}
