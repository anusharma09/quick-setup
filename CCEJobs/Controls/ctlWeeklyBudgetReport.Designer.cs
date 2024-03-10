namespace CCEJobs.Controls
{
    partial class ctlWeeklyBudgetReport
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
            this.radioReport = new DevExpress.XtraEditors.RadioGroup();
            this.radioReportType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.radioReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioReportType.Properties)).BeginInit();
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
            // radioReport
            // 
            this.radioReport.EditValue = 0;
            this.radioReport.Location = new System.Drawing.Point(14, 50);
            this.radioReport.Name = "radioReport";
            this.radioReport.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Over Million")});
            this.radioReport.Size = new System.Drawing.Size(158, 22);
            this.radioReport.TabIndex = 1;
            // 
            // radioReportType
            // 
            this.radioReportType.EditValue = 0;
            this.radioReportType.Location = new System.Drawing.Point(14, 87);
            this.radioReportType.Name = "radioReportType";
            this.radioReportType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "EMCOR")});
            this.radioReportType.Size = new System.Drawing.Size(158, 22);
            this.radioReportType.TabIndex = 2;
            // 
            // ctlWeeklyBudgetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioReportType);
            this.Controls.Add(this.radioReport);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlWeeklyBudgetReport";
            this.Size = new System.Drawing.Size(207, 263);
            ((System.ComponentModel.ISupportInitialize)(this.radioReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioReportType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.RadioGroup radioReport;
        private DevExpress.XtraEditors.RadioGroup radioReportType;
    }
}
