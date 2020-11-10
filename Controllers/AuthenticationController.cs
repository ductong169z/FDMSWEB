using FDMSWeb.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    /// <summary>
    /// Controller for authentication-related actions
    /// </summary>
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        /// <summary>
        /// Check if user is logged in or not
        /// </summary>
        /// <returns>Login page or index page</returns>
        public ActionResult Login()
        {
            /* Check if user logged in */
            if (Session["User"] == null)
            {
                ViewBag.error = TempData["Error"];
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Login action
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Index or Login page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                Account account = dao.Login(username, password);

                /* Add user if account exists */
                if (account != null)
                {
                    Session.Add("User", account);
                    return RedirectToAction("Index", "Home");
                }
            }

            /* Request input again if account doesn't exist */
            TempData["Error"] = "Username or password is incorrect!";
            return RedirectToAction("Login", "Authentication");
        }

        /// <summary>
        /// Log out action
        /// </summary>
        /// <returns>Log in page</returns>
        public ActionResult Logout()
        {
            Session.RemoveAll(); // remove all sessions
            return RedirectToAction("Login", "Authentication");
        }
    }
}