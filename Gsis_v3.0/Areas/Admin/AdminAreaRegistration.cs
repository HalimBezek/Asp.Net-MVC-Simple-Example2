using System.Web.Mvc;

namespace Gsis.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {


            context.MapRoute(name: "Admin_1", url: "Admin/Giris", defaults: new { controller = "Giris", action = "giris", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Areas.Admin.Controllers" });
            context.MapRoute(name: "Admin_2", url: "Admin/Cikis", defaults: new { controller = "Giris", action = "cikis", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Areas.Admin.Controllers" });





            context.MapRoute(
                "Admin_0",
                "Admin/{controller}/{action}/{id}",
                new { controller = "A", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Areas.Admin.Controllers" });
        }
    }
}