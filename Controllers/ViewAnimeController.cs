using FDMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    public class ViewAnimeController : Controller
    {
        public ActionResult ViewAnime(int id)
        {
            /* Instantiate DAO obj and interact with DB */
            AnimeListDAO dao = new AnimeListDAO();
            Anime anime = dao.GetAnime(id);
            dynamic animeModel = new System.Dynamic.ExpandoObject();
            animeModel.anime = anime;
            animeModel.genres = anime.Genres;
            animeModel.studios = anime.Studios;

            ///* Check if user logged in to get user anime list */


            //List animeInList = null; // not null if there is anime in list

            //if (anime != null)
            //{

            //}

            return View(animeModel);
        }
    }
}