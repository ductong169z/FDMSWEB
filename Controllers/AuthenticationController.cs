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
        /// Check if user is logged in or not before go to Login page
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
        /// Check if user is logged in or not before go to Register page
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Register action
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="fullname"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string username, string password, string fullname, string email)
        {
            if (ModelState.IsValid)
            {
                /* Instantiate DAO obj and interact with DB */
                AnimeListDAO dao = new AnimeListDAO();
                bool status = dao.Register(username, password, fullname, email);

                // if successful
                if (status)
                {
                    return RedirectToAction("Login", "Authentication");
                }

            }
            return RedirectToAction("Register", "Authentication");

        }

        /// <summary>
        /// View user info action
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult UserInfo(string userID)
        {
            /* Check if user logged in */
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        /// <summary>
        /// Check if user logged in or not before go to Edit Info page
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult EditUserInfo(string userID)
        {
            /* Check if user logged in */
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }

            return View();
        }

        /// <summary>
        /// Update user info action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullname"></param>
        /// <param name="email"></param>
        /// <param name="gender"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateUserInfo(string id, string fullname, string email, string gender, HttpPostedFileBase file)
        {
            /* Check if user logged in */
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            Account account = (Account)Session["User"];

            string avatar = account.Avatar;
            if (file != null && file.ContentLength > 0)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");
                string extension = Path.GetExtension(file.FileName);
                avatar = GuidString + "." + extension;
                string path = Path.Combine(HostingEnvironment.MapPath("~/Content/Images/users"),
               avatar);
                file.SaveAs(path);
            }

            /* Instantiate DAO obj and interact with DB */
            AnimeListDAO dao = new AnimeListDAO();
            bool status = dao.UpdateUserInfo(id, fullname, email, gender, avatar);

            // if successful
            if (status)
            {
                /* Update current session account info */
                account.FullName = fullname;
                account.Avatar = avatar;
                account.Email = email;
                if (gender.Equals("1"))
                {
                    account.Gender = 1;
                }
                else if (gender.Equals("2"))
                {
                    account.Gender = 2;
                }
                else if (gender.Equals("3"))
                {
                    account.Gender = 3;
                }
                Session.Add("User", account);
            }
            return RedirectToAction("UserInfo", "Authentication");
        }

        /// <summary>
        /// Check if user is logged in or not before go to Change Password page
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            return View();
        }

        /// <summary>
        /// Change password action
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(string password)
        {

            Account account = (Account)Session["User"]; // get current session account
            int id = account.Id;

            /* Instantiate DAO obj and interact with DB */
            AnimeListDAO dao = new AnimeListDAO();
            bool status = dao.changePassword(id + "", password);

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
