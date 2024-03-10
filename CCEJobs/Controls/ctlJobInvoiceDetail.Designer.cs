namespace CCEJobs.Controls
{
    partial class ctlJobInvoiceDetail
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdBillSummaryView, "ctlJobInvoiceDetail");
            }

            if (bColumnWidthChangedd)
            {
                bColumnWidthChangedd = false;
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdBillSummaryAgingView, "ctlJobInvoiceDetailAging");
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdBillSummaryCheckView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdBillSummary = new DevExpress.XtraGrid.GridControl();
            this.grdBillSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repComment = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdJobProgressPhaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgressLaborView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.grdBillSummaryAging = new DevExpress.XtraGrid.GridControl();
            this.grdBillSummaryAgingView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryCheckView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressLaborView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryAging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryAgingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBillSummaryCheckView
            // 
            this.grdBillSummaryCheckView.GridControl = this.grdBillSummary;
            this.grdBillSummaryCheckView.Name = "grdBillSummaryCheckView";
            // 
            // grdBillSummary
            // 
            gridLevelNode2.LevelTemplate = this.grdBillSummaryCheckView;
            gridLevelNode2.RelationName = "Level1";
            this.grdBillSummary.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grdBillSummary.Location = new System.Drawing.Point(0, 29);
            this.grdBillSummary.MainView = this.grdBillSummaryView;
            this.grdBillSummary.Name = "grdBillSummary";
            this.grdBillSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repComment,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5});
            this.grdBillSummary.Size = new System.Drawing.Size(691, 225);
            this.grdBillSummary.TabIndex = 16;
            this.grdBillSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBillSummaryView,
            this.grdJobProgressPhaseView,
            this.grdJobProgressLaborView,
            this.grdBillSummaryCheckView});
            // 
            // grdBillSummaryView
            // 
            this.grdBillSummaryView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdBillSummaryView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdBillSummaryView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdBillSummaryView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdBillSummaryView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdBillSummaryView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdBillSummaryView.GridControl = this.grdBillSummary;
            this.grdBillSummaryView.Name = "grdBillSummaryView";
            this.grdBillSummaryView.OptionsBehavior.Editable = false;
            this.grdBillSummaryView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdBillSummaryView.OptionsCustomization.AllowColumnMoving = false;
            this.grdBillSummaryView.OptionsCustomization.AllowGroup = false;
            this.grdBillSummaryView.OptionsMenu.EnableColumnMenu = false;
            this.grdBillSummaryView.OptionsMenu.EnableFooterMenu = false;
            this.grdBillSummaryView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdBillSummaryView.OptionsView.ColumnAutoWidth = false;
            this.grdBillSummaryView.OptionsView.ShowFooter = true;
            this.grdBillSummaryView.OptionsView.ShowGroupPanel = false;
            this.grdBillSummaryView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdBillSummaryView_MasterRowExpanded);
            this.grdBillSummaryView.ColumnFilterChanged += new System.EventHandler(this.grdBillSummaryView_ColumnFilterChanged);
            this.grdBillSummaryView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdBillSummaryView_ColumnWidthChanged);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repComment
            // 
            this.repComment.AutoHeight = false;
            this.repComment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repComment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repComment.MaxLength = 4000;
            this.repComment.Name = "repComment";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "c2";
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
            // grdJobProgressPhaseView
            // 
            this.grdJobProgressPhaseView.GridControl = this.grdBillSummary;
            this.grdJobProgressPhaseView.Name = "grdJobProgressPhaseView";
            this.grdJobProgressPhaseView.OptionsBehavior.Editable = false;
            // 
            // grdJobProgressLaborView
            // 
            this.grdJobProgressLaborView.GridControl = this.grdBillSummary;
            this.grdJobProgressLaborView.Name = "grdJobProgressLaborView";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.radioGroup);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(691, 29);
            this.panelControl2.TabIndex = 17;
            // 
            // radioGroup
            // 
            this.radioGroup.EditValue = 0;
            this.radioGroup.Location = new System.Drawing.Point(3, 3);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Billing"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Include Payment"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Aging"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Include Comment")});
            this.radioGroup.Size = new System.Drawing.Size(411, 24);
            this.radioGroup.TabIndex = 0;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // grdBillSummaryAging
            // 
            this.grdBillSummaryAging.Location = new System.Drawing.Point(-3, 260);
            this.grdBillSummaryAging.MainView = this.grdBillSummaryAgingView;
            this.grdBillSummaryAging.Name = "grdBillSummaryAging";
            this.grdBillSummaryAging.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit6,
            this.repositoryItemTextEdit7,
            this.repositoryItemTextEdit8,
            this.repositoryItemTextEdit9,
            this.repositoryItemTextEdit10});
            this.grdBillSummaryAging.Size = new System.Drawing.Size(691, 225);
            this.grdBillSummaryAging.TabIndex = 18;
            this.grdBillSummaryAging.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBillSummaryAgingView,
            this.gridView1,
            this.gridView3,
            this.gridView4});
            // 
            // grdBillSummaryAgingView
            // 
            this.grdBillSummaryAgingView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdBillSummaryAgingView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdBillSummaryAgingView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdBillSummaryAgingView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdBillSummaryAgingView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdBillSummaryAgingView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdBillSummaryAgingView.GridControl = this.grdBillSummaryAging;
            this.grdBillSummaryAgingView.Name = "grdBillSummaryAgingView";
            this.grdBillSummaryAgingView.OptionsBehavior.Editable = false;
            this.grdBillSummaryAgingView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdBillSummaryAgingView.OptionsCustomization.AllowColumnMoving = false;
            this.grdBillSummaryAgingView.OptionsCustomization.AllowGroup = false;
            this.grdBillSummaryAgingView.OptionsMenu.EnableColumnMenu = false;
            this.grdBillSummaryAgingView.OptionsMenu.EnableFooterMenu = false;
            this.grdBillSummaryAgingView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdBillSummaryAgingView.OptionsView.ColumnAutoWidth = false;
            this.grdBillSummaryAgingView.OptionsView.ShowFooter = true;
            this.grdBillSummaryAgingView.OptionsView.ShowGroupPanel = false;
            this.grdBillSummaryAgingView.ColumnFilterChanged += new System.EventHandler(this.grdBillSummaryAgingView_ColumnFilterChanged);
            this.grdBillSummaryAgingView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdBillSummaryAgingView_ColumnWidthChanged);
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.MaxLength = 4000;
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.AutoHeight = false;
            this.repositoryItemTextEdit6.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit6.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit6.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit6.Mask.EditMask = "c2";
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            // 
            // repositoryItemTextEdit7
            // 
            this.repositoryItemTextEdit7.AutoHeight = false;
            this.repositoryItemTextEdit7.DisplayFormat.FormatString = "c2";
            this.repositoryItemTextEdit7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit7.EditFormat.FormatString = "c2";
            this.repositoryItemTextEdit7.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit7.Mask.EditMask = "c2";
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
            this.repositoryItemTextEdit9.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit9.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit9.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit9.Mask.EditMask = "n0";
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
            // gridView1
            // 
            this.gridView1.GridControl = this.grdBillSummaryAging;
            this.gridView1.Name = "gridView1";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grdBillSummaryAging;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grdBillSummaryAging;
            this.gridView4.Name = "gridView4";
            // 
            // ctlJobInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdBillSummaryAging);
            this.Controls.Add(this.grdBillSummary);
            this.Controls.Add(this.panelControl2);
            this.Name = "ctlJobInvoiceDetail";
            this.Size = new System.Drawing.Size(691, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryCheckView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressLaborView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryAging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryAgingView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBillSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBillSummaryView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repComment;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressPhaseView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressLaborView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBillSummaryCheckView;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private DevExpress.XtraGrid.GridControl grdBillSummaryAging;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBillSummaryAgingView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit10;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
    }
}
