namespace Winform_Final
{
    partial class AgentOrder
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGVProduct = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGVODetail = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtGVOrder = new System.Windows.Forms.DataGridView();
            this.txtAmount = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnConFirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProduct)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVODetail)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGVProduct);
            this.groupBox1.Location = new System.Drawing.Point(440, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 214);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product";
            // 
            // dtGVProduct
            // 
            this.dtGVProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVProduct.Location = new System.Drawing.Point(3, 16);
            this.dtGVProduct.Name = "dtGVProduct";
            this.dtGVProduct.Size = new System.Drawing.Size(442, 195);
            this.dtGVProduct.TabIndex = 2;
            this.dtGVProduct.Click += new System.EventHandler(this.dtGVProduct_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGVODetail);
            this.groupBox2.Location = new System.Drawing.Point(12, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 226);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Detail";
            // 
            // dtGVODetail
            // 
            this.dtGVODetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVODetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVODetail.Location = new System.Drawing.Point(3, 16);
            this.dtGVODetail.Name = "dtGVODetail";
            this.dtGVODetail.Size = new System.Drawing.Size(563, 207);
            this.dtGVODetail.TabIndex = 0;
            this.dtGVODetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVODetail_CellContentClick);
            this.dtGVODetail.Click += new System.EventHandler(this.dtGVODetail_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtGVOrder);
            this.groupBox3.Location = new System.Drawing.Point(587, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 226);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order";
            // 
            // dtGVOrder
            // 
            this.dtGVOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGVOrder.Location = new System.Drawing.Point(3, 16);
            this.dtGVOrder.Name = "dtGVOrder";
            this.dtGVOrder.Size = new System.Drawing.Size(298, 207);
            this.dtGVOrder.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.FormattingEnabled = true;
            this.txtAmount.Location = new System.Drawing.Point(173, 109);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(181, 21);
            this.txtAmount.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 203);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(173, 203);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnConFirm
            // 
            this.btnConFirm.Location = new System.Drawing.Point(310, 203);
            this.btnConFirm.Name = "btnConFirm";
            this.btnConFirm.Size = new System.Drawing.Size(75, 23);
            this.btnConFirm.TabIndex = 6;
            this.btnConFirm.Text = "Confirm";
            this.btnConFirm.UseVisualStyleBackColor = true;
            this.btnConFirm.Click += new System.EventHandler(this.btnConFirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total :";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(452, 245);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(129, 20);
            this.txtTotal.TabIndex = 9;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(51, 28);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(111, 29);
            this.btnPay.TabIndex = 10;
            this.btnPay.Text = "Go to payment";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(274, 28);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(111, 29);
            this.btnView.TabIndex = 11;
            this.btnView.Text = "View order status";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // AgentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 500);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConFirm);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AgentOrder";
            this.Text = "AgentForm";
            this.Load += new System.EventHandler(this.AgentForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVProduct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVODetail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGVProduct;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGVODetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtGVOrder;
        private System.Windows.Forms.ComboBox txtAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnConFirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnView;
    }
}