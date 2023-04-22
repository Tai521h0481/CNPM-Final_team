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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        private bool check()
        {
            if (txtMonth.Text == "")
            {
                MessageBox.Show("Please enter month");
                return false;
            }
            return true;
        }
        private void btnIO_Click(object sender, EventArgs e)
        {
            if (check()) {
                dataGridView1.DataSource = API.GetStockReportByMonth(txtMonth.Text);
            }
        }

        private void btnBest_Click(object sender, EventArgs e)
        {
            if (check()) {
                dataGridView1.DataSource = API.GetBestSellingByMonth(txtMonth.Text);
            }
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            if (check()) {
                dataGridView1.DataSource = API.GetTotalRevenueByMonth(txtMonth.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void View_Load(object sender, EventArgs e)
        {

        }
    }
}
