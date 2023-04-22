using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Final
{
    public partial class AgentMenu : Form
    {
        public AgentMenu()
        {
            InitializeComponent();
        }

        private void orderProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // gọi form AgentForm hiện bên trong
            AgentOrder agentForm = new AgentOrder();
            agentForm.Show();
            this.Hide();
            // nếu agentForm đóng thì hiện lại form này
            agentForm.FormClosed += (s, args) => this.Show();
        }

        private void payTheOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // gọi form AgentPayment hiện bên trong
            AgentPayment agentForm = new AgentPayment();
            agentForm.Show();
            this.Hide();
            agentForm.FormClosed += (s, args) => this.Show();
        }

        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gọi form AgentView
            AgentView agentForm = new AgentView();
            agentForm.Show();
            this.Hide();
            agentForm.FormClosed += (s, args) => this.Show();
        }
    }
}
