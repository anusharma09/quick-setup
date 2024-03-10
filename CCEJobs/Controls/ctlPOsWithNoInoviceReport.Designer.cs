namespace CCEJobs.Controls
{
    partial class ctlPOsWithNoInvoiceReport
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
            this.lblOffice = new DevExpress.XtraEditors.LabelControl();
            this.cboOffice = new DevExpress.XtraEditors.LookUpEdit();
            this.lblJobStatus = new DevExpress.XtraEditors.LabelControl();
            this.cboDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.txtJobNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
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
            // lblOffice
            // 
            this.lblOffice.Location = new System.Drawing.Point(9, 40);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(33, 13);
            this.lblOffice.TabIndex = 1;
            this.lblOffice.Text = "Office:";
            // 
            // cboOffice
            // 
            this.cboOffice.Location = new System.Drawing.Point(74, 40);
            this.cboOffice.Name = "cboOffice";
            this.cboOffice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOffice.Properties.NullText = "";
            this.cboOffice.Size = new System.Drawing.Size(120, 20);
            this.cboOffice.TabIndex = 2;
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.Location = new System.Drawing.Point(9, 66);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(61, 13);
            this.lblJobStatus.TabIndex = 4;
            this.lblJobStatus.Text = "Department:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Location = new System.Drawing.Point(74, 66);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartment.Properties.NullText = "";
            this.cboDepartment.Size = new System.Drawing.Size(121, 20);
            this.cboDepartment.TabIndex = 5;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(74, 92);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(55, 20);
            this.txtJobNumber.TabIndex = 202;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 203;
            this.labelControl2.Text = "Job #:";
            // 
            // ctlPOsWithNoInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtJobNumber);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.lblJobStatus);
            this.Controls.Add(this.cboOffice);
            this.Controls.Add(this.lblOffice);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlPOsWithNoInvoiceReport";
            this.Size = new System.Drawing.Size(207, 263);
            this.Load += new System.EventHandler(this.ctlBidScheduleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJobNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblOffice;
        private DevExpress.XtraEditors.LookUpEdit cboOffice;
        private DevExpress.XtraEditors.LabelControl lblJobStatus;
        private DevExpress.XtraEditors.LookUpEdit cboDepartment;
        private DevExpress.XtraEditors.TextEdit txtJobNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
