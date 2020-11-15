using FDMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    /// <summary>
    /// Controller class for Anime actions (CRUD)
    /// </summary>
    public class AnimeController : Controller
    {

        /// <summary>
        /// View an anime
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View Anime page or error page or log in page</returns>
        public ActionResult ViewAnime(int id)
        {
            /* Check if user logged in */
            if (Session["User"] != null)
            {
                List<List> animeList = null; // store anime list of user
                List animeInList = null; // store anime if anime is in list of user

                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                Anime anime = dao.GetAnime(id);
                animeList = dao.GetAnimeList((Session["User"] as Account).Id, 0);

                /* If anime exists */
                if (anime != null)
                {
                    /* Set values to ViewBag */
                    ViewBag.Anime = anime;
                    ViewBag.Genres = anime.Genres;
                    ViewBag.Studios = anime.Studios;

                    /* If user has anime list */
                    if (animeList != null)
                    {
                        /* Iterate to check if the anime in view is in list of user */
                        foreach (List listAnime in animeList)
                        {
                            if (listAnime.AnimeId == id)
                            {
                                animeInList = listAnime;
                            }
                        }
                    }
                }
                else
                {
                    return View("~/Views/Error/NotFoundError.cshtml");
                }

                ViewBag.AnimeInList = animeInList;

                /* Create status list array */
                List<String> statusList = new List<String>();
                statusList.Add("Currently Watching");
                statusList.Add("Completed");
                statusList.Add("On Hold");
                statusList.Add("Dropped");
                statusList.Add("Plan to Watch");

                ViewBag.StatusList = statusList;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        /// <summary>
        /// View anime list of user
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="listStatus"></param>
        /// <returns>View Anime List page or log in page</returns>
        public ActionResult ViewAnimeList(int accountId, int listStatus)
        {
            /* Check if user logged in*/
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                string accountUsername = dao.GetAccountUsername(accountId);
                List<List> animeList = dao.GetAnimeList(accountId, listStatus);
                List<Anime> animeDetailList = dao.GetAnimeDetailList(animeList);

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

                /* Set values to ViewBag to display */
                ViewBag.AccountUsername = accountUsername;
                ViewBag.AccountId = accountId;
                ViewBag.AnimeList = animeList;
                ViewBag.AnimeDetailList = animeDetailList;
                ViewBag.ListStatus = listStatus;
                ViewBag.StatusList = statusList;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        /// <summary>
        /// Edit or remove anime in list (in ViewAnimeList page)
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="episode"></param>
        /// <param name="status"></param>
        /// <param name="animeId"></param>
        /// <param name="accountId"></param>
        /// <param name="btnAction"></param>
        /// <param name="listStatus"></param>
        /// <returns>View Anime List page or error page or log in page</returns>
        public ActionResult EditRemoveAnimeList(int progress, int episode, int status, int animeId, int accountId, string btnAction, int listStatus)
        {
            /* Check if user logged in */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();

                /* Edit or Remove based on the button user presses */
                if (btnAction.Equals("Edit"))
                {
                    Boolean result = dao.EditAnimeInList(accountId, animeId, progress, episode, status);

                    /* If action failed, throw error page */
                    if (!result)
                    {
                        return View("~/Views/Error/InternalError.cshtml");
                    }
                }
                else if (btnAction.Equals("Remove"))
                {
                    Boolean result = dao.RemoveAnimeFromList(accountId, animeId);

                    /* If action failed, throw error page */
                    if (!result)
                    {
                        return View("~/Views/Error/InternalError.cshtml");
                    }
                }

                return RedirectToAction("ViewAnimeList", "Anime", new { accountId = accountId, listStatus = listStatus });
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        /// <summary>
        /// Add, edit and remove anime in list (in ViewAnime page)
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="episode"></param>
        /// <param name="status"></param>
        /// <param name="animeId"></param>
        /// <param name="accountId"></param>
        /// <param name="btnAction"></param>
        /// <returns>View Anime page or error page or log in page</returns>
        public ActionResult AddRemoveAnimeList(int progress, int episode, int status, int animeId, int accountId, string btnAction)
        {
            /* Check if user logged in */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();

                /* Add, Edit or Remove based on the button user presses */
                if (btnAction.Equals("Add"))
                {
                    Boolean result = dao.AddAnimeToList(accountId, animeId, progress, episode, status);

                    /* If action failed, throw error page */
                    if (!result)
                    {
                        return View("~/Views/Error/InternalError.cshtml");
                    }
                }
                else if (btnAction.Equals("Edit"))
                {
                    Boolean result = dao.EditAnimeInList(accountId, animeId, progress, episode, status);

                    /* If action failed, throw error page */
                    if (!result)
                    {
                        return View("~/Views/Error/InternalError.cshtml");
                    }
                }
                else if (btnAction.Equals("Remove"))
                {
                    Boolean result = dao.RemoveAnimeFromList(accountId, animeId);

                    /* If action failed, throw error page */
                    if (!result)
                    {
                        return View("~/Views/Error/InternalError.cshtml");
                    }
                }


                return RedirectToAction("ViewAnime", "Anime", new { id = animeId });
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        /// <summary>
        /// View search result when user search in their list
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="listStatus"></param>
        /// <param name="searchValue"></param>
        /// <returns>View List Search Result page or log in page</returns>
        public ActionResult ViewListSearchResult(int accountId, int listStatus, string searchValue)
        {
            /* Check if user logged in */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                string accountUsername = dao.GetAccountUsername(accountId);
                List<List> animeList = dao.SearchAnimeInList(accountId, searchValue, listStatus);
                List<Anime> animeDetailList = dao.GetAnimeDetailList(animeList);

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

                /* Set values to ViewBag to display */
                ViewBag.AccountUsername = accountUsername;
                ViewBag.AccountId = accountId;
                ViewBag.ListStatus = listStatus;
                ViewBag.StatusList = statusList;
                ViewBag.SearchValue = searchValue;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        /// <summary>
        /// Edit or Remove anime in list (in ViewListSearchResult page)
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="episode"></param>
        /// <param name="status"></param>
        /// <param name="animeId"></param>
        /// <param name="accountId"></param>
        /// <param name="btnAction"></param>
        /// <param name="listStatus"></param>
        /// <param name="searchValue"></param>
        /// <returns>View List Search Result page or error page or log in page</returns>
        public ActionResult EditRemoveAnimeInSearchList(int progress, int episode, int status, int animeId, int accountId, string btnAction, int listStatus, string searchValue)
        {
            /* Check if user logged in */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();

                /* Edit or Remove based on the button user presses */
                if (btnAction.Equals("Edit"))
                {
                    Boolean result = dao.EditAnimeInList(accountId, animeId, progress, episode, status);

                    /* If action failed, throw error page */
                    if (!result)
                    {
                        return View("~/Views/Error/InternalError.cshtml");
                    }
                }
                else if (btnAction.Equals("Remove"))
                {
                    Boolean result = dao.RemoveAnimeFromList(accountId, animeId);

                    /* If action failed, throw error page */
                    if (!result)
                    {
                        return View("~/Views/Error/InternalError.cshtml");
                    }
                }

                return RedirectToAction("ViewListSearchResult", "Anime", new { accountId = accountId, searchValue = searchValue, listStatus = listStatus });
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        /// <summary>
        /// Show all animes
        /// </summary>
        /// <returns>Show All Animes page or login page</returns>
        public ActionResult ShowAll()
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
                List<Anime> listAnime = dao.GetAllAnimes();

                /* Set value to ViewBag to display */
                ViewBag.listAnime = listAnime;

                return View();
            }
        }
        public ActionResult ViewSearch()
        {
         List<string> types;
         List<Genre> genres;
         List<Studio> studios;
         List<Season> seasons;
            /* Check if user logged in */
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            else
            {

                AnimeListDAO dao = new AnimeListDAO();

                /* Get data from Database */
                types = dao.GetAllTypes();
                ViewData["types"] = types;

                genres = dao.GetAllGenres();
                ViewData["genres"] = genres;
                studios = dao.GetAllStudios();
                ViewData["studios"] = studios;
                seasons = dao.GetAllSeasons();
                ViewData["seasons"] = seasons;

                return View();
            }
        }

        public ActionResult SearchAnime(string animeSearchValue, string type, string studioID, string genreID, string seasonID)
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
                if (animeSearchValue == null || animeSearchValue.Equals(""))
                {
                    animeSearchValue = "%";
                }
                if (type == null || type.Equals(""))
                {
                    type = "%";
                }
                if (genreID == null || genreID.Equals(""))
                {
                    genreID = "%";
                }
                if (studioID == null || studioID.Equals(""))
                {
                    studioID = "%";
                }
                if (seasonID == null || seasonID.Equals(""))
                {
                    seasonID = "%";
                }
                List<Anime> listAnime = dao.getSearchAnime(animeSearchValue,type, studioID, genreID,seasonID);

                /* Set value to ViewBag to display */
                ViewBag.listAnime = listAnime;
                ViewBag.animeSearchValue = animeSearchValue;
                ViewBag.type = type;
                ViewBag.genreID = genreID;
                ViewBag.studioID = studioID;
                ViewBag.seasonID = seasonID;

                return View();
            }
        }

        /// <summary>
        /// Handles exceptions in controllers
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true; // mark exception as handled

            /* Throw internal error view */
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Error/InternalError.cshtml"
            };
        }

    }
}
