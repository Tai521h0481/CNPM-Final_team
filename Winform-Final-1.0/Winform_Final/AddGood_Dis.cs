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
{
    public partial class AddGood_Dis : Form
    {
        public AddGood_Dis()
        {
            InitializeComponent();
        }

        private void AddGood_Dis_Load(object sender, EventArgs e)
        {
            // hiện thị danh sách sản phẩm
            dtGV.DataSource = API.ShowAllProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // thêm sản phẩm
            if (txtName.Text == "" || txtPrice.Text == "" || txtQuan.Text == "")
            {
                MessageBox.Show("Please enter all information!");
            }
            else
            {
                string newProductID = API.GetNewProductID();
                string check = API.AddOrUpdateProduct(newProductID, txtName.Text, int.Parse(txtPrice.Text), int.Parse(txtQuan.Text));
                if(check != "")
                {
                    newProductID = check;
                }
                // CreateWareHouseReceipt(int totalProductQuantity, int totalProductPrice, string orderedDate)
                API.CreateWareHouseReceipt(int.Parse(txtQuan.Text), int.Parse(txtPrice.Text), DateTime.Now.ToString("yyyy-MM-dd"));
                string newReceiptID = API.GetReceiptIDFromWareHouseReceipt(DateTime.Now.ToString("yyyy-MM-dd"));
                // CreateIncludeImportedProducts(int totalProductQuantity, int totalProductPrice, string ReceiptID, string productID)
                API.CreateIncludeImportedProducts(int.Parse(txtQuan.Text), int.Parse(txtPrice.Text), newReceiptID, newProductID);
                dtGV.DataSource = API.ShowAllProducts();
            }
        }

        private void txtQuan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtQuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
