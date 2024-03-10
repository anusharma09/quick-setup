namespace CCEJobs.Controls
{
    partial class ctlJobSubcontractsInvoices
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSubcontractsInvoicesView, "ctlJobSubcontractsInvoices");
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
            this.grdInvoicesNoPOPaymentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSubcontractsInvoices = new DevExpress.XtraGrid.GridControl();
            this.grdSubcontractsInvoicesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdJobProgressPhaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgressLaborView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoicesNoPOPaymentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractsInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractsInvoicesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressLaborView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdInvoicesNoPOPaymentView
            // 
            this.grdInvoicesNoPOPaymentView.GridControl = this.grdSubcontractsInvoices;
            this.grdInvoicesNoPOPaymentView.Name = "grdInvoicesNoPOPaymentView";
            // 
            // grdSubcontractsInvoices
            // 
            this.grdSubcontractsInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grdInvoicesNoPOPaymentView;
            gridLevelNode1.RelationName = "Level1";
            this.grdSubcontractsInvoices.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdSubcontractsInvoices.Location = new System.Drawing.Point(0, 0);
            this.grdSubcontractsInvoices.MainView = this.grdSubcontractsInvoicesView;
            this.grdSubcontractsInvoices.Name = "grdSubcontractsInvoices";
            this.grdSubcontractsInvoices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5});
            this.grdSubcontractsInvoices.Size = new System.Drawing.Size(691, 563);
            this.grdSubcontractsInvoices.TabIndex = 16;
            this.grdSubcontractsInvoices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSubcontractsInvoicesView,
            this.grdJobProgressPhaseView,
            this.grdJobProgressLaborView,
            this.grdInvoicesNoPOPaymentView});
            // 
            // grdSubcontractsInvoicesView
            // 
            this.grdSubcontractsInvoicesView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdSubcontractsInvoicesView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdSubcontractsInvoicesView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdSubcontractsInvoicesView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdSubcontractsInvoicesView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdSubcontractsInvoicesView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdSubcontractsInvoicesView.GridControl = this.grdSubcontractsInvoices;
            this.grdSubcontractsInvoicesView.Name = "grdSubcontractsInvoicesView";
            this.grdSubcontractsInvoicesView.OptionsBehavior.Editable = false;
            this.grdSubcontractsInvoicesView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdSubcontractsInvoicesView.OptionsCustomization.AllowColumnMoving = false;
            this.grdSubcontractsInvoicesView.OptionsCustomization.AllowGroup = false;
            this.grdSubcontractsInvoicesView.OptionsMenu.EnableColumnMenu = false;
            this.grdSubcontractsInvoicesView.OptionsMenu.EnableFooterMenu = false;
            this.grdSubcontractsInvoicesView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdSubcontractsInvoicesView.OptionsView.ColumnAutoWidth = false;
            this.grdSubcontractsInvoicesView.OptionsView.ShowFooter = true;
            this.grdSubcontractsInvoicesView.OptionsView.ShowGroupPanel = false;
            this.grdSubcontractsInvoicesView.ColumnFilterChanged += new System.EventHandler(this.grdBillSummaryView_ColumnFilterChanged);
            this.grdSubcontractsInvoicesView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdSubcontractsInvoicesView_ColumnWidthChanged);
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
            // grdJobProgressPhaseView
            // 
            this.grdJobProgressPhaseView.GridControl = this.grdSubcontractsInvoices;
            this.grdJobProgressPhaseView.Name = "grdJobProgressPhaseView";
            this.grdJobProgressPhaseView.OptionsBehavior.Editable = false;
            // 
            // grdJobProgressLaborView
            // 
            this.grdJobProgressLaborView.GridControl = this.grdSubcontractsInvoices;
            this.grdJobProgressLaborView.Name = "grdJobProgressLaborView";
            // 
            // ctlJobSubcontractsInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdSubcontractsInvoices);
            this.Name = "ctlJobSubcontractsInvoices";
            this.Size = new System.Drawing.Size(691, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoicesNoPOPaymentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractsInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractsInvoicesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressPhaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressLaborView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSubcontractsInvoices;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSubcontractsInvoicesView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressPhaseView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressLaborView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdInvoicesNoPOPaymentView;
    }
}
