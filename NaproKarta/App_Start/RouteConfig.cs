using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NaproKarta
{
   public class RouteConfig
   {
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            //defaults: new { controller = "Observation", action = "ObservationEdit", id=4} //,id = UrlParameter.Optional }
            defaults: new {controller = "User", action = "Chart", id = UrlParameter.Optional}
         );
      }
   }
}
