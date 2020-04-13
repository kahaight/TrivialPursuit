using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrivialPursuitMVC
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
                name: "InitiateGame",
                url: "GameVersion/InitiateGame/{id}",
                defaults: new { controller = "GameVersion", action = "Game" }
                );
                //        routes.MapRoute(
                //name: "SubmitAnswer",
                //url: "GameVersion/InitiateGame/{id}",
                //defaults: new { controller = "GameVersion", action = "Game" }
                //);
        }
    }
}
