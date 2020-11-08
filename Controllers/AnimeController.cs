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
            /* Check if user logged in to get user anime list */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                Anime anime = dao.GetAnime(id);
                List<List> animeList = null;
                List animeInList = null;


                animeList = dao.GetAnimeList((Session["User"] as Account).Id, 0);


                if (anime != null)
                {
                    ViewBag.Anime = anime;
                    ViewBag.Genres = anime.Genres;
                    ViewBag.Studios = anime.Studios;

                    if (animeList != null)
                    {
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
                    // throw error page
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

        public ActionResult ViewAnimeList(int accountId, int listStatus)
        {
            /* Check if user logged in to get user anime list */
            if (Session["User"] != null)
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
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        public ActionResult EditRemoveAnimeList(int progress, int episode, int status, int animeId, int accountId, string btnAction, int listStatus)
        {
            /* Check if user logged in to get user anime list */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();

            if (btnAction.Equals("Edit"))
            {
                Boolean result = dao.EditAnimeInList(accountId, animeId, progress, episode, status);

                if (!result)
                {
                    // return error page
                }
            }
            else if (btnAction.Equals("Remove"))
            {
                Boolean result = dao.RemoveAnimeFromList(accountId, animeId);

                if (!result)
                {
                    // return error page
                }
            }

            return RedirectToAction("ViewAnimeList", "Anime", new { accountId = accountId, listStatus = listStatus });
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        public ActionResult AddRemoveAnimeList(int progress, int episode, int status, int animeId, int accountId, string btnAction)
        {
            /* Check if user logged in to get user anime list */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
            if (btnAction.Equals("Add"))
            {
                Boolean result = dao.AddAnimeToList(accountId, animeId, progress, episode, status);

                if (!result)
                {
                    // return error page
                }
            }
            else if (btnAction.Equals("Edit"))
            {
                Boolean result = dao.EditAnimeInList(accountId, animeId, progress, episode, status);

                if (!result)
                {
                    // return error page
                }
            }
            else if (btnAction.Equals("Remove"))
            {
                Boolean result = dao.RemoveAnimeFromList(accountId, animeId);

                if (!result)
                {
                    // return error page
                }
            }


            return RedirectToAction("ViewAnime", "Anime", new { id = animeId });
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        public ActionResult SearchAnimeInList(int accountId, string searchValue, int listStatus)
        {
            /* Check if user logged in to get user anime list */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                List<List> animeList = dao.SearchAnimeInList(accountId, searchValue, listStatus);
                List<Anime> animeDetailList = dao.GetAnimeDetailList(animeList);

                /* If user whose list is viewed has their own anime list */
                if (animeList != null)
                {
                    TempData["AnimeList"] = animeList;
                    TempData["AnimeDetailList"] = animeDetailList;
                }
                else
                {
                    TempData["AnimeList"] = new List<List>();
                    TempData["AnimeDetailList"] = new List<Anime>();
                }

                /* Create status list array */
                List<String> statusList = new List<String>();
                statusList.Add("Currently Watching");
                statusList.Add("Completed");
                statusList.Add("On Hold");
                statusList.Add("Dropped");
                statusList.Add("Plan to Watch");

                TempData["AccountId"] = accountId;
                TempData["ListStatus"] = listStatus;
                TempData["StatusList"] = statusList;
                TempData["SearchValue"] = searchValue;

                return RedirectToAction("ViewListSearchResult", "Anime", new { accountId = accountId, listStatus = listStatus });
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        public ActionResult ViewListSearchResult(int accountId, int listStatus)
        {
            /* Check if user logged in to get user anime list */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();

                ViewBag.AccountId = TempData["AccountId"];
                ViewBag.AnimeList = TempData["AnimeList"];
                ViewBag.AnimeDetailList = TempData["AnimeDetailList"];
                ViewBag.ListStatus = TempData["ListStatus"];
                ViewBag.StatusList = TempData["StatusList"];
                ViewBag.SearchValue = TempData["SearchValue"];

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        public ActionResult EditRemoveAnimeInSearchList(int progress, int episode, int status, int animeId, int accountId, string btnAction, int listStatus, string searchValue)
        {
            /* Check if user logged in to get user anime list */
            if (Session["User"] != null)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();

                if (btnAction.Equals("Edit"))
                {
                    Boolean result = dao.EditAnimeInList(accountId, animeId, progress, episode, status);

                    if (!result)
                    {
                        // return error page
                    }
                }
                else if (btnAction.Equals("Remove"))
                {
                    Boolean result = dao.RemoveAnimeFromList(accountId, animeId);

                    if (!result)
                    {
                        // return error page
                    }
                }

                return RedirectToAction("SearchAnimeInList", "Anime", new { accountId = accountId, searchValue = searchValue, listStatus = listStatus });
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }
    }
}