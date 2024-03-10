namespace JCCLightFixture.Controls
{
    partial class ctlJobLightFixture
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureView, "ctlJobLightFixture");
            }
            if (bColumnWidthChangedRelease)
            {
                bColumnWidthChangedRelease = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureReleaseView, "ctlJobLightFixtureRelease");
            }
            if (bColumnWidthChangedRevision)
            {
                bColumnWidthChangedRevision = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureRevisionView, "ctlJobLightFixtureRevision");
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdLightFixtureDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLightFixture = new DevExpress.XtraGrid.GridControl();
            this.grdLightFixtureView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.grdLightFixtureReleaseDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLightFixtureRelease = new DevExpress.XtraGrid.GridControl();
            this.grdLightFixtureReleaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdLightFixtureRevisionDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLightFixtureRevision = new DevExpress.XtraGrid.GridControl();
            this.grdLightFixtureRevisionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panLightFixture = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit3 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.panLightFixtureRelease = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit2 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.panLightFixtureRevision = new DevExpress.XtraEditors.PanelControl();
            this.hyperLinkEdit4 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenTemplate = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureReleaseDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureReleaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRevisionDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRevisionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panLightFixture)).BeginInit();
            this.panLightFixture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panLightFixtureRelease)).BeginInit();
            this.panLightFixtureRelease.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panLightFixtureRevision)).BeginInit();
            this.panLightFixtureRevision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenTemplate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLightFixtureDetailView
            // 
            this.grdLightFixtureDetailView.GridControl = this.grdLightFixture;
            this.grdLightFixtureDetailView.Name = "grdLightFixtureDetailView";
            // 
            // grdLightFixture
            // 
            this.grdLightFixture.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode3.LevelTemplate = this.grdLightFixtureDetailView;
            gridLevelNode3.RelationName = "Level1";
            this.grdLightFixture.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.grdLightFixture.Location = new System.Drawing.Point(0, 23);
            this.grdLightFixture.MainView = this.grdLightFixtureView;
            this.grdLightFixture.Name = "grdLightFixture";
            this.grdLightFixture.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkSelectedItem,
            this.txtUserDescription,
            this.txtMaterialCost,
            this.txtLaborCost,
            this.txtOtherCost,
            this.txtQuantity,
            this.txtHours,
            this.cboUnit,
            this.txtUserDescription1});
            this.grdLightFixture.Size = new System.Drawing.Size(965, 497);
            this.grdLightFixture.TabIndex = 457;
            this.grdLightFixture.ToolTipController = this.toolTipController1;
            this.grdLightFixture.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdLightFixtureView,
            this.grdLightFixtureDetailView});
            // 
            // grdLightFixtureView
            // 
            this.grdLightFixtureView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdLightFixtureView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdLightFixtureView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdLightFixtureView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdLightFixtureView.GridControl = this.grdLightFixture;
            this.grdLightFixtureView.Name = "grdLightFixtureView";
            this.grdLightFixtureView.OptionsBehavior.Editable = false;
            this.grdLightFixtureView.OptionsCustomization.AllowGroup = false;
            this.grdLightFixtureView.OptionsMenu.EnableColumnMenu = false;
            this.grdLightFixtureView.OptionsMenu.EnableFooterMenu = false;
            this.grdLightFixtureView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdLightFixtureView.OptionsView.ColumnAutoWidth = false;
            this.grdLightFixtureView.OptionsView.ShowFooter = true;
            this.grdLightFixtureView.OptionsView.ShowGroupPanel = false;
            this.grdLightFixtureView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdLightFixtureView_FocusedRowChanged);
            this.grdLightFixtureView.DoubleClick += new System.EventHandler(this.grdLightFixtureView_DoubleClick);
            this.grdLightFixtureView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLightFixtureView_KeyDown);
            this.grdLightFixtureView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdLightFixtureView_MouseUp);
            this.grdLightFixtureView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdLightFixtureView_MasterRowExpanded);
            this.grdLightFixtureView.ColumnFilterChanged += new System.EventHandler(this.grdLightFixtureView_ColumnFilterChanged);
            this.grdLightFixtureView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdLightFixtureView_ColumnWidthChanged);
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
            // grdLightFixtureReleaseDetailView
            // 
            this.grdLightFixtureReleaseDetailView.GridControl = this.grdLightFixtureRelease;
            this.grdLightFixtureReleaseDetailView.Name = "grdLightFixtureReleaseDetailView";
            // 
            // grdLightFixtureRelease
            // 
            this.grdLightFixtureRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode4.LevelTemplate = this.grdLightFixtureReleaseDetailView;
            gridLevelNode4.RelationName = "Level1";
            this.grdLightFixtureRelease.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode4});
            this.grdLightFixtureRelease.Location = new System.Drawing.Point(0, 23);
            this.grdLightFixtureRelease.MainView = this.grdLightFixtureReleaseView;
            this.grdLightFixtureRelease.Name = "grdLightFixtureRelease";
            this.grdLightFixtureRelease.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit6});
            this.grdLightFixtureRelease.Size = new System.Drawing.Size(965, 497);
            this.grdLightFixtureRelease.TabIndex = 459;
            this.grdLightFixtureRelease.ToolTipController = this.toolTipController1;
            this.grdLightFixtureRelease.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdLightFixtureReleaseView,
            this.grdLightFixtureReleaseDetailView});
            // 
            // grdLightFixtureReleaseView
            // 
            this.grdLightFixtureReleaseView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdLightFixtureReleaseView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdLightFixtureReleaseView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdLightFixtureReleaseView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdLightFixtureReleaseView.GridControl = this.grdLightFixtureRelease;
            this.grdLightFixtureReleaseView.Name = "grdLightFixtureReleaseView";
            this.grdLightFixtureReleaseView.OptionsBehavior.Editable = false;
            this.grdLightFixtureReleaseView.OptionsCustomization.AllowGroup = false;
            this.grdLightFixtureReleaseView.OptionsMenu.EnableColumnMenu = false;
            this.grdLightFixtureReleaseView.OptionsMenu.EnableFooterMenu = false;
            this.grdLightFixtureReleaseView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdLightFixtureReleaseView.OptionsView.ColumnAutoWidth = false;
            this.grdLightFixtureReleaseView.OptionsView.ShowFooter = true;
            this.grdLightFixtureReleaseView.OptionsView.ShowGroupPanel = false;
            this.grdLightFixtureReleaseView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdLightFixtureReleaseView_FocusedRowChanged);
            this.grdLightFixtureReleaseView.DoubleClick += new System.EventHandler(this.grdLightFixtureReleaseView_DoubleClick);
            this.grdLightFixtureReleaseView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLightFixtureReleaseView_KeyDown);
            this.grdLightFixtureReleaseView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdLightFixtureReleaseView_MouseUp);
            this.grdLightFixtureReleaseView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdLightFixtureReleaseView_MasterRowExpanded);
            this.grdLightFixtureReleaseView.ColumnFilterChanged += new System.EventHandler(this.grdLightFixtureReleaseView_ColumnFilterChanged);
            this.grdLightFixtureReleaseView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdLightFixtureReleaseView_ColumnWidthChanged);
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
            // grdLightFixtureRevisionDetailView
            // 
            this.grdLightFixtureRevisionDetailView.GridControl = this.grdLightFixtureRevision;
            this.grdLightFixtureRevisionDetailView.Name = "grdLightFixtureRevisionDetailView";
            // 
            // grdLightFixtureRevision
            // 
            this.grdLightFixtureRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grdLightFixtureRevisionDetailView;
            gridLevelNode1.RelationName = "Level1";
            this.grdLightFixtureRevision.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdLightFixtureRevision.Location = new System.Drawing.Point(0, 23);
            this.grdLightFixtureRevision.MainView = this.grdLightFixtureRevisionView;
            this.grdLightFixtureRevision.Name = "grdLightFixtureRevision";
            this.grdLightFixtureRevision.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemMemoExEdit2,
            this.repositoryItemTextEdit7,
            this.repositoryItemTextEdit8,
            this.repositoryItemTextEdit9,
            this.repositoryItemTextEdit10,
            this.repositoryItemTextEdit11,
            this.repositoryItemComboBox2,
            this.repositoryItemTextEdit12});
            this.grdLightFixtureRevision.Size = new System.Drawing.Size(965, 497);
            this.grdLightFixtureRevision.TabIndex = 460;
            this.grdLightFixtureRevision.ToolTipController = this.toolTipController1;
            this.grdLightFixtureRevision.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdLightFixtureRevisionView,
            this.grdLightFixtureRevisionDetailView});
            // 
            // grdLightFixtureRevisionView
            // 
            this.grdLightFixtureRevisionView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdLightFixtureRevisionView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdLightFixtureRevisionView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdLightFixtureRevisionView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdLightFixtureRevisionView.GridControl = this.grdLightFixtureRevision;
            this.grdLightFixtureRevisionView.Name = "grdLightFixtureRevisionView";
            this.grdLightFixtureRevisionView.OptionsBehavior.Editable = false;
            this.grdLightFixtureRevisionView.OptionsCustomization.AllowGroup = false;
            this.grdLightFixtureRevisionView.OptionsMenu.EnableColumnMenu = false;
            this.grdLightFixtureRevisionView.OptionsMenu.EnableFooterMenu = false;
            this.grdLightFixtureRevisionView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdLightFixtureRevisionView.OptionsView.ColumnAutoWidth = false;
            this.grdLightFixtureRevisionView.OptionsView.ShowFooter = true;
            this.grdLightFixtureRevisionView.OptionsView.ShowGroupPanel = false;
            this.grdLightFixtureRevisionView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdLightFixtureRevisionView_FocusedRowChanged);
            this.grdLightFixtureRevisionView.DoubleClick += new System.EventHandler(this.grdLightFixtureRevisionView_DoubleClick);
            this.grdLightFixtureRevisionView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLightFixtureRevisionView_KeyDown);
            this.grdLightFixtureRevisionView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdLightFixtureRevisionView_MouseUp);
            this.grdLightFixtureRevisionView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdLightFixtureRevisionView_MasterRowExpanded);
            this.grdLightFixtureRevisionView.ColumnFilterChanged += new System.EventHandler(this.grdLightFixtureRevisionView_ColumnFilterChanged);
            this.grdLightFixtureRevisionView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdLightFixtureRevisionView_ColumnWidthChanged);
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
            // panLightFixture
            // 
            this.panLightFixture.Controls.Add(this.btnOpenTemplate);
            this.panLightFixture.Controls.Add(this.hyperLinkEdit3);
            this.panLightFixture.Controls.Add(this.hyperLinkEdit1);
            this.panLightFixture.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLightFixture.Location = new System.Drawing.Point(0, 0);
            this.panLightFixture.Name = "panLightFixture";
            this.panLightFixture.Size = new System.Drawing.Size(965, 23);
            this.panLightFixture.TabIndex = 455;
            // 
            // hyperLinkEdit3
            // 
            this.hyperLinkEdit3.EditValue = "Import Light Fixture ...";
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
            this.hyperLinkEdit1.EditValue = "New Light Fixture ...";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(5, 3);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLinkEdit1.Size = new System.Drawing.Size(103, 18);
            this.hyperLinkEdit1.TabIndex = 8;
            this.hyperLinkEdit1.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // panLightFixtureRelease
            // 
            this.panLightFixtureRelease.Controls.Add(this.hyperLinkEdit2);
            this.panLightFixtureRelease.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLightFixtureRelease.Location = new System.Drawing.Point(0, 0);
            this.panLightFixtureRelease.Name = "panLightFixtureRelease";
            this.panLightFixtureRelease.Size = new System.Drawing.Size(965, 23);
            this.panLightFixtureRelease.TabIndex = 458;
            // 
            // hyperLinkEdit2
            // 
            this.hyperLinkEdit2.EditValue = "New Light Fixture Release...";
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
            this.xtraTabPage1.Controls.Add(this.grdLightFixture);
            this.xtraTabPage1.Controls.Add(this.panLightFixture);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(965, 520);
            this.xtraTabPage1.Text = "Light Fixtures";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.grdLightFixtureRelease);
            this.xtraTabPage2.Controls.Add(this.panLightFixtureRelease);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(965, 520);
            this.xtraTabPage2.Text = "Releases";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.grdLightFixtureRevision);
            this.xtraTabPage3.Controls.Add(this.panLightFixtureRevision);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(965, 520);
            this.xtraTabPage3.Text = "Revisions";
            // 
            // panLightFixtureRevision
            // 
            this.panLightFixtureRevision.Controls.Add(this.hyperLinkEdit4);
            this.panLightFixtureRevision.Dock = System.Windows.Forms.DockStyle.Top;
            this.panLightFixtureRevision.Location = new System.Drawing.Point(0, 0);
            this.panLightFixtureRevision.Name = "panLightFixtureRevision";
            this.panLightFixtureRevision.Size = new System.Drawing.Size(965, 23);
            this.panLightFixtureRevision.TabIndex = 459;
            // 
            // hyperLinkEdit4
            // 
            this.hyperLinkEdit4.EditValue = "New Light Fixture Revision...";
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
            this.btnOpenTemplate.Location = new System.Drawing.Point(335, 3);
            this.btnOpenTemplate.Name = "btnOpenTemplate";
            this.btnOpenTemplate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenTemplate.Properties.Appearance.Options.UseBackColor = true;
            this.btnOpenTemplate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOpenTemplate.Size = new System.Drawing.Size(129, 18);
            this.btnOpenTemplate.TabIndex = 10;
            this.btnOpenTemplate.Click += new System.EventHandler(this.btnOpenTemplate_Click);
            // 
            // ctlJobLightFixture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ctlJobLightFixture";
            this.Size = new System.Drawing.Size(974, 551);
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureReleaseDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureReleaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRevisionDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLightFixtureRevisionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panLightFixture)).EndInit();
            this.panLightFixture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panLightFixtureRelease)).EndInit();
            this.panLightFixtureRelease.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panLightFixtureRevision)).EndInit();
            this.panLightFixtureRevision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenTemplate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl panLightFixture;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraGrid.GridControl grdLightFixture;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLightFixtureView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelectedItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit txtUserDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMaterialCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtLaborCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtOtherCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtUserDescription1;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLightFixtureDetailView;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panLightFixtureRelease;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit2;
        private DevExpress.XtraGrid.GridControl grdLightFixtureRelease;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLightFixtureReleaseDetailView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLightFixtureReleaseView;
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
        private DevExpress.XtraGrid.GridControl grdLightFixtureRevision;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLightFixtureRevisionDetailView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLightFixtureRevisionView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit10;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit11;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit12;
        private DevExpress.XtraEditors.PanelControl panLightFixtureRevision;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit4;
        private DevExpress.XtraEditors.HyperLinkEdit btnOpenTemplate;
    }
}
