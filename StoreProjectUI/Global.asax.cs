using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StoreProjectUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }



        protected void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            //string culture = null;
            if (context.Request.UserLanguages != null && Request.UserLanguages.Length > 0)
            {
                //culture = Request.UserLanguages[0];
                CultureInfo cultureInfo = null;
                var userLanguages = HttpContext.Current.Request.UserLanguages;
                string langName = string.Empty;
                if (userLanguages != null && userLanguages.Any()) langName = userLanguages[0];
                switch (langName.ToLower().Substring(0, 2))
                {
                    case "en":
                        cultureInfo = new CultureInfo(langName);
                        break;
                    case "de":
                        cultureInfo = new CultureInfo(langName);
                        break;
                    default:
                        cultureInfo = new CultureInfo("fr-FR");
                        break;
                }

                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
        }
    }
}
