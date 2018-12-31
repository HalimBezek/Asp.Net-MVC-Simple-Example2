using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class FormController : BaseController
    {
        //
        // GET: /Form/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listele()
        {

            if (Request.QueryString["sil"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["sil"]);

                try
                {
                    ILETISIM_FORMLARI frm = data.ILETISIM_FORMLARIs.First(f => f.ID == id);

                    data.ILETISIM_FORMLARIs.DeleteOnSubmit(frm);
                    data.SubmitChanges();

                    mesaj[0] = "alert-info"; mesaj[1] = "Form başarıyla silindi..";
                    ViewBag.mesaj = mesaj;

                }
                catch
                {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }



            ViewBag.formlar = data.ILETISIM_FORMLARIs;
            return View();
        }



        public ActionResult oku(int id)
        {

           ILETISIM_FORMLARI frm = data.ILETISIM_FORMLARIs.First(f=>f.ID == id);

           ViewBag.form = frm;

            return View();
        }
	}
}