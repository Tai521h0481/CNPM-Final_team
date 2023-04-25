using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_Server;
namespace Winform_Final
/*
 database: 
    /*
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

{
    public partial class AgentOrder : Form
    {
        public AgentOrder()
        {
            InitializeComponent();
        }

        private void orderAndPayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dtGVProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void showProduct()
        {
            DataTable products = API.ShowAllProducts();
            dtGVProduct.DataSource = products;
        }
        private void AgentForm_Load(object sender, EventArgs e)
        {
            showProduct();
            btnDelete.Enabled = false;
        }

        private void dtGVProduct_Click(object sender, EventArgs e)
        {
            
        }
        public void createColumn()
        {
            //tạo cột cho dataGVOrder
            dtGVODetail.ColumnCount = 5;
            dtGVODetail.Columns[0].Name = "Product ID";
            dtGVODetail.Columns[1].Name = "Product Name";
            dtGVODetail.Columns[2].Name = "Price";
            dtGVODetail.Columns[3].Name = "Amount";
            dtGVODetail.Columns[4].Name = "Total";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // khi ấn Add kiểm tra txtAmount > 0, và dataGVProduct có hàng được chọn
            if (dtGVProduct.CurrentRow.Index != dtGVProduct.RowCount - 1 && txtAmount.Text != "")
            {
                // lấy cột 0 khi click vào hàng
                string id = dtGVProduct.CurrentRow.Cells[0].Value.ToString();
                string name = dtGVProduct.CurrentRow.Cells[1].Value.ToString();
                string price = dtGVProduct.CurrentRow.Cells[2].Value.ToString();
                string amount = txtAmount.Text;
                string total = (int.Parse(price) * int.Parse(amount)).ToString();
                // kiểm tra hàng đã tồn tại trong dataGVOrder chưa, nếu có mà vẫn thêm thì tăng thêm số lượng
                if (dtGVODetail.Rows.Count > 0)
                {
                    bool isExist = false;
                    foreach (DataGridViewRow row in dtGVODetail.Rows)
                    {
                      
                        if (row.Cells[0]?.Value != null && row.Cells[0].Value.ToString().Equals(id))
                        {
                            isExist = true;
                            row.Cells[3].Value = (int.Parse(row.Cells[3].Value.ToString()) + int.Parse(amount)).ToString();
                            row.Cells[4].Value = (int.Parse(row.Cells[4].Value.ToString()) + int.Parse(total)).ToString();
                            break;
                        }
                    }
                    if (isExist == false)
                    {
                        createColumn();
                        // thêm hàng vào dataGVOrder
                        dtGVODetail.Rows.Add(id, name, price, amount, total);
                    }
                    // cập nhật tổng tiền mỗi khi dtGVDetail được thêm từ Product
                    int sum = 0;
                    foreach (DataGridViewRow row in dtGVODetail.Rows)
                    {
                        if (row.Cells[4]?.Value != null)
                        {
                            sum += int.Parse(row.Cells[4].Value.ToString());
                        }
                    }
                    txtTotal.Text = sum.ToString();
                }
                
                else
                {
                    createColumn();
                    // thêm hàng vào dataGVOrder
                    dtGVODetail.Rows.Add(id, name, price, amount, total);
                    // cập nhật tổng tiền mỗi khi dtGVDetail được thêm từ Product
                    int sum = 0;
                    foreach (DataGridViewRow row in dtGVODetail.Rows)
                    {
                        if (row.Cells[4]?.Value != null)
                        {
                            sum += int.Parse(row.Cells[4].Value.ToString());
                        }
                    }
                    txtTotal.Text = sum.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please select a product and enter the amount!");
            }
        }

        private void dtGVODetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtGVODetail_Click(object sender, EventArgs e)
        {
            // cho phép click và xóa hàng trong dataGVOrder, cập nhât tổng tiền sau khi xóa
            btnDelete.Enabled = true;
        }
        private void showOrder()
        {
            DataTable orders = API.ShowAllOrders();
            dtGVOrder.DataSource = orders;
        }
        private void btnConFirm_Click(object sender, EventArgs e)
        {
            // khi ấn Confirm cập nhật lại số lượng hàng trong kho và tạo đơn hàng
            if (dtGVODetail.Rows.Count > 0)
            {
                // hiện thông báo xác nhận
                DialogResult dialogResult = MessageBox.Show("Are you sure to confirm this order?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string agentID = API.GetAgentID();
                    // tạo đơn hàng CreateOrderReceipt(int totalOrderPrice, int totalOrderQuantity, string orderedDate, string agentID)
                    int totalOrderPrice = int.Parse(txtTotal.Text);
                    // totalOrderQuantity = tổng số lượng hàng trong đơn hàng
                    int totalOrderQuantity = 0;
                    foreach (DataGridViewRow row in dtGVODetail.Rows)
                    {
                        if (row.Cells[3]?.Value != null)
                        {
                            totalOrderQuantity += int.Parse(row.Cells[3].Value.ToString());
                        }
                    }
                    string orderedDate = DateTime.Now.ToString("yyyy-MM-dd");
                    int orderID = API.CreateOrderReceipt(totalOrderPrice, totalOrderQuantity, orderedDate, agentID);
                    // hiện đơn hàng lên dataGVOrder
                    showOrder();
                    // tạo chi tiết dơn hàng CreateIncludeOrderProducts(string productID, int totalProductQuantity, int totalProductPrice, int orderID)
                    foreach (DataGridViewRow row in dtGVODetail.Rows)
                    {
                        if (row.Index != dtGVODetail.RowCount - 1)
                        {
                            string id = row.Cells[0].Value.ToString();
                            int amount = int.Parse(row.Cells[3].Value.ToString());
                            int total = int.Parse(row.Cells[4].Value.ToString());
                            API.CreateIncludeOrderProducts(id, amount, total, orderID);
                        }
                    }

                    foreach (DataGridViewRow row in dtGVODetail.Rows)
                    {
                        if (row.Index != dtGVODetail.RowCount - 1)
                        {
                            string id = row.Cells[0].Value.ToString();
                            int amount = int.Parse(row.Cells[3].Value.ToString());
                            // lấy số lượng hàng trong kho
                            int quantity = API.GetQuantityByProductID(id);
                            // cập nhật số lượng hàng trong kho
                            API.UpdateQuantity(id, quantity - amount);
                            showProduct();
                        }
                    }
                    txtAmount.Text = "";
                    // xóa hàng trong dataGVOrder
                    dtGVODetail.Rows.Clear();
                    // cập nhật tổng tiền
                    txtTotal.Text = "0";
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                MessageBox.Show("Please add some products to the order list!");
            }
        }

        private void dtGVProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // lấy cột 0 khi chọn hàng
            string id = dtGVProduct.CurrentRow.Cells[0].Value.ToString();
            txtAmount.DataSource = API.GetQuantityByProductID(id);
        }

        private void dtGVProduct_Click_1(object sender, EventArgs e)
        {
            if (dtGVProduct.CurrentRow.Index != dtGVProduct.RowCount - 1)
            {
                txtAmount.Items.Clear();
                string id =  dtGVProduct.CurrentRow.Cells[0].Value.ToString();
                int amount = API.GetQuantityByProductID(id);
                for (int i = 1; i <= amount; i++)
                {
                    txtAmount.Items.Add(i);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtGVProduct.CurrentRow.Index != dtGVProduct.RowCount - 1)
            {
                dtGVODetail.Rows.RemoveAt(dtGVODetail.CurrentRow.Index);
                int sum = 0;
                foreach (DataGridViewRow row in dtGVODetail.Rows)
                {
                    int rowTotal;
                    if (int.TryParse(row.Cells[4].Value?.ToString(), out rowTotal))
                    {
                        sum += rowTotal;
                    }
                }
                txtTotal.Text = sum.ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // gọi form AgentPayment
            AgentPayment agentPayment = new AgentPayment();
            agentPayment.Show();
            this.Close();  
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            AgentView agentView = new AgentView();
            agentView.Show();
            this.Close();
        }
    }
}
