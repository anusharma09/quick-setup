namespace CCEJobs.Controls
{
    partial class ctlLaborFeedBack
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdLaborFeedback = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmployee = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chartLaborFeedback = new DevExpress.XtraCharts.ChartControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkWeek = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowGrandTotal = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowTotal = new DevExpress.XtraEditors.CheckEdit();
            this.cboLaborFeedback = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl221 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLaborFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowGrandTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLaborFeedback.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdLaborFeedback);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl4);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartLaborFeedback);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(691, 536);
            this.splitContainerControl1.SplitterPosition = 372;
            this.splitContainerControl1.TabIndex = 14;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdLaborFeedback
            // 
            this.grdLaborFeedback.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdLaborFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLaborFeedback.Location = new System.Drawing.Point(0, 0);
            this.grdLaborFeedback.Name = "grdLaborFeedback";
            this.grdLaborFeedback.OptionsMenu.EnableFieldValueMenu = false;
            this.grdLaborFeedback.OptionsMenu.EnableHeaderAreaMenu = false;
            this.grdLaborFeedback.OptionsMenu.EnableHeaderMenu = false;
            this.grdLaborFeedback.OptionsView.ShowColumnHeaders = false;
            this.grdLaborFeedback.OptionsView.ShowDataHeaders = false;
            this.grdLaborFeedback.OptionsView.ShowFilterHeaders = false;
            this.grdLaborFeedback.Size = new System.Drawing.Size(687, 368);
            this.grdLaborFeedback.TabIndex = 2;
            this.grdLaborFeedback.CustomCellDisplayText += new DevExpress.XtraPivotGrid.PivotCellDisplayTextEventHandler(this.grdLaborFeedback_CustomCellDisplayText);
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.labelControl1);
            this.panelControl4.Controls.Add(this.cboEmployee);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(687, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(0, 368);
            this.panelControl4.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Select an Emp. or Blank for All:";
            // 
            // cboEmployee
            // 
            this.cboEmployee.Location = new System.Drawing.Point(6, 39);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmployee.Properties.Sorted = true;
            this.cboEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboEmployee.Size = new System.Drawing.Size(143, 20);
            this.cboEmployee.TabIndex = 0;
            this.cboEmployee.Visible = false;
            this.cboEmployee.SelectedIndexChanged += new System.EventHandler(this.cboEmployee_SelectedIndexChanged);
            // 
            // chartLaborFeedback
            // 
            this.chartLaborFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLaborFeedback.Legend.MaxHorizontalPercentage = 75;
            this.chartLaborFeedback.Location = new System.Drawing.Point(0, 0);
            this.chartLaborFeedback.Name = "chartLaborFeedback";
            this.chartLaborFeedback.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartLaborFeedback.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chartLaborFeedback.Size = new System.Drawing.Size(687, 154);
            this.chartLaborFeedback.TabIndex = 1;
            this.chartLaborFeedback.BoundDataChanged += new DevExpress.XtraCharts.BoundDataChangedEventHandler(this.chartLaborFeedback_BoundDataChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(687, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(0, 154);
            this.panelControl3.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.chkWeek);
            this.panelControl2.Controls.Add(this.chkShowGrandTotal);
            this.panelControl2.Controls.Add(this.chkShowTotal);
            this.panelControl2.Controls.Add(this.cboLaborFeedback);
            this.panelControl2.Controls.Add(this.labelControl221);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(691, 27);
            this.panelControl2.TabIndex = 15;
            // 
            // chkWeek
            // 
            this.chkWeek.Location = new System.Drawing.Point(243, 4);
            this.chkWeek.Name = "chkWeek";
            this.chkWeek.Properties.Caption = "Show Selected Week Only";
            this.chkWeek.Size = new System.Drawing.Size(163, 19);
            this.chkWeek.TabIndex = 6;
            this.chkWeek.CheckedChanged += new System.EventHandler(this.chkWeek_CheckedChanged);
            // 
            // chkShowGrandTotal
            // 
            this.chkShowGrandTotal.EditValue = true;
            this.chkShowGrandTotal.Location = new System.Drawing.Point(115, 4);
            this.chkShowGrandTotal.Name = "chkShowGrandTotal";
            this.chkShowGrandTotal.Properties.Caption = "Show Grand Total";
            this.chkShowGrandTotal.Size = new System.Drawing.Size(122, 19);
            this.chkShowGrandTotal.TabIndex = 5;
            this.chkShowGrandTotal.CheckedChanged += new System.EventHandler(this.chkShowGrandTotal_CheckedChanged);
            // 
            // chkShowTotal
            // 
            this.chkShowTotal.EditValue = true;
            this.chkShowTotal.Location = new System.Drawing.Point(15, 4);
            this.chkShowTotal.Name = "chkShowTotal";
            this.chkShowTotal.Properties.Caption = "Show Total";
            this.chkShowTotal.Size = new System.Drawing.Size(77, 19);
            this.chkShowTotal.TabIndex = 4;
            this.chkShowTotal.CheckedChanged += new System.EventHandler(this.chkShowTotal_CheckedChanged);
            // 
            // cboLaborFeedback
            // 
            this.cboLaborFeedback.Location = new System.Drawing.Point(516, 6);
            this.cboLaborFeedback.Name = "cboLaborFeedback";
            this.cboLaborFeedback.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLaborFeedback.Properties.DisplayFormat.FormatString = "d";
            this.cboLaborFeedback.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboLaborFeedback.Properties.EditFormat.FormatString = "d";
            this.cboLaborFeedback.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cboLaborFeedback.Properties.NullText = "";
            this.cboLaborFeedback.Size = new System.Drawing.Size(127, 20);
            this.cboLaborFeedback.TabIndex = 3;
            this.cboLaborFeedback.EditValueChanged += new System.EventHandler(this.cboLaborFeedback_EditValueChanged);
            // 
            // labelControl221
            // 
            this.labelControl221.Location = new System.Drawing.Point(432, 8);
            this.labelControl221.Name = "labelControl221";
            this.labelControl221.Size = new System.Drawing.Size(72, 13);
            this.labelControl221.TabIndex = 2;
            this.labelControl221.Text = "Select a Week:";
            // 
            // ctlLaborFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "ctlLaborFeedBack";
            this.Size = new System.Drawing.Size(691, 563);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLaborFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowGrandTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLaborFeedback.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl grdLaborFeedback;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboLaborFeedback;
        private DevExpress.XtraEditors.LabelControl labelControl221;
        private DevExpress.XtraCharts.ChartControl chartLaborFeedback;
        private DevExpress.XtraEditors.CheckEdit chkShowGrandTotal;
        private DevExpress.XtraEditors.CheckEdit chkShowTotal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboEmployee;
        private DevExpress.XtraEditors.CheckEdit chkWeek;
    }
}
