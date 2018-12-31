using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gsis.Areas.Admin.Controllers
{
    public class AController : BaseController
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {

            mesaj[0] = "alert-info"; mesaj[1] = "Admin Paneline Hoşgeldiniz..";
            ViewBag.mesaj = mesaj;



            return View();
        }
	}
}