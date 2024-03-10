namespace CCEJobs.Controls
{
    partial class ctlJobSubmittal
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSubmittalView, "ctlJobSubmittal");
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdSubmittalDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSubmittal = new DevExpress.XtraGrid.GridControl();
            this.grdSubmittalView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkSelectedItem = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtUserDescription = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.txtMaterialCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtLaborCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtOtherCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtHours = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cboUnit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtUserDescription1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repRevNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.panSubmittal = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit3 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRevNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSubmittal)).BeginInit();
            this.panSubmittal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSubmittalDetailView
            // 
            this.grdSubmittalDetailView.GridControl = this.grdSubmittal;
            this.grdSubmittalDetailView.Name = "grdSubmittalDetailView";
            // 
            // grdSubmittal
            // 
            this.grdSubmittal.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grdSubmittalDetailView;
            gridLevelNode1.RelationName = "Level1";
            this.grdSubmittal.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdSubmittal.Location = new System.Drawing.Point(0, 23);
            this.grdSubmittal.MainView = this.grdSubmittalView;
            this.grdSubmittal.Name = "grdSubmittal";
            this.grdSubmittal.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelectedItem,
            this.txtUserDescription,
            this.txtMaterialCost,
            this.txtLaborCost,
            this.txtOtherCost,
            this.txtQuantity,
            this.txtHours,
            this.cboUnit,
            this.txtUserDescription1,
            this.repRevNumber});
            this.grdSubmittal.Size = new System.Drawing.Size(974, 528);
            this.grdSubmittal.TabIndex = 457;
            this.grdSubmittal.ToolTipController = this.toolTipController1;
            this.grdSubmittal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSubmittalView,
            this.grdSubmittalDetailView});
            // 
            // grdSubmittalView
            // 
            this.grdSubmittalView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdSubmittalView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdSubmittalView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdSubmittalView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdSubmittalView.GridControl = this.grdSubmittal;
            this.grdSubmittalView.Name = "grdSubmittalView";
            this.grdSubmittalView.OptionsBehavior.Editable = false;
            this.grdSubmittalView.OptionsCustomization.AllowGroup = false;
            this.grdSubmittalView.OptionsMenu.EnableColumnMenu = false;
            this.grdSubmittalView.OptionsMenu.EnableFooterMenu = false;
            this.grdSubmittalView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdSubmittalView.OptionsView.ColumnAutoWidth = false;
            this.grdSubmittalView.OptionsView.ShowFooter = true;
            this.grdSubmittalView.OptionsView.ShowGroupPanel = false;
            this.grdSubmittalView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdSubmittalView_MasterRowExpanded);
            this.grdSubmittalView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdSubmittalView_ColumnWidthChanged);
            this.grdSubmittalView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdSubmittalView_FocusedRowChanged);
            this.grdSubmittalView.ColumnFilterChanged += new System.EventHandler(this.grdSubmittalView_ColumnFilterChanged);
            this.grdSubmittalView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdSubmittalView_KeyDown);
            this.grdSubmittalView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdSubmittalView_MouseUp);
            this.grdSubmittalView.DoubleClick += new System.EventHandler(this.grdSubmittalView_DoubleClick);
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
            // repRevNumber
            // 
            this.repRevNumber.AutoHeight = false;
            this.repRevNumber.DisplayFormat.FormatString = "0#";
            this.repRevNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repRevNumber.Name = "repRevNumber";
            // 
            // panSubmittal
            // 
            this.panSubmittal.Controls.Add(this.hyperLinkEdit3);
            this.panSubmittal.Controls.Add(this.hyperLinkEdit1);
            this.panSubmittal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSubmittal.Location = new System.Drawing.Point(0, 0);
            this.panSubmittal.Name = "panSubmittal";
            this.panSubmittal.Size = new System.Drawing.Size(974, 23);
            this.panSubmittal.TabIndex = 455;
            // 
            // hyperLinkEdit3
            // 
            this.hyperLinkEdit3.EditValue = "Import Submittal...";
            this.hyperLinkEdit3.Location = new System.Drawing.Point(114, 3);
            this.hyperLinkEdit3.Name = "hyperLinkEdit3";
            this.hyperLinkEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit3.Size = new System.Drawing.Size(129, 18);
            this.hyperLinkEdit3.TabIndex = 458;
            this.hyperLinkEdit3.Click += new System.EventHandler(this.hyperLinkEdit3_Click);
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "New Submittal...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(103, 18);
            this.hyperLinkEdit1.TabIndex = 8;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // ctlJobSubmittal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdSubmittal);
            this.Controls.Add(this.panSubmittal);
            this.Name = "ctlJobSubmittal";
            this.Size = new System.Drawing.Size(974, 551);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubmittalView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRevNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSubmittal)).EndInit();
            this.panSubmittal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl panSubmittal;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl grdSubmittal;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSubmittalView;
        private System.Windows.Forms.OpenFileDialog openFile;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repRevNumber;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit3;
    }
}
