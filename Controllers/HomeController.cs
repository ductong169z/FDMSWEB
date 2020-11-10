using FDMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    /// <summary>
    /// Controller to show index page
    /// </summary>
    public class HomeController : Controller
    {
      
        /// <summary>
        /// Show index page
        /// </summary>
        /// <returns>Index page or log in page</returns>
        public ActionResult Index()
        {
            /* Check if user logged in */
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                List<Anime> listAnime = dao.GetAnimes(12);

                /* Set value to ViewBag to display */
                ViewBag.listAnime = listAnime;

                return View();
            }
        }
    }
}