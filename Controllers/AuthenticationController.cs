using FDMSWeb.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDMSWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            if (Session["User"] == null)
            {
                ViewBag.error = TempData["Error"];
                return View();

            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                AnimeListDAO dao = new AnimeListDAO();

               Account account = dao.login(username, password);
                if (account != null)
                {
                    Session.Add("User", account);
                    Session.Timeout = 120;
                    return RedirectToAction("Index", "Home");
                }

            }
            TempData["Error"] = "Username or passsword is incorrect !";
            return RedirectToAction("Login", "Authentication");

        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "Authentication");
        }
    }
}