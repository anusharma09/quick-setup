namespace CCEJobs.Controls
{
    partial class ctlJobCostAnalysis
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobCostAnalysisView, "ctlJobCostAnalysis");
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.radioType = new DevExpress.XtraEditors.RadioGroup();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.grdJobCostAnalysis = new DevExpress.XtraGrid.GridControl();
            this.grdJobCostAnalysisView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdJobProgressPhaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgressLaborView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCostAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCostAnalysisView)).BeginInit();
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
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.radioType);
            this.panelControl2.Controls.Add(this.radioGroup);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(720, 32);
            this.panelControl2.TabIndex = 15;
            // 
            // radioType
            // 
            this.radioType.EditValue = 0;
            this.radioType.Location = new System.Drawing.Point(295, 5);
            this.radioType.Name = "radioType";
            this.radioType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Detail"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Summary")});
            this.radioType.Size = new System.Drawing.Size(135, 26);
            this.radioType.TabIndex = 1;
            // 
            // radioGroup
            // 
            this.radioGroup.EditValue = 0;
            this.radioGroup.Location = new System.Drawing.Point(3, 5);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "List"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "App"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Phase"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Code"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Name"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "Date")});
            this.radioGroup.Size = new System.Drawing.Size(286, 27);
            this.radioGroup.TabIndex = 0;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup_SelectedIndexChanged);
            // 
            // grdJobCostAnalysis
            // 
            this.grdJobCostAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobCostAnalysis.Location = new System.Drawing.Point(0, 32);
            this.grdJobCostAnalysis.MainView = this.grdJobCostAnalysisView;
            this.grdJobCostAnalysis.Name = "grdJobCostAnalysis";
            this.grdJobCostAnalysis.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5});
            this.grdJobCostAnalysis.Size = new System.Drawing.Size(720, 531);
            this.grdJobCostAnalysis.TabIndex = 16;
            this.grdJobCostAnalysis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobCostAnalysisView,
            this.grdJobProgressPhaseView,
            this.grdJobProgressLaborView});
            // 
            // grdJobCostAnalysisView
            // 
            this.grdJobCostAnalysisView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdJobCostAnalysisView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobCostAnalysisView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdJobCostAnalysisView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobCostAnalysisView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobCostAnalysisView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdJobCostAnalysisView.GridControl = this.grdJobCostAnalysis;
            this.grdJobCostAnalysisView.Name = "grdJobCostAnalysisView";
            this.grdJobCostAnalysisView.OptionsBehavior.Editable = false;
            this.grdJobCostAnalysisView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdJobCostAnalysisView.OptionsCustomization.AllowColumnMoving = false;
            this.grdJobCostAnalysisView.OptionsCustomization.AllowGroup = false;
            this.grdJobCostAnalysisView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobCostAnalysisView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobCostAnalysisView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobCostAnalysisView.OptionsView.ColumnAutoWidth = false;
            this.grdJobCostAnalysisView.OptionsView.ShowFooter = true;
            this.grdJobCostAnalysisView.OptionsView.ShowGroupPanel = false;
            this.grdJobCostAnalysisView.ColumnFilterChanged += new System.EventHandler(this.grdLaborAnalysisView_ColumnFilterChanged);
            this.grdJobCostAnalysisView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdJobCostAnalysisView_ColumnWidthChanged);
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
            this.grdJobProgressPhaseView.GridControl = this.grdJobCostAnalysis;
            this.grdJobProgressPhaseView.Name = "grdJobProgressPhaseView";
            this.grdJobProgressPhaseView.OptionsBehavior.Editable = false;
            // 
            // grdJobProgressLaborView
            // 
            this.grdJobProgressLaborView.GridControl = this.grdJobCostAnalysis;
            this.grdJobProgressLaborView.Name = "grdJobProgressLaborView";
            // 
            // ctlJobCostAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobCostAnalysis);
            this.Controls.Add(this.panelControl2);
            this.Name = "ctlJobCostAnalysis";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCostAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobCostAnalysisView)).EndInit();
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

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdJobCostAnalysis;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobCostAnalysisView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressPhaseView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressLaborView;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private DevExpress.XtraEditors.RadioGroup radioType;
    }
}
