using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_Server;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Winform_Final
{
    public partial class DeliveryNote : Form
    {
        public DeliveryNote()
        {
            InitializeComponent();
        }

        private void DeliveryNote_Load(object sender, EventArgs e)
        {
            // hiện các order lên datagridview
            dataGridView1.DataSource = API.ShowAllOrders();
            btnCF.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != dataGridView1.RowCount - 1)
            {
                // lấy id của order
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                API.UpdateOrderStatus(id);
                dataGridView1.DataSource = API.ShowAllOrders();
            }
            else
            {
                MessageBox.Show("Please choose an Order");
            }
        }
        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            btnCF.Enabled = true;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            DataTable data = API.GetConfirmedOrders();
            // ghi data ra file pdf người dùng được chọn path để lưu
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "ConfirmedOrders.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a new PDF document
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                document.Open();

                // Create a new table with the same number of columns as the DataTable
                PdfPTable table = new PdfPTable(data.Columns.Count);

                // Add the column headers
                foreach (DataColumn column in data.Columns)
                {
                    table.AddCell(new Phrase(column.ColumnName));
                }

                // Add the data rows
                foreach (DataRow row in data.Rows)
                {
                    foreach (object cell in row.ItemArray)
                    {
                        table.AddCell(new Phrase(cell.ToString()));
                    }
                }

                // Add the table to the document
                document.Add(table);

                // Close the document
                document.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
