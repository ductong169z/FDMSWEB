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

            ViewBag.AccountId = accountId;
            ViewBag.ListStatus = listStatus;

            return View();
        }
    }
}