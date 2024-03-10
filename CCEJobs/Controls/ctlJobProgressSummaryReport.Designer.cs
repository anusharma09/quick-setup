namespace CCEJobs.Controls
{
    partial class ctlJobProgressSummaryReport
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
            this.lblPM = new DevExpress.XtraEditors.LabelControl();
            this.cboProjectManager = new DevExpress.XtraEditors.LookUpEdit();
            this.radioDataType = new DevExpress.XtraEditors.RadioGroup();
            this.cboPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPeriod = new DevExpress.XtraEditors.LabelControl();
            this.radioApproved = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkedReportList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.radioContractValue = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboOffice = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl129 = new DevExpress.XtraEditors.LabelControl();
            this.cboDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl127 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectManager.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioDataType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioApproved.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedReportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioContractValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
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
            // lblPM
            // 
            this.lblPM.Location = new System.Drawing.Point(7, 262);
            this.lblPM.Name = "lblPM";
            this.lblPM.Size = new System.Drawing.Size(83, 13);
            this.lblPM.TabIndex = 1;
            this.lblPM.Text = "Project Manager:";
            // 
            // cboProjectManager
            // 
            this.cboProjectManager.Location = new System.Drawing.Point(96, 259);
            this.cboProjectManager.Name = "cboProjectManager";
            this.cboProjectManager.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProjectManager.Properties.NullText = "";
            this.cboProjectManager.Size = new System.Drawing.Size(142, 20);
            this.cboProjectManager.TabIndex = 2;
            // 
            // radioDataType
            // 
            this.radioDataType.EditValue = 0;
            this.radioDataType.Location = new System.Drawing.Point(96, 36);
            this.radioDataType.Name = "radioDataType";
            this.radioDataType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Current Period"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Archived Period")});
            this.radioDataType.Size = new System.Drawing.Size(108, 62);
            this.radioDataType.TabIndex = 9;
            this.radioDataType.SelectedIndexChanged += new System.EventHandler(this.radioDataType_SelectedIndexChanged);
            // 
            // cboPeriod
            // 
            this.cboPeriod.Location = new System.Drawing.Point(96, 102);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPeriod.Properties.DisplayFormat.FormatString = "d";
            this.cboPeriod.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboPeriod.Properties.EditFormat.FormatString = "d";
            this.cboPeriod.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboPeriod.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.cboPeriod.Properties.NullText = " ";
            this.cboPeriod.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Flat;
            this.cboPeriod.Size = new System.Drawing.Size(97, 20);
            this.cboPeriod.TabIndex = 12;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Location = new System.Drawing.Point(7, 109);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(60, 13);
            this.lblPeriod.TabIndex = 11;
            this.lblPeriod.Text = "Period Date:";
            this.lblPeriod.Visible = false;
            // 
            // radioApproved
            // 
            this.radioApproved.EditValue = 0;
            this.radioApproved.Location = new System.Drawing.Point(96, 128);
            this.radioApproved.Name = "radioApproved";
            this.radioApproved.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Approved"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Non-Approved")});
            this.radioApproved.Size = new System.Drawing.Size(111, 73);
            this.radioApproved.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 137);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Approval:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Data Source:";
            // 
            // checkedReportList
            // 
            this.checkedReportList.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Month End Summary", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Contract Log"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Job Progress Summary"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Month End Cost Of Completion")});
            this.checkedReportList.Location = new System.Drawing.Point(55, 355);
            this.checkedReportList.Name = "checkedReportList";
            this.checkedReportList.Size = new System.Drawing.Size(183, 140);
            this.checkedReportList.TabIndex = 16;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 355);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Reports:";
            // 
            // radioContractValue
            // 
            this.radioContractValue.EditValue = 2;
            this.radioContractValue.Location = new System.Drawing.Point(96, 285);
            this.radioContractValue.Name = "radioContractValue";
            this.radioContractValue.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "$250,000 or More"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "End of Month (WIP)")});
            this.radioContractValue.Size = new System.Drawing.Size(142, 64);
            this.radioContractValue.TabIndex = 18;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 285);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(71, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Final Contract:";
            // 
            // cboOffice
            // 
            this.cboOffice.Location = new System.Drawing.Point(64, 207);
            this.cboOffice.Name = "cboOffice";
            this.cboOffice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOffice.Properties.NullText = "";
            this.cboOffice.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboOffice.Size = new System.Drawing.Size(174, 20);
            this.cboOffice.TabIndex = 346;
            this.cboOffice.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.cboOffice_ProcessNewValue);
            // 
            // labelControl129
            // 
            this.labelControl129.Location = new System.Drawing.Point(25, 210);
            this.labelControl129.Name = "labelControl129";
            this.labelControl129.Size = new System.Drawing.Size(33, 13);
            this.labelControl129.TabIndex = 349;
            this.labelControl129.Text = "Office:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Location = new System.Drawing.Point(64, 233);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartment.Properties.NullText = "";
            this.cboDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboDepartment.Size = new System.Drawing.Size(174, 20);
            this.cboDepartment.TabIndex = 347;
            this.cboDepartment.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.cboDepartment_ProcessNewValue);
            // 
            // labelControl127
            // 
            this.labelControl127.Location = new System.Drawing.Point(25, 236);
            this.labelControl127.Name = "labelControl127";
            this.labelControl127.Size = new System.Drawing.Size(31, 13);
            this.labelControl127.TabIndex = 348;
            this.labelControl127.Text = "Dept.:";
            // 
            // ctlJobProgressSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboOffice);
            this.Controls.Add(this.labelControl129);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.labelControl127);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.radioContractValue);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.checkedReportList);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.radioApproved);
            this.Controls.Add(this.cboPeriod);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.radioDataType);
            this.Controls.Add(this.cboProjectManager);
            this.Controls.Add(this.lblPM);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlJobProgressSummaryReport";
            this.Size = new System.Drawing.Size(248, 533);
            this.Load += new System.EventHandler(this.ctlBidScheduleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectManager.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioDataType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioApproved.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedReportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioContractValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblPM;
        private DevExpress.XtraEditors.LookUpEdit cboProjectManager;
        private DevExpress.XtraEditors.RadioGroup radioDataType;
        private DevExpress.XtraEditors.LookUpEdit cboPeriod;
        private DevExpress.XtraEditors.LabelControl lblPeriod;
        private DevExpress.XtraEditors.RadioGroup radioApproved;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedReportList;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup radioContractValue;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit cboOffice;
        private DevExpress.XtraEditors.LabelControl labelControl129;
        private DevExpress.XtraEditors.LookUpEdit cboDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl127;
    }
}
