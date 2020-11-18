using FDMSWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FDMSWeb
{
    /// <summary>
    /// Class for MVC Global
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Register filters, bundles and routes upon start
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Catch 404 errors
        /// </summary>
        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();

                var rd = new RouteData();
                rd.Values["controller"] = "Error";
                rd.Values["action"] = "NotFoundError";

                IController c = new ErrorController();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
        }

    }
}
