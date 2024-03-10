namespace JCCDailyLog.Controls
{
    partial class ctlDailyLog
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
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobDailyLogView, "ctlDailyLog");
            }
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
            this.components = new System.ComponentModel.Container();
            this.grdJobDailyLog = new DevExpress.XtraGrid.GridControl();
            this.grdJobDailyLogView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkSelectedItem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtUserDescription = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.txtMaterialCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtLaborCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtOtherCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtHours = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cboUnit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtUserDescription1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.grdSubmittalDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panJobDailyLog = new DevExpress.XtraEditors.PanelControl();
            this.radioGroupType = new DevExpress.XtraEditors.RadioGroup();
            this.panDailyLogSecurity = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchDaily = new System.Windows.Forms.TextBox();
            this.hyperLinkEdit2 = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobDailyLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobDailyLogView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobDailyLog)).BeginInit();
            this.panJobDailyLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDailyLogSecurity)).BeginInit();
            this.panDailyLogSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdJobDailyLog
            // 
            this.grdJobDailyLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobDailyLog.Location = new System.Drawing.Point(0, 46);
            this.grdJobDailyLog.MainView = this.grdJobDailyLogView;
            this.grdJobDailyLog.Name = "grdJobDailyLog";
            this.grdJobDailyLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelectedItem,
            this.txtUserDescription,
            this.txtMaterialCost,
            this.txtLaborCost,
            this.txtOtherCost,
            this.txtQuantity,
            this.txtHours,
            this.cboUnit,
            this.txtUserDescription1});
            this.grdJobDailyLog.Size = new System.Drawing.Size(974, 505);
            this.grdJobDailyLog.TabIndex = 457;
            this.grdJobDailyLog.ToolTipController = this.toolTipController1;
            this.grdJobDailyLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobDailyLogView,
            this.grdSubmittalDetailView});
            // 
            // grdJobDailyLogView
            // 
            this.grdJobDailyLogView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdJobDailyLogView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobDailyLogView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdJobDailyLogView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobDailyLogView.GridControl = this.grdJobDailyLog;
            this.grdJobDailyLogView.Name = "grdJobDailyLogView";
            this.grdJobDailyLogView.OptionsBehavior.Editable = false;
            this.grdJobDailyLogView.OptionsCustomization.AllowGroup = false;
            this.grdJobDailyLogView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobDailyLogView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobDailyLogView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobDailyLogView.OptionsView.ColumnAutoWidth = false;
            this.grdJobDailyLogView.OptionsView.ShowFooter = true;
            this.grdJobDailyLogView.OptionsView.ShowGroupPanel = false;
            this.grdJobDailyLogView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdJobDailyLogView_ColumnWidthChanged);
            this.grdJobDailyLogView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdDailyLogView_FocusedRowChanged);
            this.grdJobDailyLogView.ColumnFilterChanged += new System.EventHandler(this.grdDailyLogView_ColumnFilterChanged);
            this.grdJobDailyLogView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdDailyLogView_MouseUp);
            this.grdJobDailyLogView.DoubleClick += new System.EventHandler(this.grdDailyLogView_DoubleClick);
            // 
            // chkSelectedItem
            // 
            this.chkSelectedItem.AutoHeight = false;
            this.chkSelectedItem.Name = "chkSelectedItem";
            // 
            // txtUserDescription
            // 
            this.txtUserDescription.AutoHeight = false;
            this.txtUserDescription.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtUserDescription.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUserDescription.MaxLength = 128;
            this.txtUserDescription.Name = "txtUserDescription";
            // 
            // txtMaterialCost
            // 
            this.txtMaterialCost.AutoHeight = false;
            this.txtMaterialCost.DisplayFormat.FormatString = "c2";
            this.txtMaterialCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMaterialCost.EditFormat.FormatString = "c2";
            this.txtMaterialCost.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMaterialCost.Mask.EditMask = "c2";
            this.txtMaterialCost.Mask.UseMaskAsDisplayFormat = true;
            this.txtMaterialCost.Name = "txtMaterialCost";
            // 
            // txtLaborCost
            // 
            this.txtLaborCost.AutoHeight = false;
            this.txtLaborCost.DisplayFormat.FormatString = "c2";
            this.txtLaborCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLaborCost.EditFormat.FormatString = "c2";
            this.txtLaborCost.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLaborCost.Mask.EditMask = "c2";
            this.txtLaborCost.Name = "txtLaborCost";
            // 
            // txtOtherCost
            // 
            this.txtOtherCost.AutoHeight = false;
            this.txtOtherCost.DisplayFormat.FormatString = "c2";
            this.txtOtherCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOtherCost.EditFormat.FormatString = "c2";
            this.txtOtherCost.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOtherCost.Mask.EditMask = "c2";
            this.txtOtherCost.Name = "txtOtherCost";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoHeight = false;
            this.txtQuantity.DisplayFormat.FormatString = "n0";
            this.txtQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.EditFormat.FormatString = "n0";
            this.txtQuantity.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Mask.EditMask = "n0";
            this.txtQuantity.Name = "txtQuantity";
            // 
            // txtHours
            // 
            this.txtHours.AutoHeight = false;
            this.txtHours.DisplayFormat.FormatString = "n0";
            this.txtHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHours.EditFormat.FormatString = "n0";
            this.txtHours.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHours.Mask.EditMask = "n0";
            this.txtHours.Name = "txtHours";
            // 
            // cboUnit
            // 
            this.cboUnit.AutoHeight = false;
            this.cboUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnit.Items.AddRange(new object[] {
            "C",
            "E",
            "H",
            "M"});
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.cboUnit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // txtUserDescription1
            // 
            this.txtUserDescription1.AutoHeight = false;
            this.txtUserDescription1.MaxLength = 100;
            this.txtUserDescription1.Name = "txtUserDescription1";
            // 
            // grdSubmittalDetailView
            // 
            this.grdSubmittalDetailView.GridControl = this.grdJobDailyLog;
            this.grdSubmittalDetailView.Name = "grdSubmittalDetailView";
            // 
            // panJobDailyLog
            // 
            this.panJobDailyLog.Controls.Add(this.radioGroupType);
            this.panJobDailyLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panJobDailyLog.Location = new System.Drawing.Point(0, 23);
            this.panJobDailyLog.Name = "panJobDailyLog";
            this.panJobDailyLog.Size = new System.Drawing.Size(974, 23);
            this.panJobDailyLog.TabIndex = 455;
            // 
            // radioGroupType
            // 
            this.radioGroupType.EditValue = 0;
            this.radioGroupType.Location = new System.Drawing.Point(0, 0);
            this.radioGroupType.Name = "radioGroupType";
            this.radioGroupType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "All"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Inspection"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Pictures"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Accident"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Safety"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "Extra Work"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(6, "Back Charge"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(7, "Scheduled"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(8, "Delay"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(9, "Disruption")});
            this.radioGroupType.Size = new System.Drawing.Size(829, 23);
            this.radioGroupType.TabIndex = 0;
            this.radioGroupType.SelectedIndexChanged += new System.EventHandler(this.radioGroupType_SelectedIndexChanged);
            // 
            // panDailyLogSecurity
            // 
            this.panDailyLogSecurity.Controls.Add(this.btnSearch);
            this.panDailyLogSecurity.Controls.Add(this.txtSearchDaily);
            this.panDailyLogSecurity.Controls.Add(this.hyperLinkEdit2);
            this.panDailyLogSecurity.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDailyLogSecurity.Location = new System.Drawing.Point(0, 0);
            this.panDailyLogSecurity.Name = "panDailyLogSecurity";
            this.panDailyLogSecurity.Size = new System.Drawing.Size(974, 23);
            this.panDailyLogSecurity.TabIndex = 458;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(858, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 21);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchDaily
            // 
            this.txtSearchDaily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchDaily.Location = new System.Drawing.Point(584, 0);
            this.txtSearchDaily.Name = "txtSearchDaily";
            this.txtSearchDaily.Size = new System.Drawing.Size(268, 21);
            this.txtSearchDaily.TabIndex = 9;         
            // 
            // hyperLinkEdit2
            // 
            this.hyperLinkEdit2.EditValue = "New Daily Log...";
            this.hyperLinkEdit2.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit2.Name = "hyperLinkEdit2";
            this.hyperLinkEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit2.Size = new System.Drawing.Size(172, 18);
            this.hyperLinkEdit2.TabIndex = 8;
            this.hyperLinkEdit2.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // ctlDailyLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobDailyLog);
            this.Controls.Add(this.panJobDailyLog);
            this.Controls.Add(this.panDailyLogSecurity);
            this.Name = "ctlDailyLog";
            this.Size = new System.Drawing.Size(974, 551);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobDailyLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobDailyLogView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panJobDailyLog)).EndInit();
            this.panJobDailyLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDailyLogSecurity)).EndInit();
            this.panDailyLogSecurity.ResumeLayout(false);
            this.panDailyLogSecurity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl panJobDailyLog;
        private DevExpress.XtraGrid.GridControl grdJobDailyLog;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobDailyLogView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelectedItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtUserDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaterialCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtLaborCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtOtherCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtUserDescription1;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSubmittalDetailView;
        private DevExpress.XtraEditors.RadioGroup radioGroupType;
        private DevExpress.XtraEditors.PanelControl panDailyLogSecurity;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchDaily;
    }
}
