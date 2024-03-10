namespace JCCSubcontractDocument
{
    public partial class frmSubcontractMaintenance
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubcontractMaintenance));
            this.grdSubcontract = new DevExpress.XtraGrid.GridControl();
            this.grdSubcontractView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repSubcontract = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSubcontract)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSubcontract
            // 
            this.grdSubcontract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSubcontract.EmbeddedNavigator.Name = "";
            this.grdSubcontract.Location = new System.Drawing.Point(0, 0);
            this.grdSubcontract.MainView = this.grdSubcontractView;
            this.grdSubcontract.Name = "grdSubcontract";
            this.grdSubcontract.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSubcontract});
            this.grdSubcontract.Size = new System.Drawing.Size(498, 364);
            this.grdSubcontract.TabIndex = 450;
            this.grdSubcontract.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSubcontractView});
            // 
            // grdSubcontractView
            // 
            this.grdSubcontractView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdSubcontractView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdSubcontractView.GridControl = this.grdSubcontract;
            this.grdSubcontractView.Name = "grdSubcontractView";
            this.grdSubcontractView.OptionsView.ColumnAutoWidth = false;
            this.grdSubcontractView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdSubcontractView.OptionsView.ShowGroupPanel = false;
            this.grdSubcontractView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdSubcontractView_KeyDown);
            this.grdSubcontractView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdSubcontractView_InvalidRowException);
            this.grdSubcontractView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdSubcontractView_ValidateRow);
            // 
            // repSubcontract
            // 
            this.repSubcontract.AutoHeight = false;
            this.repSubcontract.MaxLength = 50;
            this.repSubcontract.Name = "repSubcontract";
            // 
            // frmSubcontractMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 364);
            this.Controls.Add(this.grdSubcontract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSubcontractMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subcontract Documnets";
            this.Load += new System.EventHandler(this.frmSubcontractMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubcontractView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSubcontract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSubcontract;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSubcontractView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repSubcontract;


    }
}