namespace CCEJobs.Controls
{
    partial class ctlJobPrequalReport
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
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.cboCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCompDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.txtCompDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmountTo = new DevExpress.XtraEditors.TextEdit();
            this.txtAmountFrom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.radioArchiveStatus = new DevExpress.XtraEditors.RadioGroup();
            this.radioReportType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtScopeOfWork = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.pgDepartment = new DevExpress.XtraTab.XtraTabPage();
            this.lstDepartment = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.pgContractType = new DevExpress.XtraTab.XtraTabPage();
            this.lstContractType = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.pgWorkType = new DevExpress.XtraTab.XtraTabPage();
            this.lstWorkType = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.pgPrequalKeywords = new DevExpress.XtraTab.XtraTabPage();
            this.lstPrequalKeywords = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioArchiveStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScopeOfWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.pgDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstDepartment)).BeginInit();
            this.pgContractType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstContractType)).BeginInit();
            this.pgWorkType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstWorkType)).BeginInit();
            this.pgPrequalKeywords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstPrequalKeywords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(189, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(54, 27);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(3, 43);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(50, 13);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer:";
            // 
            // cboCustomer
            // 
            this.cboCustomer.Location = new System.Drawing.Point(65, 40);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomer.Properties.NullText = "";
            this.cboCustomer.Size = new System.Drawing.Size(178, 20);
            this.cboCustomer.TabIndex = 2;
            this.cboCustomer.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // txtCompDateFrom
            // 
            this.txtCompDateFrom.EditValue = null;
            this.txtCompDateFrom.Location = new System.Drawing.Point(77, 134);
            this.txtCompDateFrom.Name = "txtCompDateFrom";
            this.txtCompDateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtCompDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCompDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCompDateFrom.Size = new System.Drawing.Size(81, 20);
            this.txtCompDateFrom.TabIndex = 380;
            this.txtCompDateFrom.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // txtCompDateTo
            // 
            this.txtCompDateTo.EditValue = null;
            this.txtCompDateTo.Location = new System.Drawing.Point(162, 134);
            this.txtCompDateTo.Name = "txtCompDateTo";
            this.txtCompDateTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtCompDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCompDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCompDateTo.Size = new System.Drawing.Size(81, 20);
            this.txtCompDateTo.TabIndex = 381;
            this.txtCompDateTo.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(3, 137);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(61, 13);
            this.labelControl9.TabIndex = 382;
            this.labelControl9.Text = "Comp. Date:";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(171, 89);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(14, 13);
            this.labelControl12.TabIndex = 384;
            this.labelControl12.Text = "To";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(86, 89);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(29, 13);
            this.labelControl11.TabIndex = 383;
            this.labelControl11.Text = "From";
            // 
            // txtAmountTo
            // 
            this.txtAmountTo.Location = new System.Drawing.Point(162, 108);
            this.txtAmountTo.Name = "txtAmountTo";
            this.txtAmountTo.Properties.AllowFocused = false;
            this.txtAmountTo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAmountTo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAmountTo.Properties.DisplayFormat.FormatString = "c0";
            this.txtAmountTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmountTo.Properties.EditFormat.FormatString = "c0";
            this.txtAmountTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmountTo.Properties.Mask.EditMask = "c0";
            this.txtAmountTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmountTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAmountTo.Properties.MaxLength = 20;
            this.txtAmountTo.Size = new System.Drawing.Size(81, 20);
            this.txtAmountTo.TabIndex = 398;
            this.txtAmountTo.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // txtAmountFrom
            // 
            this.txtAmountFrom.Location = new System.Drawing.Point(77, 108);
            this.txtAmountFrom.Name = "txtAmountFrom";
            this.txtAmountFrom.Properties.AllowFocused = false;
            this.txtAmountFrom.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAmountFrom.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAmountFrom.Properties.DisplayFormat.FormatString = "c0";
            this.txtAmountFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmountFrom.Properties.EditFormat.FormatString = "c0";
            this.txtAmountFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmountFrom.Properties.Mask.EditMask = "c0";
            this.txtAmountFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmountFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAmountFrom.Properties.MaxLength = 20;
            this.txtAmountFrom.Size = new System.Drawing.Size(81, 20);
            this.txtAmountFrom.TabIndex = 397;
            this.txtAmountFrom.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(3, 111);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(72, 13);
            this.labelControl8.TabIndex = 396;
            this.labelControl8.Text = "Contract Amt.:";
            // 
            // radioArchiveStatus
            // 
            this.radioArchiveStatus.EditValue = 0;
            this.radioArchiveStatus.Location = new System.Drawing.Point(14, 348);
            this.radioArchiveStatus.Name = "radioArchiveStatus";
            this.radioArchiveStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Active"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Closed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "All")});
            this.radioArchiveStatus.Size = new System.Drawing.Size(217, 19);
            this.radioArchiveStatus.TabIndex = 403;
            this.radioArchiveStatus.Click += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // radioReportType
            // 
            this.radioReportType.EditValue = 0;
            this.radioReportType.Location = new System.Drawing.Point(17, 373);
            this.radioReportType.Name = "radioReportType";
            this.radioReportType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Report"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Excel"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Excel Sum.")});
            this.radioReportType.Size = new System.Drawing.Size(214, 19);
            this.radioReportType.TabIndex = 404;
            this.radioReportType.Click += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(3, 66);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(33, 13);
            this.labelControl13.TabIndex = 406;
            this.labelControl13.Text = "Scope:";
            // 
            // txtScopeOfWork
            // 
            this.txtScopeOfWork.Location = new System.Drawing.Point(65, 63);
            this.txtScopeOfWork.Name = "txtScopeOfWork";
            this.txtScopeOfWork.Properties.MaxLength = 50;
            this.txtScopeOfWork.Size = new System.Drawing.Size(174, 20);
            this.txtScopeOfWork.TabIndex = 405;
            this.txtScopeOfWork.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(14, 160);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.pgDepartment;
            this.xtraTabControl1.Size = new System.Drawing.Size(229, 182);
            this.xtraTabControl1.TabIndex = 407;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pgDepartment,
            this.pgContractType,
            this.pgWorkType,
            this.pgPrequalKeywords});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // pgDepartment
            // 
            this.pgDepartment.Controls.Add(this.lstDepartment);
            this.pgDepartment.Name = "pgDepartment";
            this.pgDepartment.Size = new System.Drawing.Size(220, 151);
            this.pgDepartment.Text = "Department";
            // 
            // lstDepartment
            // 
            this.lstDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDepartment.Location = new System.Drawing.Point(0, 0);
            this.lstDepartment.Name = "lstDepartment";
            this.lstDepartment.Size = new System.Drawing.Size(220, 151);
            this.lstDepartment.TabIndex = 4;
            this.lstDepartment.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstDepartment_ItemCheck);
            // 
            // pgContractType
            // 
            this.pgContractType.Controls.Add(this.lstContractType);
            this.pgContractType.Name = "pgContractType";
            this.pgContractType.Size = new System.Drawing.Size(220, 151);
            this.pgContractType.Text = "Contract Type";
            // 
            // lstContractType
            // 
            this.lstContractType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContractType.Location = new System.Drawing.Point(0, 0);
            this.lstContractType.Name = "lstContractType";
            this.lstContractType.Size = new System.Drawing.Size(220, 151);
            this.lstContractType.TabIndex = 402;
            this.lstContractType.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstContractType_ItemCheck);
            // 
            // pgWorkType
            // 
            this.pgWorkType.Controls.Add(this.lstWorkType);
            this.pgWorkType.Name = "pgWorkType";
            this.pgWorkType.Size = new System.Drawing.Size(220, 151);
            this.pgWorkType.Text = "Work Type";
            // 
            // lstWorkType
            // 
            this.lstWorkType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWorkType.Location = new System.Drawing.Point(0, 0);
            this.lstWorkType.Name = "lstWorkType";
            this.lstWorkType.Size = new System.Drawing.Size(220, 151);
            this.lstWorkType.TabIndex = 400;
            this.lstWorkType.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstWorkType_ItemCheck);
            // 
            // pgPrequalKeywords
            // 
            this.pgPrequalKeywords.Controls.Add(this.lstPrequalKeywords);
            this.pgPrequalKeywords.Name = "pgPrequalKeywords";
            this.pgPrequalKeywords.Size = new System.Drawing.Size(220, 151);
            this.pgPrequalKeywords.Text = "Prequal Keywords";
            // 
            // lstPrequalKeywords
            // 
            this.lstPrequalKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPrequalKeywords.Location = new System.Drawing.Point(0, 0);
            this.lstPrequalKeywords.Name = "lstPrequalKeywords";
            this.lstPrequalKeywords.Size = new System.Drawing.Size(220, 151);
            this.lstPrequalKeywords.TabIndex = 400;
            this.lstPrequalKeywords.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstPrequalKeywords_ItemCheck);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(104, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 27);
            this.btnClear.TabIndex = 408;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ctlJobPrequalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.txtScopeOfWork);
            this.Controls.Add(this.radioReportType);
            this.Controls.Add(this.radioArchiveStatus);
            this.Controls.Add(this.txtAmountTo);
            this.Controls.Add(this.txtAmountFrom);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtCompDateFrom);
            this.Controls.Add(this.txtCompDateTo);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlJobPrequalReport";
            this.Size = new System.Drawing.Size(255, 415);
            this.Load += new System.EventHandler(this.ctlBidScheduleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioArchiveStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScopeOfWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.pgDepartment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstDepartment)).EndInit();
            this.pgContractType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstContractType)).EndInit();
            this.pgWorkType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstWorkType)).EndInit();
            this.pgPrequalKeywords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstPrequalKeywords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.LookUpEdit cboCustomer;
        private DevExpress.XtraEditors.DateEdit txtCompDateFrom;
        private DevExpress.XtraEditors.DateEdit txtCompDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtAmountTo;
        private DevExpress.XtraEditors.TextEdit txtAmountFrom;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.RadioGroup radioArchiveStatus;
        private DevExpress.XtraEditors.RadioGroup radioReportType;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtScopeOfWork;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage pgDepartment;
        private DevExpress.XtraTab.XtraTabPage pgContractType;
        private DevExpress.XtraTab.XtraTabPage pgWorkType;
        private DevExpress.XtraTab.XtraTabPage pgPrequalKeywords;
        private DevExpress.XtraEditors.CheckedListBoxControl lstDepartment;
        private DevExpress.XtraEditors.CheckedListBoxControl lstContractType;
        private DevExpress.XtraEditors.CheckedListBoxControl lstWorkType;
        private DevExpress.XtraEditors.CheckedListBoxControl lstPrequalKeywords;
        private DevExpress.XtraEditors.SimpleButton btnClear;
    }
}
