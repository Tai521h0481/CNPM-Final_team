using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderItemsWeb.Controllers
{
    public class DistributorController : Controller
    {
        // GET: Distributor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoodRecived()
        {
            return View();
        }

        public ActionResult GoodDelivery()
        {
            return View();
        }
        public ActionResult GoodView()
        {
            return View();
        }
    }
}