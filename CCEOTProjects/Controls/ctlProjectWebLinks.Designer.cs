namespace CCEOTProjects.Controls
{
    partial class ctlProjectWebLinks
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
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdWebLinkView, "ctlProjectWebLinks");
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
            this.grdWebLink = new DevExpress.XtraGrid.GridControl();
            this.grdWebLinkView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repWebLink = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repItem = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.grdWebLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWebLinkView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repWebLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdWebLink
            // 
            this.grdWebLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWebLink.Location = new System.Drawing.Point(0, 0);
            this.grdWebLink.MainView = this.grdWebLinkView;
            this.grdWebLink.Name = "grdWebLink";
            this.grdWebLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repWebLink,
            this.repItem});
            this.grdWebLink.Size = new System.Drawing.Size(716, 173);
            this.grdWebLink.TabIndex = 450;
            this.grdWebLink.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdWebLinkView});
            // 
            // grdWebLinkView
            // 
            this.grdWebLinkView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdWebLinkView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdWebLinkView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.grdWebLinkView.Appearance.Row.Options.UseFont = true;
            this.grdWebLinkView.GridControl = this.grdWebLink;
            this.grdWebLinkView.Name = "grdWebLinkView";
            this.grdWebLinkView.OptionsCustomization.AllowColumnMoving = false;
            this.grdWebLinkView.OptionsCustomization.AllowFilter = false;
            this.grdWebLinkView.OptionsCustomization.AllowGroup = false;
            this.grdWebLinkView.OptionsView.ColumnAutoWidth = false;
            this.grdWebLinkView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdWebLinkView.OptionsView.ShowGroupPanel = false;
            this.grdWebLinkView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdWebLinkView_FocusedRowChanged);
            this.grdWebLinkView.DoubleClick += new System.EventHandler(this.grdWebLinkView_DoubleClick);
            this.grdWebLinkView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdWebLinkView_KeyDown);
            this.grdWebLinkView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdWebLinkView_InvalidRowException);
            this.grdWebLinkView.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(this.grdWebLinkView_ColumnWidthChanged);
            this.grdWebLinkView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdWebLinkView_ValidateRow);
            // 
            // repWebLink
            // 
            this.repWebLink.AutoHeight = false;
            this.repWebLink.MaxLength = 100;
            this.repWebLink.Name = "repWebLink";
            this.repWebLink.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repWebLink.MouseEnter += new System.EventHandler(this.repWebLink_MouseEnter);
            // 
            // repItem
            // 
            this.repItem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.repItem.Appearance.Options.UseFont = true;
            this.repItem.AutoHeight = false;
            this.repItem.MaxLength = 100;
            this.repItem.Name = "repItem";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdWebLink);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.webBrowser);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(720, 563);
            this.splitContainerControl1.SplitterPosition = 177;
            this.splitContainerControl1.TabIndex = 451;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(716, 376);
            this.webBrowser.TabIndex = 0;
            // 
            // ctlProjectWebLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ctlProjectWebLinks";
            this.Size = new System.Drawing.Size(720, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdWebLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWebLinkView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repWebLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdWebLink;
        private DevExpress.XtraGrid.Views.Grid.GridView grdWebLinkView;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repWebLink;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repItem;

    }
}
