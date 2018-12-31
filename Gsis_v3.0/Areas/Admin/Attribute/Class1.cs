using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gsis.Areas.Admin
{
    public class GirisKontrol : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["ID"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Giris");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
