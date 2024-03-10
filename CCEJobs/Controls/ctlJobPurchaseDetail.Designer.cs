namespace CCEJobs.Controls
{
    partial class ctlJobPurchaseDetail
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
                switch (radioGroup.SelectedIndex)
                {
                    case 4:
                        Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail4");
                        break;
                    case 5:
                        Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail5");
                        break;
                    case 6:
                        Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail6");
                        break;
                    default:
                        Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdPurchaseSummaryView, "ctlJobPurchaseDetail4");
                        break;

                }
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdBillSummaryCheckView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdPurchaseSummary = new DevExpress.XtraGrid.GridControl();
            this.grdPurchaseSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repComment = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdPurchaseSummaryItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgressPhaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgressLaborView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryCheckView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseSummaryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseSummaryItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressLaborView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBillSummaryCheckView
            // 
            this.grdBillSummaryCheckView.GridControl = this.grdPurchaseSummary;
            this.grdBillSummaryCheckView.Name = "grdBillSummaryCheckView";
            this.grdBillSummaryCheckView.DoubleClick += new System.EventHandler(this.grdBillSummaryCheckView_DoubleClick);
            // 
            // grdPurchaseSummary
            // 
            this.grdPurchaseSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grdBillSummaryCheckView;
            gridLevelNode1.RelationName = "Level1";
            this.grdPurchaseSummary.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdPurchaseSummary.Location = new System.Drawing.Point(0, 29);
            this.grdPurchaseSummary.MainView = this.grdPurchaseSummaryView;
            this.grdPurchaseSummary.Name = "grdPurchaseSummary";
            this.grdPurchaseSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repComment});
            this.grdPurchaseSummary.Size = new System.Drawing.Size(819, 534);
            this.grdPurchaseSummary.TabIndex = 16;
            this.grdPurchaseSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPurchaseSummaryView,
            this.grdPurchaseSummaryItems,
            this.grdJobProgressPhaseView,
            this.grdJobProgressLaborView,
            this.grdBillSummaryCheckView});
            // 
            // grdPurchaseSummaryView
            // 
            this.grdPurchaseSummaryView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdPurchaseSummaryView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdPurchaseSummaryView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdPurchaseSummaryView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdPurchaseSummaryView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdPurchaseSummaryView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdPurchaseSummaryView.GridControl = this.grdPurchaseSummary;
            this.grdPurchaseSummaryView.Name = "grdPurchaseSummaryView";
            this.grdPurchaseSummaryView.OptionsCustomization.AllowColumnMoving = false;
            this.grdPurchaseSummaryView.OptionsCustomization.AllowGroup = false;
            this.grdPurchaseSummaryView.OptionsMenu.EnableColumnMenu = false;
            this.grdPurchaseSummaryView.OptionsMenu.EnableFooterMenu = false;
            this.grdPurchaseSummaryView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdPurchaseSummaryView.OptionsView.ColumnAutoWidth = false;
            this.grdPurchaseSummaryView.OptionsView.ShowFooter = true;
            this.grdPurchaseSummaryView.OptionsView.ShowGroupPanel = false;
            this.grdPurchaseSummaryView.DoubleClick += new System.EventHandler(this.grdPurchaseSummaryView_DoubleClick);
            this.grdPurchaseSummaryView.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.grdBillSummaryView_MasterRowExpanded);
            this.grdPurchaseSummaryView.ColumnFilterChanged += new System.EventHandler(this.grdBillSummaryView_ColumnFilterChanged);
            this.grdPurchaseSummaryView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdPurchaseSummaryView_InvalidRowException);
            this.grdPurchaseSummaryView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdPurchaseSummaryView_ColumnWidthChanged);
            this.grdPurchaseSummaryView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdPurchaseSummaryView_ValidateRow);
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
            // repComment
            // 
            this.repComment.AutoHeight = false;
            this.repComment.MaxLength = 25;
            this.repComment.Name = "repComment";
            // 
            // grdPurchaseSummaryItems
            // 
            this.grdPurchaseSummaryItems.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdPurchaseSummaryItems.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdPurchaseSummaryItems.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdPurchaseSummaryItems.Appearance.FooterPanel.Options.UseFont = true;
            this.grdPurchaseSummaryItems.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdPurchaseSummaryItems.Appearance.GroupFooter.Options.UseFont = true;
            this.grdPurchaseSummaryItems.GridControl = this.grdPurchaseSummary;
            this.grdPurchaseSummaryItems.Name = "grdPurchaseSummaryItems";
            this.grdPurchaseSummaryItems.OptionsBehavior.Editable = false;
            this.grdPurchaseSummaryItems.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdPurchaseSummaryItems.OptionsCustomization.AllowColumnMoving = false;
            this.grdPurchaseSummaryItems.OptionsCustomization.AllowGroup = false;
            this.grdPurchaseSummaryItems.OptionsMenu.EnableColumnMenu = false;
            this.grdPurchaseSummaryItems.OptionsMenu.EnableFooterMenu = false;
            this.grdPurchaseSummaryItems.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdPurchaseSummaryItems.OptionsView.ColumnAutoWidth = false;
            this.grdPurchaseSummaryItems.OptionsView.ShowFooter = true;
            this.grdPurchaseSummaryItems.OptionsView.ShowGroupPanel = false;
            // 
            // grdJobProgressPhaseView
            // 
            this.grdJobProgressPhaseView.GridControl = this.grdPurchaseSummary;
            this.grdJobProgressPhaseView.Name = "grdJobProgressPhaseView";
            this.grdJobProgressPhaseView.OptionsBehavior.Editable = false;
            // 
            // grdJobProgressLaborView
            // 
            this.grdJobProgressLaborView.GridControl = this.grdPurchaseSummary;
            this.grdJobProgressLaborView.Name = "grdJobProgressLaborView";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.radioGroup);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(819, 29);
            this.panelControl2.TabIndex = 17;
            // 
            // radioGroup
            // 
            this.radioGroup.EditValue = 0;
            this.radioGroup.Location = new System.Drawing.Point(3, 3);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup.Properties.Appearance.Options.UseFont = true;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "POs"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "POs With Invoice"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "POs with No Invoice"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "POs With Rec Items"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Ord && Rec Items"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "POs Summary"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(6, "Invoices")});
            this.radioGroup.Size = new System.Drawing.Size(813, 24);
            this.radioGroup.TabIndex = 0;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // ctlJobPurchaseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdPurchaseSummary);
            this.Controls.Add(this.panelControl2);
            this.Name = "ctlJobPurchaseDetail";
            this.Size = new System.Drawing.Size(819, 563);
            this.Leave += new System.EventHandler(this.ctlJobPurchaseDetail_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.grdBillSummaryCheckView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseSummaryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurchaseSummaryItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressLaborView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPurchaseSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPurchaseSummaryView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
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
        private DevExpress.XtraGrid.Views.Grid.GridView grdPurchaseSummaryItems;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repComment;
    }
}
