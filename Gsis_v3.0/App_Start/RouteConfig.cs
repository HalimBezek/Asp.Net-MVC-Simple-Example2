using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gsis
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(name: "s_1", url: "ana-sayfa", defaults: new { controller = "SiteHome", action = "Index", id = 1 }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_1a", url: "", defaults: new { controller = "SiteHome", action = "Index", id = 1 }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_2", url: "hakkimizda", defaults: new { controller = "hakkimizda", action = "Index", id = 2 }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_3", url: "galeri", defaults: new { controller = "galeri", action = "Index", id = 3 }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_4", url: "referanslarimiz", defaults: new { controller = "referanslar", action = "Index", id = 4 }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_5", url: "hizmetlerimiz", defaults: new { controller = "hizmetler", action = "Index", id = 5 }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_6", url: "haberler", defaults: new { controller = "haberler", action = "Index", id = 6 }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_6a", url: "h/{id}/{clr}", defaults: new { controller = "haberler", action = "detay", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_7", url: "iletisim", defaults: new { controller = "iletisim", action = "Index", id = 7 }, namespaces: new string[] { "Gsis.Controllers" });

            routes.MapRoute(name: "s_10", url: "beniara", defaults: new { controller = "iletisim", action = "beniara", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Controllers" });


            routes.MapRoute(name: "s_11", url: "duyurular", defaults: new { controller = "duyurular", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_11a", url: "d/{id}/{clr}", defaults: new { controller = "duyurular", action = "detay", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_12", url: "katilimci-gorusleri", defaults: new { controller = "Icerik", action = "gorusler", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Controllers" });
            routes.MapRoute(name: "s_13", url: "{id}/{clr}", defaults: new { controller = "Icerik", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Controllers" });


            routes.MapRoute(name: "s_Default", url: "{controller}/{action}/{id}", defaults: new { controller = "SiteHome", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "Gsis.Controllers" });
        }
    }
}
