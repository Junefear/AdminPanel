using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPanel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{qweqw}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, qweqw = "mustafa arif" } // UrlParameter.Optional -> Opsiyonel olaiblir de olmayabilir de
            );

            routes.MapRoute(
                name: "Default2",
                url: "Yonetim/{controller}/{action}/{qwe1}/{qwe2}/{qwe3}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, qwe1 = UrlParameter.Optional, qwe2 = UrlParameter.Optional, qwe3 = UrlParameter.Optional } // UrlParameter.Optional -> Opsiyonel olaiblir de olmayabilir de
            );
            routes.MapRoute(
                name: "defauld3",
                url: "{controller}/{action}/{isim1}/{isim2}/{isim3}/{isim4}",
                defaults: new { Controller = "Medya", action = "Index", id = UrlParameter.Optional, isim1 = UrlParameter.Optional, isim2 = UrlParameter.Optional, isim3 = UrlParameter.Optional, isim4 = UrlParameter.Optional }
                );


        }
    }
}
