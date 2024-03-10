namespace CCEJobs.Controls
{
    partial class ctlAdHocReport
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
            this.lblReportFormat = new DevExpress.XtraEditors.LabelControl();
            this.cboReportFormat = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportFormat.Properties)).BeginInit();
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
            // lblReportFormat
            // 
            this.lblReportFormat.Location = new System.Drawing.Point(9, 43);
            this.lblReportFormat.Name = "lblReportFormat";
            this.lblReportFormat.Size = new System.Drawing.Size(74, 13);
            this.lblReportFormat.TabIndex = 1;
            this.lblReportFormat.Text = "Report Format:";
            // 
            // cboReportFormat
            // 
            this.cboReportFormat.EditValue = "Job List";
            this.cboReportFormat.Location = new System.Drawing.Point(25, 62);
            this.cboReportFormat.Name = "cboReportFormat";
            this.cboReportFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboReportFormat.Properties.Items.AddRange(new object[] {
            "Job List",
            "Bid Schedule",
            "Weekly Budget",
            "Weekly Estimate Successful",
            "Weekly Estimate No No Bid",
            "Weekly Estimate Open Pending",
            "Weekly New Job"});
            this.cboReportFormat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboReportFormat.Size = new System.Drawing.Size(170, 20);
            this.cboReportFormat.TabIndex = 2;
            // 
            // ctlAdHocReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboReportFormat);
            this.Controls.Add(this.lblReportFormat);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlAdHocReport";
            this.Size = new System.Drawing.Size(207, 263);
            ((System.ComponentModel.ISupportInitialize)(this.cboReportFormat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblReportFormat;
        private DevExpress.XtraEditors.ComboBoxEdit cboReportFormat;
    }
}
