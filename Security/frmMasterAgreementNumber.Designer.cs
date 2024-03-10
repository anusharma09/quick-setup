namespace Security
{
    partial class frmMasterAgreementNumber
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterAgreementNumber));
            this.grdMasterAgreement = new DevExpress.XtraGrid.GridControl();
            this.grdMasterAgreementView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repCompany = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repMasterNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repContractDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repSignedDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repLink = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.hyperlinkImport = new DevExpress.XtraEditors.HyperLinkEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.mnuFile = new DevExpress.XtraBars.BarSubItem();
            this.mnuExit = new DevExpress.XtraBars.BarStaticItem();
            this.mnuHelp = new DevExpress.XtraBars.BarSubItem();
            this.mnuAbout = new DevExpress.XtraBars.BarStaticItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdMasterAgreement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMasterAgreementView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMasterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repContractDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repContractDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSignedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSignedDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperlinkImport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMasterAgreement
            // 
            this.grdMasterAgreement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMasterAgreement.Location = new System.Drawing.Point(0, 0);
            this.grdMasterAgreement.MainView = this.grdMasterAgreementView;
            this.grdMasterAgreement.Name = "grdMasterAgreement";
            this.grdMasterAgreement.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCompany,
            this.repMasterNumber,
            this.repContractDate,
            this.repSignedDate,
            this.repLink});
            this.grdMasterAgreement.Size = new System.Drawing.Size(871, 514);
            this.grdMasterAgreement.TabIndex = 449;
            this.grdMasterAgreement.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdMasterAgreementView});
            // 
            // grdMasterAgreementView
            // 
            this.grdMasterAgreementView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdMasterAgreementView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdMasterAgreementView.GridControl = this.grdMasterAgreement;
            this.grdMasterAgreementView.Name = "grdMasterAgreementView";
            this.grdMasterAgreementView.OptionsView.ColumnAutoWidth = false;
            this.grdMasterAgreementView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdMasterAgreementView.OptionsView.ShowGroupPanel = false;
            this.grdMasterAgreementView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdMasterAgreementView_FocusedRowChanged);
            this.grdMasterAgreementView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdMasterAgreementView_InvalidRowException);
            this.grdMasterAgreementView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdMasterAgreementView_ValidateRow);
            this.grdMasterAgreementView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdMasterAgreementView_KeyDown);
            // 
            // repCompany
            // 
            this.repCompany.AutoHeight = false;
            this.repCompany.MaxLength = 200;
            this.repCompany.Name = "repCompany";
            // 
            // repMasterNumber
            // 
            this.repMasterNumber.AutoHeight = false;
            this.repMasterNumber.MaxLength = 100;
            this.repMasterNumber.Name = "repMasterNumber";
            // 
            // repContractDate
            // 
            this.repContractDate.AutoHeight = false;
            this.repContractDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repContractDate.MaxLength = 50;
            this.repContractDate.Name = "repContractDate";
            // 
            // repSignedDate
            // 
            this.repSignedDate.AutoHeight = false;
            this.repSignedDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSignedDate.MaxLength = 50;
            this.repSignedDate.Name = "repSignedDate";
            // 
            // repLink
            // 
            this.repLink.MaxLength = 500;
            this.repLink.Name = "repLink";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 51);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdMasterAgreement);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(871, 527);
            this.splitContainerControl1.SplitterPosition = 514;
            this.splitContainerControl1.TabIndex = 450;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.hyperlinkImport);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(871, 29);
            this.panelControl1.TabIndex = 451;
            // 
            // hyperlinkImport
            // 
            this.hyperlinkImport.EditValue = "Import Master Agreement...";
            this.hyperlinkImport.Location = new System.Drawing.Point(203, 8);
            this.hyperlinkImport.Name = "hyperlinkImport";
            this.hyperlinkImport.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperlinkImport.Properties.Appearance.Options.UseBackColor = true;
            this.hyperlinkImport.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperlinkImport.Size = new System.Drawing.Size(189, 18);
            this.hyperlinkImport.TabIndex = 10;
            this.hyperlinkImport.Click += new System.EventHandler(this.hyperlinkImport_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Master Agreement List";
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mnuFile,
            this.mnuExit,
            this.mnuHelp,
            this.mnuAbout});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 4;
            this.barManager.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuFile)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.RotateWhenVertical = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // mnuFile
            // 
            this.mnuFile.Caption = "&File";
            this.mnuFile.Id = 0;
            this.mnuFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuExit)});
            this.mnuFile.Name = "mnuFile";
            // 
            // mnuExit
            // 
            this.mnuExit.Caption = "&Exit";
            this.mnuExit.Id = 1;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.TextAlignment = System.Drawing.StringAlignment.Near;
            this.mnuExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Caption = "&Help";
            this.mnuHelp.Id = 2;
            this.mnuHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuAbout)});
            this.mnuHelp.Name = "mnuHelp";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Caption = "&About";
            this.mnuAbout.Id = 3;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.TextAlignment = System.Drawing.StringAlignment.Near;
            this.mnuAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ProcessMenuItem_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(871, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 578);
            this.barDockControlBottom.Size = new System.Drawing.Size(871, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 556);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(871, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 556);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // frmMasterAgreementNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 601);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMasterAgreementNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Agreement";
            this.Load += new System.EventHandler(this.frmMasterAgreementNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMasterAgreement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMasterAgreementView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMasterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repContractDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repContractDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSignedDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSignedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperlinkImport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMasterAgreement;
        private DevExpress.XtraGrid.Views.Grid.GridView grdMasterAgreementView;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repCompany;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repMasterNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repContractDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repSignedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repLink;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem mnuFile;
        private DevExpress.XtraBars.BarStaticItem mnuExit;
        private DevExpress.XtraBars.BarSubItem mnuHelp;
        private DevExpress.XtraBars.BarStaticItem mnuAbout;
        private DevExpress.XtraEditors.HyperLinkEdit hyperlinkImport;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}
