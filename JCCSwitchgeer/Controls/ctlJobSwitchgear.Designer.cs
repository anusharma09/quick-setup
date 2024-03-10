namespace JCCSwitchgear.Controls
{
    partial class ctlJobSwitchgear
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearView, "ctlJobSwitchgear");
            }

            if (bColumnWidthChangedRelease)
            {
                bColumnWidthChangedRelease = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearReleaseView, "ctlJobSwitchgearRelease");
            }


            if (bColumnWidthChangedRevision)
            {
                bColumnWidthChangedRevision = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearRevisionView, "ctlJobSwitchgearRevision");
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
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
            this.grdSwitchgearReleaseDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSwitchgearRelease = new DevExpress.XtraGrid.GridControl();
            this.grdSwitchgearReleaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdSwitchgearRevisionDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSwitchgearRevision = new DevExpress.XtraGrid.GridControl();
            this.grdSwitchgearRevisionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panSwitchgear = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit3 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.panSwitchgearRelease = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit2 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.panSwitchgearRevision = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit4 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenTemplate = new DevExpress.XtraEditors.HyperLinkEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearReleaseDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearReleaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRevisionDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRevisionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgear)).BeginInit();
            this.panSwitchgear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgearRelease)).BeginInit();
            this.panSwitchgearRelease.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgearRevision)).BeginInit();
            this.panSwitchgearRevision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenTemplate.Properties)).BeginInit();
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
            gridLevelNode1.LevelTemplate = this.grdSwitchgearDetailView;
            gridLevelNode1.RelationName = "Level1";
            this.grdSwitchgear.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
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
            this.grdSwitchgear.Size = new System.Drawing.Size(965, 497);
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
            this.grdSwitchgearView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdLightFixtureView_FocusedRowChanged);
            this.grdSwitchgearView.DoubleClick += new System.EventHandler(this.grdLightFixtureView_DoubleClick);
            this.grdSwitchgearView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdSwitchgearView_KeyDown);
            this.grdSwitchgearView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdLightFixtureView_MouseUp);
            this.grdSwitchgearView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdLightFixtureView_MasterRowExpanded);
            this.grdSwitchgearView.ColumnFilterChanged += new System.EventHandler(this.grdLightFixtureView_ColumnFilterChanged);
            this.grdSwitchgearView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdSwitchgearView_ColumnWidthChanged);
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
            // grdSwitchgearReleaseDetailView
            // 
            this.grdSwitchgearReleaseDetailView.GridControl = this.grdSwitchgearRelease;
            this.grdSwitchgearReleaseDetailView.Name = "grdSwitchgearReleaseDetailView";
            // 
            // grdSwitchgearRelease
            // 
            this.grdSwitchgearRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.LevelTemplate = this.grdSwitchgearReleaseDetailView;
            gridLevelNode2.RelationName = "Level1";
            this.grdSwitchgearRelease.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grdSwitchgearRelease.Location = new System.Drawing.Point(0, 23);
            this.grdSwitchgearRelease.MainView = this.grdSwitchgearReleaseView;
            this.grdSwitchgearRelease.Name = "grdSwitchgearRelease";
            this.grdSwitchgearRelease.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit6});
            this.grdSwitchgearRelease.Size = new System.Drawing.Size(965, 497);
            this.grdSwitchgearRelease.TabIndex = 459;
            this.grdSwitchgearRelease.ToolTipController = this.toolTipController1;
            this.grdSwitchgearRelease.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSwitchgearReleaseView,
            this.grdSwitchgearReleaseDetailView});
            // 
            // grdSwitchgearReleaseView
            // 
            this.grdSwitchgearReleaseView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdSwitchgearReleaseView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdSwitchgearReleaseView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdSwitchgearReleaseView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdSwitchgearReleaseView.GridControl = this.grdSwitchgearRelease;
            this.grdSwitchgearReleaseView.Name = "grdSwitchgearReleaseView";
            this.grdSwitchgearReleaseView.OptionsBehavior.Editable = false;
            this.grdSwitchgearReleaseView.OptionsCustomization.AllowGroup = false;
            this.grdSwitchgearReleaseView.OptionsMenu.EnableColumnMenu = false;
            this.grdSwitchgearReleaseView.OptionsMenu.EnableFooterMenu = false;
            this.grdSwitchgearReleaseView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdSwitchgearReleaseView.OptionsView.ColumnAutoWidth = false;
            this.grdSwitchgearReleaseView.OptionsView.ShowFooter = true;
            this.grdSwitchgearReleaseView.OptionsView.ShowGroupPanel = false;
            this.grdSwitchgearReleaseView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdLightFixtureReleaseView_FocusedRowChanged);
            this.grdSwitchgearReleaseView.DoubleClick += new System.EventHandler(this.grdLightFixtureReleaseView_DoubleClick);
            this.grdSwitchgearReleaseView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdSwitchgearReleaseView_KeyDown);
            this.grdSwitchgearReleaseView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdLightFixtureReleaseView_MouseUp);
            this.grdSwitchgearReleaseView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdLightFixtureReleaseView_MasterRowExpanded);
            this.grdSwitchgearReleaseView.ColumnFilterChanged += new System.EventHandler(this.grdLightFixtureReleaseView_ColumnFilterChanged);
            this.grdSwitchgearReleaseView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdSwitchgearReleaseView_ColumnWidthChanged);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.MaxLength = 128;
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "c2";
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Mask.EditMask = "c2";
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit3.Mask.EditMask = "c2";
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit4.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit4.Mask.EditMask = "n0";
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit5.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit5.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit5.Mask.EditMask = "n0";
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "C",
            "E",
            "H",
            "M"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.AutoHeight = false;
            this.repositoryItemTextEdit6.MaxLength = 100;
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            // 
            // grdSwitchgearRevisionDetailView
            // 
            this.grdSwitchgearRevisionDetailView.GridControl = this.grdSwitchgearRevision;
            this.grdSwitchgearRevisionDetailView.Name = "grdSwitchgearRevisionDetailView";
            // 
            // grdSwitchgearRevision
            // 
            this.grdSwitchgearRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode3.LevelTemplate = this.grdSwitchgearRevisionDetailView;
            gridLevelNode3.RelationName = "Level1";
            this.grdSwitchgearRevision.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.grdSwitchgearRevision.Location = new System.Drawing.Point(0, 23);
            this.grdSwitchgearRevision.MainView = this.grdSwitchgearRevisionView;
            this.grdSwitchgearRevision.Name = "grdSwitchgearRevision";
            this.grdSwitchgearRevision.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemMemoExEdit2,
            this.repositoryItemTextEdit7,
            this.repositoryItemTextEdit8,
            this.repositoryItemTextEdit9,
            this.repositoryItemTextEdit10,
            this.repositoryItemTextEdit11,
            this.repositoryItemComboBox2,
            this.repositoryItemTextEdit12});
            this.grdSwitchgearRevision.Size = new System.Drawing.Size(965, 497);
            this.grdSwitchgearRevision.TabIndex = 460;
            this.grdSwitchgearRevision.ToolTipController = this.toolTipController1;
            this.grdSwitchgearRevision.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSwitchgearRevisionView,
            this.grdSwitchgearRevisionDetailView});
            // 
            // grdSwitchgearRevisionView
            // 
            this.grdSwitchgearRevisionView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdSwitchgearRevisionView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdSwitchgearRevisionView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdSwitchgearRevisionView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdSwitchgearRevisionView.GridControl = this.grdSwitchgearRevision;
            this.grdSwitchgearRevisionView.Name = "grdSwitchgearRevisionView";
            this.grdSwitchgearRevisionView.OptionsBehavior.Editable = false;
            this.grdSwitchgearRevisionView.OptionsCustomization.AllowGroup = false;
            this.grdSwitchgearRevisionView.OptionsMenu.EnableColumnMenu = false;
            this.grdSwitchgearRevisionView.OptionsMenu.EnableFooterMenu = false;
            this.grdSwitchgearRevisionView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdSwitchgearRevisionView.OptionsView.ColumnAutoWidth = false;
            this.grdSwitchgearRevisionView.OptionsView.ShowFooter = true;
            this.grdSwitchgearRevisionView.OptionsView.ShowGroupPanel = false;
            this.grdSwitchgearRevisionView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdSwitchgearRevisionView_FocusedRowChanged);
            this.grdSwitchgearRevisionView.DoubleClick += new System.EventHandler(this.grdSwitchgearRevisionView_DoubleClick);
            this.grdSwitchgearRevisionView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdSwitchgearRevisionView_KeyDown);
            this.grdSwitchgearRevisionView.ColumnFilterChanged += new System.EventHandler(this.grdSwitchgearRevisionView_ColumnFilterChanged);
            this.grdSwitchgearRevisionView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdSwitchgearRevisionView_ColumnWidthChanged);
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemMemoExEdit2
            // 
            this.repositoryItemMemoExEdit2.AutoHeight = false;
            this.repositoryItemMemoExEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repositoryItemMemoExEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit2.MaxLength = 128;
            this.repositoryItemMemoExEdit2.Name = "repositoryItemMemoExEdit2";
            // 
            // repositoryItemTextEdit7
            // 
            this.repositoryItemTextEdit7.AutoHeight = false;
            this.repositoryItemTextEdit7.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit7.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit7.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit7.Mask.EditMask = "c2";
            this.repositoryItemTextEdit7.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit7.Name = "repositoryItemTextEdit7";
            // 
            // repositoryItemTextEdit8
            // 
            this.repositoryItemTextEdit8.AutoHeight = false;
            this.repositoryItemTextEdit8.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit8.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit8.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit8.Mask.EditMask = "c2";
            this.repositoryItemTextEdit8.Name = "repositoryItemTextEdit8";
            // 
            // repositoryItemTextEdit9
            // 
            this.repositoryItemTextEdit9.AutoHeight = false;
            this.repositoryItemTextEdit9.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit9.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit9.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit9.Mask.EditMask = "c2";
            this.repositoryItemTextEdit9.Name = "repositoryItemTextEdit9";
            // 
            // repositoryItemTextEdit10
            // 
            this.repositoryItemTextEdit10.AutoHeight = false;
            this.repositoryItemTextEdit10.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit10.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit10.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit10.Mask.EditMask = "n0";
            this.repositoryItemTextEdit10.Name = "repositoryItemTextEdit10";
            // 
            // repositoryItemTextEdit11
            // 
            this.repositoryItemTextEdit11.AutoHeight = false;
            this.repositoryItemTextEdit11.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit11.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit11.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit11.Mask.EditMask = "n0";
            this.repositoryItemTextEdit11.Name = "repositoryItemTextEdit11";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "C",
            "E",
            "H",
            "M"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemTextEdit12
            // 
            this.repositoryItemTextEdit12.AutoHeight = false;
            this.repositoryItemTextEdit12.MaxLength = 100;
            this.repositoryItemTextEdit12.Name = "repositoryItemTextEdit12";
            // 
            // panSwitchgear
            // 
            this.panSwitchgear.Controls.Add(this.btnOpenTemplate);
            this.panSwitchgear.Controls.Add(this.hyperLinkEdit3);
            this.panSwitchgear.Controls.Add(this.hyperLinkEdit1);
            this.panSwitchgear.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSwitchgear.Location = new System.Drawing.Point(0, 0);
            this.panSwitchgear.Name = "panSwitchgear";
            this.panSwitchgear.Size = new System.Drawing.Size(965, 23);
            this.panSwitchgear.TabIndex = 455;
            // 
            // hyperLinkEdit3
            // 
            this.hyperLinkEdit3.EditValue = "Import Switchgear ...";
            this.hyperLinkEdit3.Location = new System.Drawing.Point(173, 3);
            this.hyperLinkEdit3.Name = "hyperLinkEdit3";
            this.hyperLinkEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit3.Size = new System.Drawing.Size(129, 18);
            this.hyperLinkEdit3.TabIndex = 9;
            this.hyperLinkEdit3.Click += new System.EventHandler(this.hyperLinkEdit3_Click);
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "New Switchgear ...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(103, 18);
            this.hyperLinkEdit1.TabIndex = 8;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // panSwitchgearRelease
            // 
            this.panSwitchgearRelease.Controls.Add(this.hyperLinkEdit2);
            this.panSwitchgearRelease.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSwitchgearRelease.Location = new System.Drawing.Point(0, 0);
            this.panSwitchgearRelease.Name = "panSwitchgearRelease";
            this.panSwitchgearRelease.Size = new System.Drawing.Size(965, 23);
            this.panSwitchgearRelease.TabIndex = 458;
            // 
            // hyperLinkEdit2
            // 
            this.hyperLinkEdit2.EditValue = "New Switchgear Release...";
            this.hyperLinkEdit2.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit2.Name = "hyperLinkEdit2";
            this.hyperLinkEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit2.Size = new System.Drawing.Size(170, 18);
            this.hyperLinkEdit2.TabIndex = 8;
            this.hyperLinkEdit2.Click += new System.EventHandler(this.hyperLinkEdit2_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(974, 551);
            this.xtraTabControl1.TabIndex = 458;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.grdSwitchgear);
            this.xtraTabPage1.Controls.Add(this.panSwitchgear);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(965, 520);
            this.xtraTabPage1.Text = "Switchgear";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.grdSwitchgearRelease);
            this.xtraTabPage2.Controls.Add(this.panSwitchgearRelease);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(965, 520);
            this.xtraTabPage2.Text = "Releases";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.grdSwitchgearRevision);
            this.xtraTabPage3.Controls.Add(this.panSwitchgearRevision);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(965, 520);
            this.xtraTabPage3.Text = "Revision";
            // 
            // panSwitchgearRevision
            // 
            this.panSwitchgearRevision.Controls.Add(this.hyperLinkEdit4);
            this.panSwitchgearRevision.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSwitchgearRevision.Location = new System.Drawing.Point(0, 0);
            this.panSwitchgearRevision.Name = "panSwitchgearRevision";
            this.panSwitchgearRevision.Size = new System.Drawing.Size(965, 23);
            this.panSwitchgearRevision.TabIndex = 459;
            // 
            // hyperLinkEdit4
            // 
            this.hyperLinkEdit4.EditValue = "New Switchgear Revision...";
            this.hyperLinkEdit4.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit4.Name = "hyperLinkEdit4";
            this.hyperLinkEdit4.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit4.Size = new System.Drawing.Size(170, 18);
            this.hyperLinkEdit4.TabIndex = 8;
            this.hyperLinkEdit4.Click += new System.EventHandler(this.hyperLinkEdit4_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // btnOpenTemplate
            // 
            this.btnOpenTemplate.EditValue = "Open Template ...";
            this.btnOpenTemplate.Location = new System.Drawing.Point(327, 3);
            this.btnOpenTemplate.Name = "btnOpenTemplate";
            this.btnOpenTemplate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenTemplate.Properties.Appearance.Options.UseBackColor = true;
            this.btnOpenTemplate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOpenTemplate.Size = new System.Drawing.Size(129, 18);
            this.btnOpenTemplate.TabIndex = 11;
            this.btnOpenTemplate.Click += new System.EventHandler(this.btnOpenTemplate_Click);
            // 
            // ctlJobSwitchgear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ctlJobSwitchgear";
            this.Size = new System.Drawing.Size(974, 551);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearReleaseDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearReleaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRevisionDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSwitchgearRevisionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgear)).EndInit();
            this.panSwitchgear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgearRelease)).EndInit();
            this.panSwitchgearRelease.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panSwitchgearRevision)).EndInit();
            this.panSwitchgearRevision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenTemplate.Properties)).EndInit();
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
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panSwitchgearRelease;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit2;
        private DevExpress.XtraGrid.GridControl grdSwitchgearRelease;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSwitchgearReleaseDetailView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSwitchgearReleaseView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit3;
        private System.Windows.Forms.OpenFileDialog openFile;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.PanelControl panSwitchgearRevision;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit4;
        private DevExpress.XtraGrid.GridControl grdSwitchgearRevision;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSwitchgearRevisionDetailView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSwitchgearRevisionView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit11;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit12;
        private DevExpress.XtraEditors.HyperLinkEdit btnOpenTemplate;
    }
}
