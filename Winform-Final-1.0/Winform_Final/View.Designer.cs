namespace Winform_Final
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIO = new System.Windows.Forms.Button();
            this.txtMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBest = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // btnIO
            // 
            this.btnIO.Location = new System.Drawing.Point(80, 308);
            this.btnIO.Name = "btnIO";
            this.btnIO.Size = new System.Drawing.Size(114, 37);
            this.btnIO.TabIndex = 1;
            this.btnIO.Text = "Incoming/Outgoing";
            this.btnIO.UseVisualStyleBackColor = true;
            this.btnIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // txtMonth
            // 
            this.txtMonth.FormattingEnabled = true;
            this.txtMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.txtMonth.Location = new System.Drawing.Point(314, 255);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(172, 21);
            this.txtMonth.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Month :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(770, 206);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnBest
            // 
            this.btnBest.Location = new System.Drawing.Point(270, 308);
            this.btnBest.Name = "btnBest";
            this.btnBest.Size = new System.Drawing.Size(114, 37);
            this.btnBest.TabIndex = 7;
            this.btnBest.Text = "Best Selling";
            this.btnBest.UseVisualStyleBackColor = true;
            this.btnBest.Click += new System.EventHandler(this.btnBest_Click);
            // 
            // btnRevenue
            // 
            this.btnRevenue.Location = new System.Drawing.Point(446, 308);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(114, 37);
            this.btnRevenue.TabIndex = 8;
            this.btnRevenue.Text = "Revenue";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(612, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 37);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 373);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRevenue);
            this.Controls.Add(this.btnBest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.btnIO);
            this.Controls.Add(this.groupBox1);
            this.Name = "View";
            this.Text = "View";
            this.Load += new System.EventHandler(this.View_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnIO;
        private System.Windows.Forms.ComboBox txtMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBest;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.Button btnCancel;
    }
}