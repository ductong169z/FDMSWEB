using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FDMSWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "View Anime",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ViewAnime", action = "ViewAnime", id = 2 }
            );

            routes.MapRoute(
                name: "View Anime List",
                url: "{controller}/{action}/accountId={accountId}&listStatus={listStatus}",
                defaults: new { controller = "ViewAnimeList", action = "ViewAnimeList", id = 3 }
            );
        }
    }
}
