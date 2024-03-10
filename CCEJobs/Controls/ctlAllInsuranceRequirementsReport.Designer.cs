namespace CCEJobs.Controls
{
    partial class ctlAllInsuranceRequirementsReport
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
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.lstOffice = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lstDepartment = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioStatus = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl273 = new DevExpress.XtraEditors.LabelControl();
            this.txtProfLiab = new DevExpress.XtraEditors.TextEdit();
            this.txtGLAutoWC = new DevExpress.XtraEditors.TextEdit();
            this.txtCompletedOps = new DevExpress.XtraEditors.TextEdit();
            this.chkProfLiab = new DevExpress.XtraEditors.CheckEdit();
            this.chkGLAutoWC = new DevExpress.XtraEditors.CheckEdit();
            this.chkCompletedOps = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl272 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lstOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfLiab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGLAutoWC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompletedOps.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProfLiab.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGLAutoWC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompletedOps.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(18, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(54, 27);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(128, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 21);
            this.btnClear.TabIndex = 366;
            this.btnClear.Text = "&Clear";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lstOffice
            // 
            this.lstOffice.Location = new System.Drawing.Point(72, 36);
            this.lstOffice.Name = "lstOffice";
            this.lstOffice.Size = new System.Drawing.Size(153, 81);
            this.lstOffice.TabIndex = 400;
            this.lstOffice.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstOffice_ItemCheck);
            // 
            // lstDepartment
            // 
            this.lstDepartment.Location = new System.Drawing.Point(72, 123);
            this.lstDepartment.Name = "lstDepartment";
            this.lstDepartment.Size = new System.Drawing.Size(153, 100);
            this.lstDepartment.TabIndex = 401;
            this.lstDepartment.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.lstDepartment_ItemCheck);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 36);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 406;
            this.labelControl4.Text = "Office:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 123);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 13);
            this.labelControl5.TabIndex = 407;
            this.labelControl5.Text = "Department:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 230);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 408;
            this.labelControl1.Text = "Job Status:";
            // 
            // radioStatus
            // 
            this.radioStatus.Location = new System.Drawing.Point(58, 249);
            this.radioStatus.Name = "radioStatus";
            this.radioStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Open"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Closed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "All")});
            this.radioStatus.Size = new System.Drawing.Size(167, 22);
            this.radioStatus.TabIndex = 409;
            this.radioStatus.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl273);
            this.panelControl1.Controls.Add(this.txtProfLiab);
            this.panelControl1.Controls.Add(this.txtGLAutoWC);
            this.panelControl1.Controls.Add(this.txtCompletedOps);
            this.panelControl1.Controls.Add(this.chkProfLiab);
            this.panelControl1.Controls.Add(this.chkGLAutoWC);
            this.panelControl1.Controls.Add(this.chkCompletedOps);
            this.panelControl1.Controls.Add(this.labelControl272);
            this.panelControl1.Location = new System.Drawing.Point(27, 287);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(198, 95);
            this.panelControl1.TabIndex = 410;
            // 
            // labelControl273
            // 
            this.labelControl273.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl273.Appearance.Options.UseFont = true;
            this.labelControl273.Location = new System.Drawing.Point(143, 5);
            this.labelControl273.Name = "labelControl273";
            this.labelControl273.Size = new System.Drawing.Size(27, 13);
            this.labelControl273.TabIndex = 153;
            this.labelControl273.Text = "Years";
            // 
            // txtProfLiab
            // 
            this.txtProfLiab.Location = new System.Drawing.Point(143, 68);
            this.txtProfLiab.Name = "txtProfLiab";
            this.txtProfLiab.Properties.DisplayFormat.FormatString = "n0";
            this.txtProfLiab.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtProfLiab.Properties.EditFormat.FormatString = "n0";
            this.txtProfLiab.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtProfLiab.Properties.Mask.EditMask = "##";
            this.txtProfLiab.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtProfLiab.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtProfLiab.Properties.MaxLength = 2;
            this.txtProfLiab.Size = new System.Drawing.Size(36, 20);
            this.txtProfLiab.TabIndex = 152;
            this.txtProfLiab.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // txtGLAutoWC
            // 
            this.txtGLAutoWC.Location = new System.Drawing.Point(143, 48);
            this.txtGLAutoWC.Name = "txtGLAutoWC";
            this.txtGLAutoWC.Properties.DisplayFormat.FormatString = "n0";
            this.txtGLAutoWC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGLAutoWC.Properties.EditFormat.FormatString = "n0";
            this.txtGLAutoWC.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGLAutoWC.Properties.Mask.EditMask = "##";
            this.txtGLAutoWC.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGLAutoWC.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGLAutoWC.Properties.MaxLength = 2;
            this.txtGLAutoWC.Size = new System.Drawing.Size(36, 20);
            this.txtGLAutoWC.TabIndex = 151;
            this.txtGLAutoWC.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // txtCompletedOps
            // 
            this.txtCompletedOps.Location = new System.Drawing.Point(143, 28);
            this.txtCompletedOps.Name = "txtCompletedOps";
            this.txtCompletedOps.Properties.DisplayFormat.FormatString = "n0";
            this.txtCompletedOps.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCompletedOps.Properties.EditFormat.FormatString = "n0";
            this.txtCompletedOps.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCompletedOps.Properties.Mask.EditMask = "##";
            this.txtCompletedOps.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCompletedOps.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCompletedOps.Properties.MaxLength = 2;
            this.txtCompletedOps.Size = new System.Drawing.Size(36, 20);
            this.txtCompletedOps.TabIndex = 150;
            this.txtCompletedOps.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // chkProfLiab
            // 
            this.chkProfLiab.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chkProfLiab.Location = new System.Drawing.Point(9, 68);
            this.chkProfLiab.Name = "chkProfLiab";
            this.chkProfLiab.Properties.Caption = "Prof. Liab";
            this.chkProfLiab.Size = new System.Drawing.Size(106, 19);
            this.chkProfLiab.TabIndex = 149;
            this.chkProfLiab.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // chkGLAutoWC
            // 
            this.chkGLAutoWC.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chkGLAutoWC.Location = new System.Drawing.Point(9, 48);
            this.chkGLAutoWC.Name = "chkGLAutoWC";
            this.chkGLAutoWC.Properties.Caption = "G/L Auto-WC";
            this.chkGLAutoWC.Size = new System.Drawing.Size(106, 19);
            this.chkGLAutoWC.TabIndex = 148;
            this.chkGLAutoWC.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // chkCompletedOps
            // 
            this.chkCompletedOps.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chkCompletedOps.Location = new System.Drawing.Point(9, 28);
            this.chkCompletedOps.Name = "chkCompletedOps";
            this.chkCompletedOps.Properties.Caption = "Completed OPS";
            this.chkCompletedOps.Size = new System.Drawing.Size(106, 19);
            this.chkCompletedOps.TabIndex = 147;
            this.chkCompletedOps.EditValueChanged += new System.EventHandler(this.AllItems_EditValueChanged);
            // 
            // labelControl272
            // 
            this.labelControl272.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl272.Appearance.Options.UseFont = true;
            this.labelControl272.Location = new System.Drawing.Point(5, 5);
            this.labelControl272.Name = "labelControl272";
            this.labelControl272.Size = new System.Drawing.Size(79, 13);
            this.labelControl272.TabIndex = 146;
            this.labelControl272.Text = "All Ins. Required";
            // 
            // ctlAllInsuranceRequirementsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.radioStatus);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lstDepartment);
            this.Controls.Add(this.lstOffice);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnProcess);
            this.Name = "ctlAllInsuranceRequirementsReport";
            this.Size = new System.Drawing.Size(226, 529);
            ((System.ComponentModel.ISupportInitialize)(this.lstOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfLiab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGLAutoWC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompletedOps.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProfLiab.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGLAutoWC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompletedOps.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.CheckedListBoxControl lstOffice;
        private DevExpress.XtraEditors.CheckedListBoxControl lstDepartment;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup radioStatus;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl273;
        private DevExpress.XtraEditors.TextEdit txtProfLiab;
        private DevExpress.XtraEditors.TextEdit txtGLAutoWC;
        private DevExpress.XtraEditors.TextEdit txtCompletedOps;
        private DevExpress.XtraEditors.CheckEdit chkProfLiab;
        private DevExpress.XtraEditors.CheckEdit chkGLAutoWC;
        private DevExpress.XtraEditors.CheckEdit chkCompletedOps;
        private DevExpress.XtraEditors.LabelControl labelControl272;
    }
}
