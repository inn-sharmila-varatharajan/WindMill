using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Windmill
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
			);

			routes.MapRoute(
	name: "Card",
	  url: "",
	defaults: new { controller = "Home", action = "Card", id = UrlParameter.Optional }
);

			routes.MapRoute(
	name: "Dashboard",
	  url: "",
	defaults: new { controller = "Home", action = "Dashboard", id = UrlParameter.Optional }
);

			routes.MapRoute(
name: "Report",
  url: "",
defaults: new { controller = "Home", action = "Report", id = UrlParameter.Optional }
);

		}
	}
}
