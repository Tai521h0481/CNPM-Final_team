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
    public partial class AgentView : Form
    {
        public AgentView()
        {
            InitializeComponent();
        }

        private void AgentView_Load(object sender, EventArgs e)
        {
            // hiện tình trạng đơn hàng của agent đang đăng nhập
            dataGridView1.DataSource = API.ShowAllOrdersWithPaymentStatus();
        }
    }
}
