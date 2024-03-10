namespace JCCPurchasing.Controls
{
    partial class ctlPurchaseOrdersListBySupplierReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.txtJobNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblJobNumber = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(141, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(54, 27);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(84, 57);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Properties.MaxLength = 5;
            this.txtJobNumber.Size = new System.Drawing.Size(68, 20);
            this.txtJobNumber.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 125);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(172, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Enter a Job Number for the POs List";
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Location = new System.Drawing.Point(17, 60);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(61, 13);
            this.lblJobNumber.TabIndex = 11;
            this.lblJobNumber.Text = "Job Number:";
            // 
            // ctlPurchaseOrdersListBySupplierReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtJobNumber);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblJobNumber);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlPurchaseOrdersListBySupplierReport";
            this.Size = new System.Drawing.Size(207, 263);
            ((System.ComponentModel.ISupportInitialize)(this.txtJobNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.TextEdit txtJobNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblJobNumber;
    }
}
