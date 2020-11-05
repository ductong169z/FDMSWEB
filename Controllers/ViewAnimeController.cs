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
            ViewBag.Anime = anime;
            ViewBag.Genres = dao.GetGenreList(anime.Id);
            ViewBag.Studios = dao.GetStudioList(anime.Id);

            foreach (var item in anime.Studios)
            {
                System.Diagnostics.Debug.WriteLine(item.Id);
                System.Diagnostics.Debug.WriteLine(item.Name);
                System.Diagnostics.Debug.WriteLine(item.Created_at);
            }
            System.Diagnostics.Debug.WriteLine("____________________");

            foreach (var item in ViewBag.Studios)
            {
                System.Diagnostics.Debug.WriteLine(item.Id);
                System.Diagnostics.Debug.WriteLine(item.Name);
                System.Diagnostics.Debug.WriteLine(item.Created_at);
            }

            foreach (var item in ViewBag.genres)
            {
                System.Diagnostics.Debug.WriteLine(item.Id);
                System.Diagnostics.Debug.WriteLine(item.Name);
                System.Diagnostics.Debug.WriteLine(item.Created_at);
            }

            ///* Check if user logged in to get user anime list */


            //List animeInList = null; // not null if there is anime in list

            //if (anime != null)
            //{

            //}

            return View();
        }
    }
}