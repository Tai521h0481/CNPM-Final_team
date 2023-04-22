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
    public partial class DistributorForm : Form
    {
        public DistributorForm()
        {
            InitializeComponent();
        }

        private void goodRecivedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // gọi tới AddGood_Dis
            AddGood_Dis addGood = new AddGood_Dis();
            addGood.Show();
            this.Hide();
            addGood.FormClosed += (s, args) => this.Show();
        }

        private void deliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // gọi tới DeliveryNote
            DeliveryNote deliveryNote = new DeliveryNote();
            deliveryNote.Show();
            this.Hide();
            deliveryNote.FormClosed += (s, args) => this.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View view = new View();
            view.Show();
            this.Hide();
            view.FormClosed += (s, args) => this.Show();
        }
    }
}
