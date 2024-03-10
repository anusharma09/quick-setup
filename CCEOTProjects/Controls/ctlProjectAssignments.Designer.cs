namespace CCEOTProjects.Controls
{
    partial class ctlProjectAssignments
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdAssignmentView, "ctlProjectAssignments");
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
            this.grdAssignment = new DevExpress.XtraGrid.GridControl();
            this.grdAssignmentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAssignment
            // 
            this.grdAssignment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAssignment.Location = new System.Drawing.Point(0, 0);
            this.grdAssignment.MainView = this.grdAssignmentView;
            this.grdAssignment.Name = "grdAssignment";
            this.grdAssignment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repEdit,
            this.repDate});
            this.grdAssignment.Size = new System.Drawing.Size(720, 563);
            this.grdAssignment.TabIndex = 450;
            this.grdAssignment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAssignmentView});
            // 
            // grdAssignmentView
            // 
            this.grdAssignmentView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdAssignmentView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdAssignmentView.GridControl = this.grdAssignment;
            this.grdAssignmentView.Name = "grdAssignmentView";
            this.grdAssignmentView.OptionsCustomization.AllowGroup = false;
            this.grdAssignmentView.OptionsView.ColumnAutoWidth = false;
            this.grdAssignmentView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdAssignmentView.OptionsView.ShowGroupPanel = false;
            this.grdAssignmentView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdAssignmentView_FocusedRowChanged);
            this.grdAssignmentView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdAssignmentView_CellValueChanged);
            this.grdAssignmentView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdAssignmentView_MouseUp);
            this.grdAssignmentView.ColumnFilterChanged += new System.EventHandler(this.grdAssignmentView_ColumnFilterChanged);
            this.grdAssignmentView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdAssignmentView_InvalidRowException);
            this.grdAssignmentView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdAssignmentView_ColumnWidthChanged);
            this.grdAssignmentView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdAssignmentView_ValidateRow);
            // 
            // repEdit
            // 
            this.repEdit.AutoHeight = false;
            this.repEdit.MaxLength = 100;
            this.repEdit.Name = "repEdit";
            // 
            // repDate
            // 
            this.repDate.AutoHeight = false;
            this.repDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDate.DisplayFormat.FormatString = "g";
            this.repDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repDate.EditFormat.FormatString = "g";
            this.repDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repDate.Mask.EditMask = "g";
            this.repDate.Mask.UseMaskAsDisplayFormat = true;
            this.repDate.Name = "repDate";
            this.repDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ctlProjectAssignments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.grdAssignment);
            this.Name = "ctlProjectAssignments";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAssignment;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAssignmentView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repDate;

    }
}
