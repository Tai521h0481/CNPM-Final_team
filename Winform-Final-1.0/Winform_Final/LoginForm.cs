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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnDis_CheckedChanged(object sender, EventArgs e)
        {
            // only chosse one of the two
            if (btnDis.Checked == true)
            {
                btnAgent.Checked = false;
            }
        }

        private void btnAgent_CheckedChanged(object sender, EventArgs e)
        {
            // only chosse one of the two
            if (btnAgent.Checked == true)
            {
                btnDis.Checked = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please enter your username and password!");
            }
            else
            {
                // check if the user is distributor or agent
                if (btnDis.Checked == true)
                {
                    // check if the username and password is correct
                    if (API.CheckLoginWithDistributor(txtUser.Text, txtPass.Text) == true)
                    {
                        // open DistributorForm
                        DistributorForm disForm = new DistributorForm();
                        disForm.Show();
                        this.Hide();
                        disForm.FormClosed += (s, args) => this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect!");
                    }
                }
                else if (btnAgent.Checked == true)
                {
                    // check if the username and password is correct
                    if (API.CheckLoginWithAgent(txtUser.Text, txtPass.Text) == true)
                    {
                        // open AgentForm
                        AgentMenu agentForm = new AgentMenu();
                        agentForm.Show();
                        this.Hide();
               
                        agentForm.FormClosed += (s, args) => this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect!");
                    }
                }
                else
                {
                    MessageBox.Show("Please choose your role!");
                } 
                // reset the form
                txtUser.Text = "";
                txtPass.Text = "";
                btnDis.Checked = false;
                btnAgent.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
