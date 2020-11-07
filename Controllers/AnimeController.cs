using FDMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    public class AnimeController : Controller
    {
        public ActionResult ViewAnime(int id)
        {
            /* Instantiate DAO obj and interact with DB */
            AnimeListDAO dao = new AnimeListDAO();
            Anime anime = dao.GetAnime(id);
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

        public ActionResult ViewAnimeList(int accountId, int listStatus)
        {
            /* Instantiate DAO obj and interact with DB */
            AnimeListDAO dao = new AnimeListDAO();
            string accountUsername = dao.GetAccountUsername(accountId);
            List<List> animeList = dao.GetAnimeList(accountId, listStatus);
            List<Anime> animeDetailList = dao.GetAnimeDetailList(animeList);

            /* Get status list if there is user logged in */


            /* If user whose list is viewed has their own anime list */
            if (animeList != null)
            {
                ViewBag.AnimeList = animeList;
                ViewBag.AnimeDetailList = animeDetailList;
            }
            else
            {
                ViewBag.AnimeList = new List<List>();
                ViewBag.AnimeDetailList = new List<Anime>();
            }

            /* Create status list array */
            List<String> statusList = new List<String>();
            statusList.Add("Currently Watching");
            statusList.Add("Completed");
            statusList.Add("On Hold");
            statusList.Add("Dropped");
            statusList.Add("Plan to Watch");

            ViewBag.AccountUsername = accountUsername;
            ViewBag.AccountId = accountId;
            ViewBag.AnimeList = animeList;
            ViewBag.AnimeDetailList = animeDetailList;
            ViewBag.ListStatus = listStatus;
            ViewBag.StatusList = statusList;

            return View();
        }

        public ActionResult EditRemoveAnimeList(int progressEdit, int episodeEdit, int statusEdit, int animeIdEdit, int accountIdEdit, string btnAction, int accountId, int listStatus)
        {
            /* Instantiate DAO obj and interact with DB */
            AnimeListDAO dao = new AnimeListDAO();

            if (btnAction.Equals("Edit"))
            {
                Boolean result = dao.EditAnimeInList(accountIdEdit, animeIdEdit, progressEdit, episodeEdit, statusEdit);
                
                if (!result)
                {
                    // return error page
                }
            }
            else if (btnAction.Equals("Delete"))
            {
                Boolean result = dao.RemoveAnimeFromList(accountIdEdit, animeIdEdit);
                
                if (!result)
                {
                    // return error page
                }
            }

            return RedirectToAction("ViewAnimeList", "Anime", new { accountId = accountId, listStatus = listStatus });
        }
    }
}