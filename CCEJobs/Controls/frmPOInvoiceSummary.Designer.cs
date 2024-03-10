namespace CCEJobs.Controls
{
    partial class frmPOInvoiceSummary
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtVendor = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceDate = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Invoice #:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Invoice Amount:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 103);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Invoice Date:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Vendor:";
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(140, 28);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Properties.ReadOnly = true;
            this.txtInvoiceNumber.Size = new System.Drawing.Size(106, 20);
            this.txtInvoiceNumber.TabIndex = 5;
            // 
            // txtVendor
            // 
            this.txtVendor.Location = new System.Drawing.Point(140, 54);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Properties.ReadOnly = true;
            this.txtVendor.Size = new System.Drawing.Size(106, 20);
            this.txtVendor.TabIndex = 6;
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.Location = new System.Drawing.Point(140, 80);
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Properties.ReadOnly = true;
            this.txtInvoiceAmount.Size = new System.Drawing.Size(106, 20);
            this.txtInvoiceAmount.TabIndex = 7;
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.Location = new System.Drawing.Point(140, 106);
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Properties.ReadOnly = true;
            this.txtInvoiceDate.Size = new System.Drawing.Size(106, 20);
            this.txtInvoiceDate.TabIndex = 8;
            // 
            // frmPOInvoiceSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Controls.Add(this.txtInvoiceDate);
            this.Controls.Add(this.txtInvoiceAmount);
            this.Controls.Add(this.txtVendor);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPOInvoiceSummary";
            this.Text = "Invoice Summary";
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtInvoiceNumber;
        private DevExpress.XtraEditors.TextEdit txtVendor;
        private DevExpress.XtraEditors.TextEdit txtInvoiceAmount;
        private DevExpress.XtraEditors.TextEdit txtInvoiceDate;
    }
}