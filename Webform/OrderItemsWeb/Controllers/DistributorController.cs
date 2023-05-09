using OrderItemsWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
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
        public ActionResult In_Out()
        {
            return View();
        }
        public ActionResult BestSelling()
        {
            string sql = "SELECT TOP 5 TotalProductQuantity, ProductID, TotalProductPrice FROM (SELECT ProductID, SUM(TotalProductPrice) AS TotalProductPrice, SUM(TotalProductQuantity) AS TotalProductQuantity FROM IncludeOrderProducts";
            sql += " GROUP BY ProductID) Best_Selling_Product ORDER BY TotalProductQuantity DESC";
            var result = db.Database.SqlQuery<BestSellingProduct>(sql).ToList();
            return View(result);
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
        [HttpPost]
        public ActionResult Show_In_Out(int month)
        {
            string sql = "SELECT YEAR(CreatedDate) AS Year, MONTH(CreatedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantityImported, 0 AS TotalQuantitySold FROM IncludeImportedProducts JOIN WarehouseReceipt ON IncludeImportedProducts.ReceiptID = WarehouseReceipt.ReceiptID WHERE MONTH(CreatedDate) = " + month + " GROUP BY YEAR(CreatedDate), MONTH(CreatedDate), ProductID UNION SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month, ProductID, 0 AS TotalQuantityImported, SUM(TotalProductQuantity) AS TotalQuantitySold FROM IncludeOrderProducts JOIN OrderReceipt ON IncludeOrderProducts.OrderID = OrderReceipt.OrderID WHERE MONTH(OrderedDate) = " + month + " GROUP BY YEAR(OrderedDate), MONTH(OrderedDate), ProductID;";
            var result = db.Database.SqlQuery(typeof(InOutProduct), sql).Cast<InOutProduct>().ToList();
            return View(result);
        }
        [HttpPost]
        public ActionResult ShowBSelling(int month)
        {
            string sql = "SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantitySold FROM IncludeOrderProducts JOIN OrderReceipt ON IncludeOrderProducts.OrderID = OrderReceipt.OrderID WHERE MONTH(OrderedDate) = " + month + " GROUP BY YEAR(OrderedDate), MONTH(OrderedDate), ProductID ORDER BY TotalQuantitySold DESC;";
            var result = db.Database.SqlQuery(typeof(BestSellingProduct), sql).Cast<BestSellingProduct>().ToList();
            return View(result);
        }
        public ActionResult Revenue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowRevenue(int month)
        {
            string sql = "SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month,SUM(TotalOrderPrice) AS TotalRevenue FROM OrderReceipt WHERE MONTH(OrderedDate) = " + month + "GROUP BY YEAR(OrderedDate), MONTH(OrderedDate);";
            var result = db.Database.SqlQuery(typeof(RevenueProduct), sql).Cast<RevenueProduct>().ToList();
            return View(result);
        }
    }
    public class BestSellingProduct
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string ProductID { get; set; }
        public int TotalQuantitySold { get; set; }
    }
    public class InOutProduct
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string ProductID { get; set; }
        public int TotalQuantityImported { get; set; }
        public int TotalQuantitySold { get; set; }
    }
    public class RevenueProduct
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalRevenue { get; set; }
    }
}