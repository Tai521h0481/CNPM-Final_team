using OrderItemsWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace OrderItemsWeb.Controllers
{
    public class DistributorController : Controller
    {
        // GET: Distributor
        private DevConn db = new DevConn();

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
            var orders = db.OrderReceipts.ToList();

            ViewBag.Agents = db.Agents.ToList();

            return View(orders);
        }
        public ActionResult GoodView()
        {
            return View();
        }
        public ActionResult Product()
        {
            var products = db.Products.ToList();

            return View(products);
        }

        public ActionResult ConfirmOrder(int id)
        {
            var order = db.OrderReceipts.Find(id);
            order.PaymentStatus = "paid";
            order.Status = "confirmed";
            order.OrderStatus = "being transferred";
            db.SaveChanges();
            return RedirectToAction("GoodDelivery");
        }
        public ActionResult IssueOrder()
        {
            var orders = db.OrderReceipts.Where(o => o.Status == "confirmed").ToList();
            return new Rotativa.ViewAsPdf("IssueOrder", orders)
            {
                FileName = "IssueOrder.pdf"
            };
        }

        [HttpPost]
        public ActionResult AddProduct(string name, string price, string quantity)
        {
            int parsedPrice;
            int parsedQuantity;
            if (!int.TryParse(price, out parsedPrice) || !int.TryParse(quantity, out parsedQuantity))
            {
                ViewBag.Message = "Invalid price or quantity value";
                return View("GoodRecived");
            }

            // Check if a product with the same name already exists in the database
            var existingProduct = db.Products.FirstOrDefault(p => p.ProductName.ToLower() == name.ToLower());
            if (existingProduct != null)
            {
                // Update the quantity of the existing product
                existingProduct.ProductQuantity += parsedQuantity;
            }
            else
            {
                var maxProductId = db.Products.Max(p => p.ProductID);

                // Increment the maximum product ID
                int newProductId = int.Parse(maxProductId.Substring(1)) + 1;

                // Generate a new product ID by adding the "P" prefix
                string newProductIdString = "P" + newProductId.ToString("D3");

                var product = new Product
                {
                    ProductID = newProductIdString,
                    ProductName = name,
                    ProductPrice = parsedPrice,
                    ProductQuantity = parsedQuantity
                };
                db.Products.Add(product);
            }

            db.SaveChanges();

            return RedirectToAction("Product");
        }
        public ActionResult In_Out()
        {
            return View();
        }
        public ActionResult BestSelling()
        {
            return View();
        }
        public ActionResult Revenue()
        {
            return View();
        }
    }
}