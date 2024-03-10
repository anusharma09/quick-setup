namespace CCEOTProjects.Controls
{
    partial class ctlProjectAudit
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdAuditView, "ctlProjectAudit");
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
            this.grdAudit = new DevExpress.XtraGrid.GridControl();
            this.grdAuditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAudit
            // 
            this.grdAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAudit.Location = new System.Drawing.Point(0, 0);
            this.grdAudit.MainView = this.grdAuditView;
            this.grdAudit.Name = "grdAudit";
            this.grdAudit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repEdit});
            this.grdAudit.Size = new System.Drawing.Size(720, 563);
            this.grdAudit.TabIndex = 450;
            this.grdAudit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAuditView});
            // 
            // grdAuditView
            // 
            this.grdAuditView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdAuditView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdAuditView.GridControl = this.grdAudit;
            this.grdAuditView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.grdAuditView.Name = "grdAuditView";
            this.grdAuditView.OptionsCustomization.AllowGroup = false;
            this.grdAuditView.OptionsView.ColumnAutoWidth = false;
            this.grdAuditView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdAuditView.OptionsView.ShowGroupPanel = false;
            this.grdAuditView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdNoteView_FocusedRowChanged);
            this.grdAuditView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdNoteView_MouseUp);
            this.grdAuditView.ColumnFilterChanged += new System.EventHandler(this.grdNoteView_ColumnFilterChanged);
            this.grdAuditView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdNoteView_InvalidRowException);
            this.grdAuditView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdAuditView_ColumnWidthChanged);
            // 
            // repEdit
            // 
            this.repEdit.MaxLength = 4000;
            this.repEdit.Name = "repEdit";
            // 
            // ctlProjectAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdAudit);
            this.Name = "ctlProjectAudit";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAudit;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAuditView;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repEdit;

    }
}
