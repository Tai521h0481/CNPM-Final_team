using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Principal;
using OrderItemsWeb.Models;

namespace OrderItemsWeb.Controllers
{
    public class LoginController : Controller
    {
        private DevConn db = new DevConn();
        // GET: Login
        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginForm(string username, string password, string role)
        {
            if (username.Any(c => char.IsPunctuation(c)) || username.Any(c => char.IsWhiteSpace(c)) || username.Any(c => char.IsSymbol(c)) || username.Any(c => char.IsLetterOrDigit(c)) == false)
            {
                ViewBag.Message = "Username must not contain special characters";
                return View();
            }
            if (role == "distributor")
            {
                var distributor = db.Distributors.Where(d => d.DistributorAccount == username && d.DistributorPassword == password).FirstOrDefault();
                if (distributor != null)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction("Index", "Distributor");
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();
                }
            }
            else if (role == "agent")
            {
                var agent = db.Agents.Where(a => a.AgentAccount == username && a.AgentPassword == password).FirstOrDefault();
                if (agent != null)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Choose Distributor or Agent";
                return View();
            }
        }
    }
}