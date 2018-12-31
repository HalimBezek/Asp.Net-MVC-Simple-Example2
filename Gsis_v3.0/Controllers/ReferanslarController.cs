using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gsis.Controllers
{
    public class ReferanslarController : BaseController
    {
        //
        // GET: /Referanslar/
        public ActionResult Index(int id)
        {

            ViewBag.sabit_icerik = data.ICERIKs.First(f => f.SAYFA_NO == id);


            var referanslar = data.REFERANSLARs.OrderByDescending(f => f.ID);
            ViewBag.referanslar = referanslar;

            return View();
        }

    }
}
