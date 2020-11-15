using FDMSWeb.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
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

        public ActionResult Register()
        {
            if (Session["User"] == null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string username, string password, string fullname, string email)
        {
            if (ModelState.IsValid)
            {
                AnimeListDAO dao = new AnimeListDAO();
                bool status = dao.Register(username, password, fullname, email);
                if (status)
                {
                    return RedirectToAction("Login", "Authentication");


                }

            }
            return RedirectToAction("Register", "Authentication");

        }

        public ActionResult UserInfo(string userID)
        {
            if (Session["User"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }
        public ActionResult EditUserInfo(string userID)
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateUserInfo(string id, string fullname, string email, string gender, HttpPostedFileBase file)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");

            }
            Account account = (Account)Session["User"];

            string avatar = account.Avatar;
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(HostingEnvironment.MapPath("~/Content/Images/users"),
                Path.GetFileName(file.FileName));
                file.SaveAs(path);
                avatar = file.FileName;
            }
            AnimeListDAO dao = new AnimeListDAO();
            bool status = dao.UpdateUserInfo(id, fullname, email, gender, avatar);
            if (status)
            {
                account.FullName = fullname;
                account.Avatar = avatar;
                account.Email = email;
                Session.Add("User", account);
            }
            return RedirectToAction("UserInfo", "Authentication");
        }
        public ActionResult ChangePassword()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");

            }
            return View();
        }


        [HttpPost]
        public ActionResult ChangePassword(string password)
        {
            Account account = (Account)Session["User"];

            int id = account.Id;
            System.Diagnostics.Debug.WriteLine(id);
            AnimeListDAO dao = new AnimeListDAO();
            bool status = dao.changePassword(id+"", password);

            return RedirectToAction("UserInfo", "Authentication");
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
