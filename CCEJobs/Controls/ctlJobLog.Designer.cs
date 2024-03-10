namespace CCEJobs.Controls
{
    partial class ctlJobLog
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
            this.grdJobLog = new DevExpress.XtraGrid.GridControl();
            this.grdJobLogView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdJobProgressPhaseView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdJobProgressLaborView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobLogView)).BeginInit();
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
            // grdJobLog
            // 
            this.grdJobLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobLog.EmbeddedNavigator.Name = "";
            this.grdJobLog.Location = new System.Drawing.Point(0, 0);
            this.grdJobLog.MainView = this.grdJobLogView;
            this.grdJobLog.Name = "grdJobLog";
            this.grdJobLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5});
            this.grdJobLog.Size = new System.Drawing.Size(720, 563);
            this.grdJobLog.TabIndex = 16;
            this.grdJobLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobLogView,
            this.grdJobProgressPhaseView,
            this.grdJobProgressLaborView});
            // 
            // grdJobLogView
            // 
            this.grdJobLogView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grdJobLogView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobLogView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdJobLogView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobLogView.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobLogView.Appearance.GroupFooter.Options.UseFont = true;
            this.grdJobLogView.GridControl = this.grdJobLog;
            this.grdJobLogView.Name = "grdJobLogView";
            this.grdJobLogView.OptionsBehavior.Editable = false;
            this.grdJobLogView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.grdJobLogView.OptionsCustomization.AllowColumnMoving = false;
            this.grdJobLogView.OptionsCustomization.AllowGroup = false;
            this.grdJobLogView.OptionsMenu.EnableColumnMenu = false;
            this.grdJobLogView.OptionsMenu.EnableFooterMenu = false;
            this.grdJobLogView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdJobLogView.OptionsView.ColumnAutoWidth = false;
            this.grdJobLogView.OptionsView.ShowFooter = true;
            this.grdJobLogView.OptionsView.ShowGroupPanel = false;
            this.grdJobLogView.ColumnFilterChanged += new System.EventHandler(this.grdJobLogView_ColumnFilterChanged);
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
            this.grdJobProgressPhaseView.GridControl = this.grdJobLog;
            this.grdJobProgressPhaseView.Name = "grdJobProgressPhaseView";
            this.grdJobProgressPhaseView.OptionsBehavior.Editable = false;
            // 
            // grdJobProgressLaborView
            // 
            this.grdJobProgressLaborView.GridControl = this.grdJobLog;
            this.grdJobProgressLaborView.Name = "grdJobProgressLaborView";
            // 
            // ctlJobLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobLog);
            this.Name = "ctlJobLog";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobLogView)).EndInit();
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

        private DevExpress.XtraGrid.GridControl grdJobLog;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobLogView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressPhaseView;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressLaborView;
    }
}
