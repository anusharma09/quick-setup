namespace CCEJobs.Controls
{
    partial class ctlJobProgressComment
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobProgressCommentView, "ctlJobProgressComment");
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
            this.grdJobProgressComment = new DevExpress.XtraGrid.GridControl();
            this.grdJobProgressCommentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressCommentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // grdJobProgressComment
            // 
            this.grdJobProgressComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdJobProgressComment.Location = new System.Drawing.Point(0, 0);
            this.grdJobProgressComment.MainView = this.grdJobProgressCommentView;
            this.grdJobProgressComment.Name = "grdJobProgressComment";
            this.grdJobProgressComment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repEdit});
            this.grdJobProgressComment.Size = new System.Drawing.Size(720, 563);
            this.grdJobProgressComment.TabIndex = 450;
            this.grdJobProgressComment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdJobProgressCommentView});
            // 
            // grdJobProgressCommentView
            // 
            this.grdJobProgressCommentView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdJobProgressCommentView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdJobProgressCommentView.GridControl = this.grdJobProgressComment;
            this.grdJobProgressCommentView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.grdJobProgressCommentView.Name = "grdJobProgressCommentView";
            this.grdJobProgressCommentView.OptionsCustomization.AllowGroup = false;
            this.grdJobProgressCommentView.OptionsView.ColumnAutoWidth = false;
            this.grdJobProgressCommentView.OptionsView.ShowGroupPanel = false;
            this.grdJobProgressCommentView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdJobProgressCommentView_MouseUp);
            this.grdJobProgressCommentView.ColumnFilterChanged += new System.EventHandler(this.grdJobProgressCommentView_ColumnFilterChanged);
            this.grdJobProgressCommentView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdJobProgressCommentView_ColumnWidthChanged);
            // 
            // repEdit
            // 
            this.repEdit.MaxLength = 4000;
            this.repEdit.Name = "repEdit";
            // 
            // ctlJobProgressComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdJobProgressComment);
            this.Name = "ctlJobProgressComment";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobProgressCommentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdJobProgressComment;
        private DevExpress.XtraGrid.Views.Grid.GridView grdJobProgressCommentView;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repEdit;

    }
}
