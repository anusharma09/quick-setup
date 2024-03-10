namespace CCEOTProjects.Controls
{
    partial class ctlProjectNotes
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdNoteView, "ctlProjectNotes");
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
            this.grdNote = new DevExpress.XtraGrid.GridControl();
            this.grdNoteView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoteView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // grdNote
            // 
            this.grdNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNote.Location = new System.Drawing.Point(0, 0);
            this.grdNote.MainView = this.grdNoteView;
            this.grdNote.Name = "grdNote";
            this.grdNote.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repEdit});
            this.grdNote.Size = new System.Drawing.Size(720, 563);
            this.grdNote.TabIndex = 450;
            this.grdNote.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdNoteView});
            // 
            // grdNoteView
            // 
            this.grdNoteView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdNoteView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdNoteView.GridControl = this.grdNote;
            this.grdNoteView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.grdNoteView.Name = "grdNoteView";
            this.grdNoteView.OptionsCustomization.AllowGroup = false;
            this.grdNoteView.OptionsView.ColumnAutoWidth = false;
            this.grdNoteView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdNoteView.OptionsView.ShowGroupPanel = false;
            this.grdNoteView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdNoteView_FocusedRowChanged);
            this.grdNoteView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdNoteView_MouseUp);
            this.grdNoteView.ColumnFilterChanged += new System.EventHandler(this.grdNoteView_ColumnFilterChanged);
            this.grdNoteView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdNoteView_InvalidRowException);
            this.grdNoteView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdNoteView_ColumnWidthChanged);
            this.grdNoteView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdNoteView_ValidateRow);
            // 
            // repEdit
            // 
            this.repEdit.MaxLength = 4000;
            this.repEdit.Name = "repEdit";
            // 
            // ctlProjectNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdNote);
            this.Name = "ctlProjectNotes";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoteView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdNote;
        private DevExpress.XtraGrid.Views.Grid.GridView grdNoteView;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repEdit;

    }
}
