namespace CCEJobs.Controls
{
    partial class ctlPurchasing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlPurchasing));
            this.panGrid = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panGridTitle = new DevExpress.XtraEditors.PanelControl();
            this.picList = new DevExpress.XtraEditors.PictureEdit();
            this.lblList = new DevExpress.XtraEditors.LabelControl();
            this.panUtil = new DevExpress.XtraEditors.PanelControl();
            this.panReportParamters = new DevExpress.XtraEditors.PanelControl();
            this.panReport = new DevExpress.XtraEditors.PanelControl();
            this.cboReport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.panPrintSelect = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panGrid)).BeginInit();
            this.panGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).BeginInit();
            this.panGridTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panUtil)).BeginInit();
            this.panUtil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panReportParamters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panReport)).BeginInit();
            this.panReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panPrintSelect)).BeginInit();
            this.panPrintSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panGrid
            // 
            this.panGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panGrid.Controls.Add(this.panelControl1);
            this.panGrid.Controls.Add(this.panGridTitle);
            this.panGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGrid.Location = new System.Drawing.Point(0, 0);
            this.panGrid.Name = "panGrid";
            this.panGrid.Size = new System.Drawing.Size(305, 543);
            this.panGrid.TabIndex = 7;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 27);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(305, 27);
            this.panelControl1.TabIndex = 9;
            // 
            // panGridTitle
            // 
            this.panGridTitle.Controls.Add(this.picList);
            this.panGridTitle.Controls.Add(this.lblList);
            this.panGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panGridTitle.Location = new System.Drawing.Point(0, 0);
            this.panGridTitle.Name = "panGridTitle";
            this.panGridTitle.Size = new System.Drawing.Size(305, 27);
            this.panGridTitle.TabIndex = 8;
            // 
            // picList
            // 
            this.picList.EditValue = ((object)(resources.GetObject("picList.EditValue")));
            this.picList.Location = new System.Drawing.Point(7, 3);
            this.picList.Name = "picList";
            this.picList.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picList.Size = new System.Drawing.Size(31, 23);
            this.picList.TabIndex = 1;
            // 
            // lblList
            // 
            this.lblList.Location = new System.Drawing.Point(53, 9);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(52, 13);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Purchasing";
            // 
            // panUtil
            // 
            this.panUtil.Controls.Add(this.panReportParamters);
            this.panUtil.Controls.Add(this.panReport);
            this.panUtil.Dock = System.Windows.Forms.DockStyle.Right;
            this.panUtil.Location = new System.Drawing.Point(305, 0);
            this.panUtil.Name = "panUtil";
            this.panUtil.Size = new System.Drawing.Size(234, 543);
            this.panUtil.TabIndex = 8;
            // 
            // panReportParamters
            // 
            this.panReportParamters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panReportParamters.Location = new System.Drawing.Point(2, 86);
            this.panReportParamters.Name = "panReportParamters";
            this.panReportParamters.Size = new System.Drawing.Size(230, 455);
            this.panReportParamters.TabIndex = 12;
            // 
            // panReport
            // 
            this.panReport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panReport.Controls.Add(this.cboReport);
            this.panReport.Controls.Add(this.labelControl6);
            this.panReport.Controls.Add(this.panPrintSelect);
            this.panReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.panReport.Location = new System.Drawing.Point(2, 2);
            this.panReport.Name = "panReport";
            this.panReport.Size = new System.Drawing.Size(230, 84);
            this.panReport.TabIndex = 11;
            // 
            // cboReport
            // 
            this.cboReport.Location = new System.Drawing.Point(26, 55);
            this.cboReport.Name = "cboReport";
            this.cboReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboReport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboReport.Size = new System.Drawing.Size(197, 20);
            this.cboReport.TabIndex = 366;
            this.cboReport.SelectedIndexChanged += new System.EventHandler(this.cboReport_SelectedIndexChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 36);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Select a Report:";
            // 
            // panPrintSelect
            // 
            this.panPrintSelect.Controls.Add(this.pictureEdit1);
            this.panPrintSelect.Controls.Add(this.labelControl5);
            this.panPrintSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPrintSelect.Location = new System.Drawing.Point(0, 0);
            this.panPrintSelect.Name = "panPrintSelect";
            this.panPrintSelect.Size = new System.Drawing.Size(230, 27);
            this.panPrintSelect.TabIndex = 10;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(7, 3);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(31, 23);
            this.pictureEdit1.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(53, 9);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Reports";
            // 
            // ctlPurchasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panGrid);
            this.Controls.Add(this.panUtil);
            this.Name = "ctlPurchasing";
            this.Size = new System.Drawing.Size(539, 543);
            ((System.ComponentModel.ISupportInitialize)(this.panGrid)).EndInit();
            this.panGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panGridTitle)).EndInit();
            this.panGridTitle.ResumeLayout(false);
            this.panGridTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panUtil)).EndInit();
            this.panUtil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panReportParamters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panReport)).EndInit();
            this.panReport.ResumeLayout(false);
            this.panReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panPrintSelect)).EndInit();
            this.panPrintSelect.ResumeLayout(false);
            this.panPrintSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panGrid;
        private DevExpress.XtraEditors.PanelControl panGridTitle;
        private DevExpress.XtraEditors.PictureEdit picList;
        private DevExpress.XtraEditors.LabelControl lblList;
        private DevExpress.XtraEditors.PanelControl panUtil;
        private DevExpress.XtraEditors.PanelControl panReport;
        private DevExpress.XtraEditors.PanelControl panPrintSelect;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cboReport;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panReportParamters;
    }
}
