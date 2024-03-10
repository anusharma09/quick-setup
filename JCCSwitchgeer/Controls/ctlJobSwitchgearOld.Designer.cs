namespace JCCSwitchgear.Controls
{
    partial class ctlJobSwitchgearOld
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdSwitchgearDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSwitchgear = new DevExpress.XtraGrid.GridControl();
            this.grdSwitchgearView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.panSwitchgear = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.hyperLinkEdit2 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgear)).BeginInit();
            this.panSwitchgear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSwitchgearDetailView
            // 
            this.grdSwitchgearDetailView.GridControl = this.grdSwitchgear;
            this.grdSwitchgearDetailView.Name = "grdSwitchgearDetailView";
            // 
            // grdSwitchgear
            // 
            this.grdSwitchgear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSwitchgear.EmbeddedNavigator.Name = "";
            gridLevelNode2.LevelTemplate = this.grdSwitchgearDetailView;
            gridLevelNode2.RelationName = "Level1";
            this.grdSwitchgear.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grdSwitchgear.Location = new System.Drawing.Point(0, 23);
            this.grdSwitchgear.MainView = this.grdSwitchgearView;
            this.grdSwitchgear.Name = "grdSwitchgear";
            this.grdSwitchgear.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelectedItem,
            this.txtUserDescription,
            this.txtMaterialCost,
            this.txtLaborCost,
            this.txtOtherCost,
            this.txtQuantity,
            this.txtHours,
            this.cboUnit,
            this.txtUserDescription1});
            this.grdSwitchgear.Size = new System.Drawing.Size(974, 528);
            this.grdSwitchgear.TabIndex = 457;
            this.grdSwitchgear.ToolTipController = this.toolTipController1;
            this.grdSwitchgear.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSwitchgearView,
            this.grdSwitchgearDetailView});
            // 
            // grdSwitchgearView
            // 
            this.grdSwitchgearView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdSwitchgearView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdSwitchgearView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdSwitchgearView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdSwitchgearView.GridControl = this.grdSwitchgear;
            this.grdSwitchgearView.Name = "grdSwitchgearView";
            this.grdSwitchgearView.OptionsBehavior.Editable = false;
            this.grdSwitchgearView.OptionsCustomization.AllowGroup = false;
            this.grdSwitchgearView.OptionsMenu.EnableColumnMenu = false;
            this.grdSwitchgearView.OptionsMenu.EnableFooterMenu = false;
            this.grdSwitchgearView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdSwitchgearView.OptionsView.ColumnAutoWidth = false;
            this.grdSwitchgearView.OptionsView.ShowFooter = true;
            this.grdSwitchgearView.OptionsView.ShowGroupPanel = false;
            this.grdSwitchgearView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdSwitchgearView_FocusedRowChanged);
            this.grdSwitchgearView.DoubleClick += new System.EventHandler(this.grdSwitchgearView_DoubleClick);
            this.grdSwitchgearView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdSwitchgearView_MouseUp);
            this.grdSwitchgearView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdSwitchgearView_MasterRowExpanded);
            this.grdSwitchgearView.ColumnFilterChanged += new System.EventHandler(this.grdSwitchgearView_ColumnFilterChanged);
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
            // panSwitchgear
            // 
            this.panSwitchgear.Controls.Add(this.hyperLinkEdit2);
            this.panSwitchgear.Controls.Add(this.hyperLinkEdit1);
            this.panSwitchgear.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSwitchgear.Location = new System.Drawing.Point(0, 0);
            this.panSwitchgear.Name = "panSwitchgear";
            this.panSwitchgear.Size = new System.Drawing.Size(974, 23);
            this.toolTipController1.SetSuperTip(this.panSwitchgear, null);
            this.panSwitchgear.TabIndex = 455;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "New Switchgear...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(103, 18);
            this.hyperLinkEdit1.TabIndex = 8;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // hyperLinkEdit2
            // 
            this.hyperLinkEdit2.EditValue = "Import Switchgear...";
            this.hyperLinkEdit2.Location = new System.Drawing.Point(179, 3);
            this.hyperLinkEdit2.Name = "hyperLinkEdit2";
            this.hyperLinkEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit2.Size = new System.Drawing.Size(115, 18);
            this.hyperLinkEdit2.TabIndex = 9;
            this.hyperLinkEdit2.Click += new System.EventHandler(this.hyperLinkEdit2_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // ctlJobSwitchgear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdSwitchgear);
            this.Controls.Add(this.panSwitchgear);
            this.Name = "ctlJobSwitchgear";
            this.Size = new System.Drawing.Size(974, 551);
            this.toolTipController1.SetSuperTip(this, null);
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgear)).EndInit();
            this.panSwitchgear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl panSwitchgear;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl grdSwitchgear;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSwitchgearView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelectedItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtUserDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaterialCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtLaborCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtOtherCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtUserDescription1;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSwitchgearDetailView;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit2;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}
