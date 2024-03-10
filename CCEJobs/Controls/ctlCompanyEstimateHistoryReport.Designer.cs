namespace CCEJobs.Controls
{
    partial class ctlCompanyEstimateHistoryReport
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
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.txtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.lblJobStatus = new DevExpress.XtraEditors.LabelControl();
            this.lstJobStatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkArchive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstJobStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArchive.Properties)).BeginInit();
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
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(4, 50);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(57, 13);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "As Of Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.EditValue = new System.DateTime(2008, 3, 3, 17, 7, 56, 126);
            this.txtEndDate.Location = new System.Drawing.Point(64, 47);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtEndDate.Size = new System.Drawing.Size(96, 20);
            this.txtEndDate.TabIndex = 5;
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.Location = new System.Drawing.Point(4, 139);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(35, 13);
            this.lblJobStatus.TabIndex = 359;
            this.lblJobStatus.Text = "Status:";
            // 
            // lstJobStatus
            // 
            this.lstJobStatus.Location = new System.Drawing.Point(51, 143);
            this.lstJobStatus.Name = "lstJobStatus";
            this.lstJobStatus.Size = new System.Drawing.Size(138, 142);
            this.lstJobStatus.TabIndex = 358;
            // 
            // chkArchive
            // 
            this.chkArchive.Location = new System.Drawing.Point(139, 73);
            this.chkArchive.Name = "chkArchive";
            this.chkArchive.Properties.Caption = "";
            this.chkArchive.Size = new System.Drawing.Size(21, 19);
            this.chkArchive.TabIndex = 360;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(109, 13);
            this.labelControl1.TabIndex = 361;
            this.labelControl1.Text = "Include Archived Est\'s:";
            // 
            // ctlCompanyEstimateReviewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.chkArchive);
            this.Controls.Add(this.lblJobStatus);
            this.Controls.Add(this.lstJobStatus);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlCompanyEstimateReviewReport";
            this.Size = new System.Drawing.Size(207, 314);
            this.Load += new System.EventHandler(this.ctlCompanyEstimateReviewReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstJobStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArchive.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.DateEdit txtEndDate;
        private DevExpress.XtraEditors.LabelControl lblJobStatus;
        private DevExpress.XtraEditors.CheckedListBoxControl lstJobStatus;
        private DevExpress.XtraEditors.CheckEdit chkArchive;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
