using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gsis.Models;

namespace Gsis.Areas.Admin.Controllers
{
    public class Is_basvuruController : BaseController
    {
        //
        // GET: /is_basvuru/
        public ActionResult listele()
        {

            if (Request.QueryString["sil"] != null)
            {
                int r_id = Convert.ToInt32(Request.QueryString["sil"]);

                try
                {
                    IS_BASVURULARI bsvr = data.IS_BASVURULARIs.First(f => f.ID == r_id);
                    data.IS_BASVURULARIs.DeleteOnSubmit(bsvr);

                    data.SubmitChanges();


                    mesaj[0] = "alert-info"; mesaj[1] = "İş başvurusu başarıyla silindi..";
                    ViewBag.mesaj = mesaj;

                }
                catch
                {
                    mesaj[0] = "alert-error"; mesaj[1] = "Silme işlemi sırasında gata oluştu !";
                    ViewBag.mesaj = mesaj;
                }
            }





            ViewBag.formlar = data.IS_BASVURULARIs;
            return View();
        }
	}
}