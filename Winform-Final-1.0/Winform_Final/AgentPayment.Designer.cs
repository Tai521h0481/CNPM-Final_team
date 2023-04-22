namespace Winform_Final
{
    partial class AgentPayment
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.CheckBox();
            this.txtMomo = new System.Windows.Forms.CheckBox();
            this.txtVNpay = new System.Windows.Forms.CheckBox();
            this.btnOne = new System.Windows.Forms.Button();
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
            this.groupBox1.Size = new System.Drawing.Size(383, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(377, 214);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payment with :";
            // 
            // txtCash
            // 
            this.txtCash.AutoSize = true;
            this.txtCash.Location = new System.Drawing.Point(124, 268);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(50, 17);
            this.txtCash.TabIndex = 2;
            this.txtCash.Text = "Cash";
            this.txtCash.UseVisualStyleBackColor = true;
            this.txtCash.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtMomo
            // 
            this.txtMomo.AutoSize = true;
            this.txtMomo.Location = new System.Drawing.Point(198, 268);
            this.txtMomo.Name = "txtMomo";
            this.txtMomo.Size = new System.Drawing.Size(55, 17);
            this.txtMomo.TabIndex = 3;
            this.txtMomo.Text = "Momo";
            this.txtMomo.UseVisualStyleBackColor = true;
            this.txtMomo.CheckedChanged += new System.EventHandler(this.txtMomo_CheckedChanged);
            // 
            // txtVNpay
            // 
            this.txtVNpay.AutoSize = true;
            this.txtVNpay.Location = new System.Drawing.Point(275, 268);
            this.txtVNpay.Name = "txtVNpay";
            this.txtVNpay.Size = new System.Drawing.Size(62, 17);
            this.txtVNpay.TabIndex = 4;
            this.txtVNpay.Text = "VN Pay";
            this.txtVNpay.UseVisualStyleBackColor = true;
            this.txtVNpay.CheckedChanged += new System.EventHandler(this.txtVNpay_CheckedChanged);
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(54, 318);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(96, 40);
            this.btnOne.TabIndex = 6;
            this.btnOne.Text = "Pay";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AgentPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 379);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.txtVNpay);
            this.Controls.Add(this.txtMomo);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "AgentPayment";
            this.Text = "AgentPayment";
            this.Load += new System.EventHandler(this.AgentPayment_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox txtCash;
        private System.Windows.Forms.CheckBox txtMomo;
        private System.Windows.Forms.CheckBox txtVNpay;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnCancel;
    }
}