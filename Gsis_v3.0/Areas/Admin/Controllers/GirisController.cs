using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class GirisController : Controller
    {
        public ActionResult giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult giris(string kullanici, string sifre)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();

            var admins = data.ADMINs.Where(f=>f.KULLANICI_ADI == kullanici).Where(f=>f.SIFRE == sifre).Where(f=>f.DURUM == true);


            if (admins.Count() > 0)
            {
                System.Web.HttpContext.Current.Session["ID"] = "1";  // giriş için session a id atandı
                return Redirect("/Admin");
            }
            else
            {
                return Redirect("/Admin");
            }

        }

      

        public ActionResult cikis()
        {
            Session["ID"] = null;
            return Redirect("/Admin/Giris");
        }
	}
}