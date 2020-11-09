using FDMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            AnimeListDAO dao = new AnimeListDAO();
            List<Anime> listAnime = dao.GetAllAnimes();
            ViewBag.listAnime = listAnime; List<Season> seasonList = dao.GetAllSeasons();
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                return View(seasonList);
            }
        }

        public ActionResult ViewAnime()
        {

            return View("~/Views/Anime/ViewAnime.cshtml");
        }

        public ActionResult ViewAnimeList()
        {

            return View("~/Views/Anime/ViewAnimeList.cshtml");
        }
    }
}