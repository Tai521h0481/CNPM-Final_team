using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

/*
 * database
 * CREATE TABLE WarehouseReceipt
(
  ReceiptID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  TotalWarehouseQuantity INT NOT NULL,
  TotalWarehousePrice INT NOT NULL,
  CreatedDate DATE NOT NULL
);

CREATE TABLE Product
(
  ProductID VARCHAR(10) NOT NULL PRIMARY KEY,
  ProductName NVARCHAR(50) NOT NULL,
  ProductPrice INT NOT NULL,
  ProductQuantity INT NOT NULL
);

CREATE TABLE Agent
(
  AgentID VARCHAR(10) NOT NULL PRIMARY KEY,
  AgentName NVARCHAR(50) NOT NULL,
  AgentAccount NVARCHAR(50) NOT NULL,
  AgentPassword NVARCHAR(50) NOT NULL,
  AgentAddress NVARCHAR(100),
  AgentPhoneNumber NVARCHAR(20)
);

CREATE TABLE OrderReceipt
(
  OrderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  TotalOrderPrice INT NOT NULL,
  TotalOrderQuantity INT NOT NULL,
  OrderedDate DATE NOT NULL,
  Status NVARCHAR(50) NOT NULL,
  AgentID VARCHAR(10) NOT NULL,
  PaymentMethod NVARCHAR(50),
  PaymentStatus NVARCHAR(50),
  OrderStatus NVARCHAR(50),
  CONSTRAINT FkOrderReceipt_AgentID FOREIGN KEY (AgentID) REFERENCES Agent(AgentID) 
);

CREATE TABLE IncludeOrderProducts
(
  TotalProductQuantity INT NOT NULL,
  TotalProductPrice INT NOT NULL,
  OrderID INT NOT NULL,
  ProductID VARCHAR(10) NOT NULL,
  CONSTRAINT PkIncludeOrderProducts_OrderID_ProductID PRIMARY KEY (OrderID, ProductID),
  CONSTRAINT FkIncludeOrderProducts_OrderID FOREIGN KEY (OrderID) REFERENCES OrderReceipt(OrderID),
  CONSTRAINT FkIncludeOrderProducts_ProductID FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE IncludeImportedProducts
(
  TotalProductQuantity INT NOT NULL,
  TotalProductPrice INT NOT NULL,
  ReceiptID INT NOT NULL,
  ProductID VARCHAR(10) NOT NULL,
  CONSTRAINT PkIncludeImportedProducts PRIMARY KEY (ReceiptID, ProductID),
  CONSTRAINT FkIncludeImportedProducts_ReceiptID FOREIGN KEY (ReceiptID) REFERENCES WarehouseReceipt(ReceiptID),
  CONSTRAINT FkIncludeImportedProducts_ProductID FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE Distributor
(
  DistributorID VARCHAR(10) NOT NULL PRIMARY KEY,
  DistributorAccount NVARCHAR(50) NOT NULL,
  DistributorPassword NVARCHAR(50) NOT NULL
);

CREATE TABLE StockReport
(
  ReportID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  ReportDate DATE NOT NULL,
  IncomingStock INT NOT NULL,
  OutgoingStock INT NOT NULL
);

CREATE TABLE BestSellingProduct
(
  ProductID VARCHAR(10) NOT NULL PRIMARY KEY,
  ProductName NVARCHAR(50) NOT NULL,
  TotalSales INT NOT NULL,
  CONSTRAINT FkBestSellingProduct_ProductID FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE RevenueReport
(
  ReportID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  ReportMonth INT NOT NULL,
  ReportYear INT NOT NULL,
  TotalRevenue INT NOT NULL
);
 */

