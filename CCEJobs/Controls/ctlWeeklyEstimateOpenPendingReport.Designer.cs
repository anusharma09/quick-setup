namespace CCEJobs.Controls
{
    partial class ctlWeeklyEstimateOpenPendingReport
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioReportType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.radioCompany = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioCompany.Properties)).BeginInit();
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
            this.lblEndDate.Location = new System.Drawing.Point(12, 39);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(78, 13);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "Week End Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.EditValue = new System.DateTime(2008, 8, 21, 15, 30, 33, 0);
            this.txtEndDate.Location = new System.Drawing.Point(93, 36);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEndDate.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.False;
            this.txtEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtEndDate.Size = new System.Drawing.Size(96, 20);
            this.txtEndDate.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(120, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Select Week Ending Date";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(116, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "(Usually a Sunday Date)";
            // 
            // radioReportType
            // 
            this.radioReportType.EditValue = 0;
            this.radioReportType.Location = new System.Drawing.Point(31, 130);
            this.radioReportType.Name = "radioReportType";
            this.radioReportType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Open/Pending"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Open"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Pending")});
            this.radioReportType.Size = new System.Drawing.Size(110, 70);
            this.radioReportType.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 111);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Report Format:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 206);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(175, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Select Open/Pending for both status";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 225);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(105, 13);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Open for Open status";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(21, 244);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(129, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Pending for Pending status";
            // 
            // radioCompany
            // 
            this.radioCompany.EditValue = 0;
            this.radioCompany.Location = new System.Drawing.Point(25, 302);
            this.radioCompany.Name = "radioCompany";
            this.radioCompany.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "EMCOR")});
            this.radioCompany.Size = new System.Drawing.Size(158, 22);
            this.radioCompany.TabIndex = 14;
            this.radioCompany.Visible = false;
            // 
            // ctlWeeklyEstimateOpenPendingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioCompany);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.radioReportType);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlWeeklyEstimateOpenPendingReport";
            this.Size = new System.Drawing.Size(207, 328);
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioCompany.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.DateEdit txtEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radioReportType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.RadioGroup radioCompany;
    }
}
