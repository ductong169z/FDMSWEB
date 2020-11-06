using FDMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    public class ViewAnimeListController : Controller
    {
        public ActionResult ViewAnimeList(int accountId, int listStatus)
        {
            /* Instantiate DAO obj and interact with DB */
            AnimeListDAO dao = new AnimeListDAO();
            List<List> animeList = dao.GetAnimeList(accountId, listStatus);
            ViewBag.Anime = anime;
            ViewBag.Genres = anime.Genres;
            ViewBag.Studios = anime.Studios;

            ///* Check if user logged in to get user anime list */


            //List animeInList = null; // not null if there is anime in list

            //if (anime != null)
            //{

            //}

            return View();
        }
    }
}