namespace DAL_Server
{
    public class API
    {
        // kiểm tra login with distributor
        public static bool CheckLoginWithDistributor(string distributorAccount, string distributorPassword)
        {
            string sql = "SELECT * FROM Distributor WHERE DistributorAccount = '" + distributorAccount + "' AND DistributorPassword = '" + distributorPassword + "'";
            DataTable dt = Connection.SelectQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        // kiểm tra login with agent
        private static DataTable Agent;
        public static bool CheckLoginWithAgent(string agentAccount, string agentPassword)
        {
            string sql = "SELECT * FROM Agent WHERE AgentAccount = '" + agentAccount + "' AND AgentPassword = '" + agentPassword + "'";
            DataTable dt = Connection.SelectQuery(sql);
            Agent = dt;
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static string GetAgentID()
        {
            // nếu khác null
            if (Agent != null)
            {
                return Agent.Rows[0][0].ToString();
            }
            return "";
        }
        // show tất cả sản phẩm
        public static DataTable ShowAllProducts()
        {
            string sql = "SELECT * FROM Product";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }
        public static DataTable ShowAllOrders()
        {
            string sql = "SELECT * FROM OrderReceipt";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }   
        // lấy số lượng sản phẩm còn lại bằng productID
        public static int GetQuantityByProductID(string productID)
        {
            string sql = "SELECT ProductQuantity FROM Product WHERE ProductID = '" + productID + "'";
            DataTable dt = Connection.SelectQuery(sql);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        // tạo includeOrderProducts
        public static void CreateIncludeOrderProducts(string productID, int totalProductQuantity, int totalProductPrice, int orderID)
        {
            string sql = "INSERT INTO IncludeOrderProducts VALUES (" + totalProductQuantity + ", " + totalProductPrice + ", " + orderID + ", '" + productID + "')";
            Connection.ActionQuery(sql);
        }
        // tạo UpdateQuantity(productID, int.Parse(amounts));
        public static void UpdateQuantity(string productID, int quantity)
        {
            string sql = "UPDATE Product SET ProductQuantity = " + quantity + " WHERE ProductID = '" + productID + "'";
            Connection.ActionQuery(sql);
        }
        // tạo OrderReceipt và trả về orderID
        public static int CreateOrderReceipt(int totalOrderPrice, int totalOrderQuantity, string orderedDate, string agentID)
        {
            string status = "";
            string paymentMethod = "";
            string paymentStatus = "unpaid";
            string orderStatus = "processing"; 
            string sql = "INSERT INTO OrderReceipt VALUES (" + totalOrderPrice + ", " + totalOrderQuantity + ", '" + orderedDate + "', '" + status + "', '" + agentID + "', '" + paymentMethod + "', '" + paymentStatus + "', '" + orderStatus + "')";
            Connection.ActionQuery(sql);
            // lấy max của orderID
            string sql2 = "SELECT MAX(OrderID) FROM OrderReceipt";
            DataTable dt = Connection.SelectQuery(sql2);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        // hiện tất cả các đơn hàng của agent chưa thanh toán
        public static DataTable ShowAllUnpaidOrders()
        {
            string agentID = GetAgentID();
            string sql = "SELECT * FROM OrderReceipt WHERE AgentID = '" + agentID + "' AND PaymentStatus = 'unpaid'";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }
        // cập nhật trạng thái thanh toán và phương thức thanh toán
        public static void UpdatePaymentStatusAndPaymentMethod(int orderID, string paymentStatus, string paymentMethod)
        {
            string sql = "UPDATE OrderReceipt SET PaymentStatus = '" + paymentStatus + "', PaymentMethod = '" + paymentMethod + "' WHERE OrderID = " + orderID;
            Connection.ActionQuery(sql);
        }
        // hiện tất cả các đơn hàng của agent đã thanh toán và chưa thanh toán
        public static DataTable ShowAllOrdersWithPaymentStatus()
        {
            string agentID = GetAgentID();
            string sql = "SELECT * FROM OrderReceipt WHERE AgentID = '" + agentID + "'";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }
        public static string GetNewProductID()
        {
            string sql = "SELECT MAX(ProductID) FROM Product";
            DataTable dt = Connection.SelectQuery(sql);
            string maxProductID = dt.Rows[0][0].ToString();
            int newProductID = int.Parse(maxProductID.Substring(1)) + 1;
            return "P" + newProductID.ToString("D3");
        }
        // wareHouseReceipt dùng để nhập hàng theo ngày, nếu ngày nhập hàng đã tồn tại thì cập nhật số lượng, nếu chưa thì thêm mới. bảng này không có productID
        public static void CreateWareHouseReceipt(int totalProductQuantity, int totalProductPrice, string orderedDate)
        {
            // tạo mảng để lưu các ngày đã nhập hàng
            string[] orderedDates = new string[100];
            // lấy tất cả các ngày đã nhập hàng mà không xảy ra lỗi
            string sql = "select * from WareHouseReceipt";
            DataTable dt = Connection.SelectQuery(sql);
            // lấy ngày lưu vào rderedDates
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                orderedDates[i] = dt.Rows[i][3].ToString();
            }
            // kiểm tra ngày nhập hàng đã tồn tại chưa
            bool isExist = false;
            for (int i = 0; i < orderedDates.Length; i++)
            {
                if (orderedDates[i] == orderedDate)
                {
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                sql = "INSERT INTO WareHouseReceipt VALUES (" + totalProductQuantity + ", " + totalProductPrice + ", '" + orderedDate + "')";
                Connection.ActionQuery(sql);
                
            }
            else
            {
                sql = "select * from WareHouseReceipt where CreatedDate = '" + orderedDate + "'";
                dt = Connection.SelectQuery(sql);
                int oldTotalProductQuantity = int.Parse(dt.Rows[0][0].ToString());
                int oldTotalProductPrice = int.Parse(dt.Rows[0][1].ToString());
                int newTotalProductQuantity = oldTotalProductQuantity + totalProductQuantity;
                int newTotalProductPrice = oldTotalProductPrice + totalProductPrice;
                sql = "UPDATE WareHouseReceipt SET TotalProductQuantity = " + newTotalProductQuantity + ", TotalProductPrice = " + newTotalProductPrice + " WHERE CreatedDate = '" + orderedDate + "'";
                Connection.ActionQuery(sql);
            }
            
        }
        // lấy ReceiptID từ WareHouseReceipt theo ngày nhập hàng
        public static string GetReceiptIDFromWareHouseReceipt(string orderedDate)
        {
            string sql = "SELECT ReceiptID FROM WareHouseReceipt WHERE CreatedDate = '" + orderedDate + "'";
            DataTable dt = Connection.SelectQuery(sql);
            string ReceiptID = dt.Rows[0][0].ToString();
            return ReceiptID;
        }
        // tạo IncludeImportedProducts
        public static void CreateIncludeImportedProducts(int totalProductQuantity, int totalProductPrice, string ReceiptID, string productID)
        {
            string sql = "SELECT * FROM IncludeImportedProducts WHERE ProductID = '" + productID + "'";
            DataTable dt = Connection.SelectQuery(sql);
            if (dt != null)
            {
                int oldProductQuantity = int.Parse(dt.Rows[0][0].ToString());
                int oldProductPrice = int.Parse(dt.Rows[0][1].ToString());
                int newProductQuantity = oldProductQuantity + totalProductQuantity;
                int newProductPrice = oldProductPrice + totalProductPrice;
                sql = "UPDATE IncludeImportedProducts SET TotalProductQuantity = " + newProductQuantity + ", TotalProductPrice = " + newProductPrice + " WHERE ProductID = '" + productID + "'";
                Connection.ActionQuery(sql);
            }
            else
            {
                sql = "INSERT INTO IncludeImportedProducts VALUES (" + totalProductQuantity + ", " + totalProductPrice + ", '" + ReceiptID + "', '" + productID + "')";
                Connection.ActionQuery(sql);
            }
        }
        // thêm sản phẩm vào bảng Product hoặc cập nhật số lượng sản phẩm nếu đã tồn tại (ID, name, price, quantity)
        public static string AddOrUpdateProduct(string productID, string productName, int productPrice, int productQuantity)
        {
            string sql = "SELECT * FROM Product WHERE productName = '" + productName + "'";
            DataTable dt = Connection.SelectQuery(sql);
            if (dt != null)
            {
                int oldProductQuantity = int.Parse(dt.Rows[0][3].ToString());
                int newProductQuantity = oldProductQuantity + productQuantity;
                sql = "UPDATE Product SET ProductQuantity = " + newProductQuantity + " WHERE productID = '" + dt.Rows[0][0].ToString() + "'";
                Connection.ActionQuery(sql);
                return dt.Rows[0][0].ToString();
            }
            else
            {
                sql = "INSERT INTO Product VALUES ('" + productID + "', N'" + productName + "', " + productPrice + ", " + productQuantity + ")";
                Connection.ActionQuery(sql);
                return "";
            }
        }
        // update status của order là đã xác nhận, orderstatus là đang vận chuyển dựa vào orderID
        public static void UpdateOrderStatus(int orderID)
        {
            string sql = "UPDATE OrderReceipt SET status = 'confirmed', OrderStatus = 'being transferred' WHERE OrderID = " + orderID;
            Connection.ActionQuery(sql);
        }
        // lấy những order đã xác nhận
        public static DataTable GetConfirmedOrders()
        {
            string sql = "SELECT * FROM OrderReceipt WHERE status = 'confirmed'";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }
        public static DataTable GetStockReportByMonth(string month)
        {
            /*string sql = "SELECT YEAR(CreatedDate) AS Year, MONTH(CreatedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantityImported FROM IncludeImportedProducts JOIN WarehouseReceipt ON IncludeImportedProducts.ReceiptID = WarehouseReceipt.ReceiptID WHERE MONTH(CreatedDate) = " + month + "GROUP BY YEAR(CreatedDate), MONTH(CreatedDate), ProductID;";
            DataTable dt = Connection.SelectQuery(sql);
           
            sql = "SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantitySold FROM IncludeOrderProducts JOIN OrderReceipt ON IncludeOrderProducts.OrderID = OrderReceipt.OrderID WHERE MONTH(OrderedDate) = " + month +"GROUP By YEAR(OrderedDate), MONTH(OrderedDate), ProductID;";
            dt = Connection.SelectQuery(sql);*/
            string sql = "SELECT YEAR(CreatedDate) AS Year, MONTH(CreatedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantityImported, 0 AS TotalQuantitySold FROM IncludeImportedProducts JOIN WarehouseReceipt ON IncludeImportedProducts.ReceiptID = WarehouseReceipt.ReceiptID WHERE MONTH(CreatedDate) = " + month + " GROUP BY YEAR(CreatedDate), MONTH(CreatedDate), ProductID UNION SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month, ProductID, 0 AS TotalQuantityImported, SUM(TotalProductQuantity) AS TotalQuantitySold FROM IncludeOrderProducts JOIN OrderReceipt ON IncludeOrderProducts.OrderID = OrderReceipt.OrderID WHERE MONTH(OrderedDate) = "+month+" GROUP BY YEAR(OrderedDate), MONTH(OrderedDate), ProductID; ";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }
        public static DataTable GetBestSellingByMonth(string month)
        {
            string sql = "SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month, ProductID, SUM(TotalProductQuantity) AS TotalQuantitySold FROM IncludeOrderProducts JOIN OrderReceipt ON IncludeOrderProducts.OrderID = OrderReceipt.OrderID WHERE MONTH(OrderedDate) = "+month+" GROUP BY YEAR(OrderedDate), MONTH(OrderedDate), ProductID ORDER BY TotalQuantitySold DESC;";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }
        public static DataTable GetTotalRevenueByMonth(string month)
        {
            string sql = "SELECT YEAR(OrderedDate) AS Year, MONTH(OrderedDate) AS Month,SUM(TotalOrderPrice) AS TotalRevenue FROM OrderReceipt WHERE MONTH(OrderedDate) = " + month +"GROUP BY YEAR(OrderedDate), MONTH(OrderedDate);";
            DataTable dt = Connection.SelectQuery(sql);
            return dt;
        }
    }
}
