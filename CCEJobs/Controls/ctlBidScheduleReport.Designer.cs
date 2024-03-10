namespace CCEJobs.Controls
{
    partial class ctlBidScheduleReport
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
            this.lstJobStatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lblJobStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstJobStatus)).BeginInit();
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
            this.lblOffice.Location = new System.Drawing.Point(9, 43);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(33, 13);
            this.lblOffice.TabIndex = 1;
            this.lblOffice.Text = "Office:";
            // 
            // cboOffice
            // 
            this.cboOffice.Location = new System.Drawing.Point(52, 40);
            this.cboOffice.Name = "cboOffice";
            this.cboOffice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOffice.Properties.NullText = "";
            this.cboOffice.Size = new System.Drawing.Size(142, 20);
            this.cboOffice.TabIndex = 2;
            // 
            // lstJobStatus
            // 
            this.lstJobStatus.Location = new System.Drawing.Point(52, 66);
            this.lstJobStatus.Name = "lstJobStatus";
            this.lstJobStatus.Size = new System.Drawing.Size(138, 142);
            this.lstJobStatus.TabIndex = 3;
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.Location = new System.Drawing.Point(9, 62);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(35, 13);
            this.lblJobStatus.TabIndex = 4;
            this.lblJobStatus.Text = "Status:";
            // 
            // ctlBidScheduleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblJobStatus);
            this.Controls.Add(this.lstJobStatus);
            this.Controls.Add(this.cboOffice);
            this.Controls.Add(this.lblOffice);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlBidScheduleReport";
            this.Size = new System.Drawing.Size(207, 263);
            this.Load += new System.EventHandler(this.ctlBidScheduleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstJobStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblOffice;
        private DevExpress.XtraEditors.LookUpEdit cboOffice;
        private DevExpress.XtraEditors.CheckedListBoxControl lstJobStatus;
        private DevExpress.XtraEditors.LabelControl lblJobStatus;
    }
}
