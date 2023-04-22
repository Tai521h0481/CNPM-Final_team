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
    public partial class AgentPayment : Form
    {
        public AgentPayment()
        {
            InitializeComponent();
        }

        private void AgentPayment_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = API.ShowAllUnpaidOrders();
            btnOne.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(txtCash.Checked == true)
            {
                txtMomo.Checked = false;
                txtVNpay.Checked = false;
            }
        }

        private void txtMomo_CheckedChanged(object sender, EventArgs e)
        {
            if(txtMomo.Checked == true)
            {
                txtCash.Checked = false;
                txtVNpay.Checked = false;
            }
        }

        private void txtVNpay_CheckedChanged(object sender, EventArgs e)
        {
            if(txtVNpay.Checked == true)
            {
                txtCash.Checked = false;
                txtMomo.Checked = false;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            btnOne.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // đóng form này 
            this.Close();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.Index != dataGridView1.RowCount - 1) {
                if (txtCash.Checked == false && txtMomo.Checked == false && txtVNpay.Checked == false)
                {
                    MessageBox.Show("Please choose a payment method");
                }
                else
                {
                    // hiện thông báo tiền của hóa đơn đang chọn, nếu ấn Yes thì cập nhật trạng thái đã thanh toán và thanh toán bằng phương thức đã chọn
                    if (MessageBox.Show("The total amount of the order is: " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + " VND. Do you want to pay?", "Payment", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string paymentMethod = "";
                        if (txtCash.Checked == true)
                        {
                            paymentMethod = "Cash";
                        }
                        else if (txtMomo.Checked == true)
                        {
                            paymentMethod = "Momo";
                        }
                        else if (txtVNpay.Checked == true)
                        {
                            paymentMethod = "VNpay";
                        }
                        
                        // cập nhật trạng thái đã thanh toán và thanh toán bằng phương thức đã chọn UpdatePaymentStatusAndPaymentMethod(int orderID, string paymentStatus, string paymentMethod)
                        API.UpdatePaymentStatusAndPaymentMethod(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), "paid", paymentMethod);

                        MessageBox.Show("Payment successful");
                        dataGridView1.DataSource = API.ShowAllUnpaidOrders();
                    }
                }
            }
        }
    }
}
