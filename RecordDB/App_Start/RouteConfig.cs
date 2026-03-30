using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace RecordDB
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            // The route name (the 1st parameter) must be unique
            routes.MapPageRoute(string.Empty, "Default", "~/Default.aspx");

            routes.MapPageRoute(string.Empty, "GetRecord/{rid}", "~/RecordView.aspx");

            routes.MapPageRoute(string.Empty, "GetArtist/{show}", "~/Browse.aspx");

            routes.MapPageRoute(string.Empty, "UpdateRecord/{rid}", "~/EditRecord.aspx");
        }
    }
}
