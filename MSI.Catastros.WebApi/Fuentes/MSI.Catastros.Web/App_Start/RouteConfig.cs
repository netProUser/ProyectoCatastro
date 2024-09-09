using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSI.Catastros.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              "Informes",
              "{controller}/{action}/{id}/{extension}",
              new { controller = "Informes", action = "CargarImagenes", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              "Manzana",
              "{controller}/{action}/{sector}/{manzana}",
              new { controller = "Manzana", action = "Editar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "ManzanaVias",
                "{controller}/{action}/{id}/{sector}/{manzana}/{vias}",
                new { controller = "ManzanaVia", action = "Editar", id = UrlParameter.Optional }
            );
            
        }
    }
}
