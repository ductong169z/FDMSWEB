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
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "View Anime",
                url: "{action}/animeId={id}",
                defaults: new { controller = "Anime", action = "ViewAnime", id = 2 }
            );

            routes.MapRoute(
                name: "View Anime List",
                url: "{action}/accountId={accountId}&listStatus={listStatus}",
                defaults: new { controller = "Anime", action = "ViewAnimeList", id = 3 }
            );
        }
    }
}
