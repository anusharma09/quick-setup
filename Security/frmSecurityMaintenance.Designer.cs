namespace Security
{
    partial class frmSecurityMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecurityMaintenance));
            this.grdUser = new DevExpress.XtraGrid.GridControl();
            this.grdUserView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repLANID = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repUserName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repEmail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdUserAccess = new DevExpress.XtraGrid.GridControl();
            this.grdUserAccessView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdUserJob = new DevExpress.XtraGrid.GridControl();
            this.grdUserJobView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repJobNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.barManager = new DevExpress.XtraBars.BarManager();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLANID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAccessView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserJobView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repJobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUser
            // 
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.Location = new System.Drawing.Point(0, 0);
            this.grdUser.MainView = this.grdUserView;
            this.grdUser.Name = "grdUser";
            this.grdUser.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLANID,
            this.repUserName,
            this.repEmail});
            this.grdUser.Size = new System.Drawing.Size(871, 241);
            this.grdUser.TabIndex = 449;
            this.grdUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdUserView});
            // 
            // grdUserView
            // 
            this.grdUserView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdUserView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdUserView.GridControl = this.grdUser;
            this.grdUserView.Name = "grdUserView";
            this.grdUserView.OptionsView.ColumnAutoWidth = false;
            this.grdUserView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdUserView.OptionsView.ShowGroupPanel = false;
            this.grdUserView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdUserView_FocusedRowChanged);
            this.grdUserView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdUserView_InvalidRowException);
            this.grdUserView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdUserView_ValidateRow);
            this.grdUserView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdUserView_KeyDown);
            // 
            // repLANID
            // 
            this.repLANID.AutoHeight = false;
            this.repLANID.MaxLength = 20;
            this.repLANID.Name = "repLANID";
            // 
            // repUserName
            // 
            this.repUserName.AutoHeight = false;
            this.repUserName.MaxLength = 35;
            this.repUserName.Name = "repUserName";
            // 
            // repEmail
            // 
            this.repEmail.AutoHeight = false;
            this.repEmail.MaxLength = 50;
            this.repEmail.Name = "repEmail";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 53);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdUser);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(871, 526);
            this.splitContainerControl1.SplitterPosition = 241;
            this.splitContainerControl1.TabIndex = 450;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.grdUserAccess);
            this.splitContainerControl2.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.grdUserJob);
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(871, 273);
            this.splitContainerControl2.SplitterPosition = 523;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // grdUserAccess
            // 
            this.grdUserAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserAccess.Location = new System.Drawing.Point(0, 29);
            this.grdUserAccess.MainView = this.grdUserAccessView;
            this.grdUserAccess.Name = "grdUserAccess";
            this.grdUserAccess.Size = new System.Drawing.Size(523, 244);
            this.grdUserAccess.TabIndex = 450;
            this.grdUserAccess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdUserAccessView});
            // 
            // grdUserAccessView
            // 
            this.grdUserAccessView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdUserAccessView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdUserAccessView.GridControl = this.grdUserAccess;
            this.grdUserAccessView.Name = "grdUserAccessView";
            this.grdUserAccessView.OptionsView.ColumnAutoWidth = false;
            this.grdUserAccessView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdUserAccessView.OptionsView.ShowGroupPanel = false;
            this.grdUserAccessView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdUserAccessView_InvalidRowException);
            this.grdUserAccessView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdUserAccessView_ValidateRow);
            this.grdUserAccessView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdUserAccessView_KeyDown);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(523, 29);
            this.panelControl2.TabIndex = 452;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(12, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(120, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Selected User Access";
            // 
            // grdUserJob
            // 
            this.grdUserJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserJob.Location = new System.Drawing.Point(0, 29);
            this.grdUserJob.MainView = this.grdUserJobView;
            this.grdUserJob.Name = "grdUserJob";
            this.grdUserJob.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repJobNumber});
            this.grdUserJob.Size = new System.Drawing.Size(336, 244);
            this.grdUserJob.TabIndex = 450;
            this.grdUserJob.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdUserJobView});
            // 
            // grdUserJobView
            // 
            this.grdUserJobView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdUserJobView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdUserJobView.GridControl = this.grdUserJob;
            this.grdUserJobView.Name = "grdUserJobView";
            this.grdUserJobView.OptionsView.ColumnAutoWidth = false;
            this.grdUserJobView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdUserJobView.OptionsView.ShowGroupPanel = false;
            this.grdUserJobView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grdUserJobView_InvalidRowException);
            this.grdUserJobView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdUserJobView_ValidateRow);
            this.grdUserJobView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdUserJobView_KeyDown);
            // 
            // repJobNumber
            // 
            this.repJobNumber.AutoHeight = false;
            this.repJobNumber.MaxLength = 10;
            this.repJobNumber.Name = "repJobNumber";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(336, 29);
            this.panelControl3.TabIndex = 452;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(12, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(161, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Selected User Assigned Jobs";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(871, 29);
            this.panelControl1.TabIndex = 451;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Users List";
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
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuHelp)});
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
            this.barDockControlTop.Size = new System.Drawing.Size(871, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 579);
            this.barDockControlBottom.Size = new System.Drawing.Size(871, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 555);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(871, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 555);
            // 
            // frmSecurityMaintenance
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
            this.Name = "frmSecurityMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Security";
            this.Load += new System.EventHandler(this.frmSecurityMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLANID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAccessView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserJobView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repJobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grdUserView;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl grdUserAccess;
        private DevExpress.XtraGrid.Views.Grid.GridView grdUserAccessView;
        private DevExpress.XtraGrid.GridControl grdUserJob;
        private DevExpress.XtraGrid.Views.Grid.GridView grdUserJobView;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repJobNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repLANID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repEmail;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
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

    }
}