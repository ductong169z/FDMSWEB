﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFoundError()
        {
            ActionResult result;

            object model = Request.Url.PathAndQuery;

            if (!Request.IsAjaxRequest())
                result = View(model);
            else
                result = PartialView("_NotFoundError", model);

            return result;
        }
    }
}