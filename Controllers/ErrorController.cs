using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    /// <summary>
    /// Controller for errors
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Error 404 error
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFoundError()
        {
            ActionResult result; // store result action

            object model = Request.Url.PathAndQuery; // store current url

            /* Check if URL is valid, if not throw not found page */
            if (!Request.IsAjaxRequest())
                result = View(model);
            else
                result = PartialView("_NotFoundError", model);

            return result;
        }
    }
}